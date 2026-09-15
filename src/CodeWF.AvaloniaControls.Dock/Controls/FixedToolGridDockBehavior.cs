using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.VisualTree;
using Dock.Avalonia.Controls;
using Dock.Model.Controls;
using Dock.Model.Core;

namespace CodeWF.AvaloniaControls.Dock.Controls;

/// <summary>
/// Keeps the side Tool columns of a GridDock at fixed pixel widths and releases
/// those columns when their dock becomes empty.
/// </summary>
public static class FixedToolGridDockBehavior
{
    public static readonly AttachedProperty<bool> IsEnabledProperty =
        AvaloniaProperty.RegisterAttached<DockControl, Control, bool>("IsEnabled", false);

    static FixedToolGridDockBehavior()
    {
        IsEnabledProperty.Changed.AddClassHandler<Control>((control, change) =>
        {
            if (change.NewValue is true)
            {
                control.AttachedToVisualTree += OnAttachedToVisualTree;
                control.DetachedFromVisualTree += OnDetachedFromVisualTree;
                if (control.IsAttachedToVisualTree())
                {
                    Refresh(control);
                    control.LayoutUpdated += OnOwnerLayoutUpdated;
                    Dispatcher.UIThread.Post(() => Refresh(control), DispatcherPriority.Background);
                }
            }
            else
            {
                control.AttachedToVisualTree -= OnAttachedToVisualTree;
                control.DetachedFromVisualTree -= OnDetachedFromVisualTree;
            }
        });
    }

    public static bool GetIsEnabled(AvaloniaObject element) => element.GetValue(IsEnabledProperty);
    public static void SetIsEnabled(AvaloniaObject element, bool value) => element.SetValue(IsEnabledProperty, value);

    private static void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        if (sender is Control control)
        {
            control.LayoutUpdated -= OnOwnerLayoutUpdated;
            control.LayoutUpdated += OnOwnerLayoutUpdated;
            Refresh(control);
            Dispatcher.UIThread.Post(() => Refresh(control), DispatcherPriority.Background);
        }
    }

    private static void OnDetachedFromVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        if (sender is not Control control) return;
        control.LayoutUpdated -= OnOwnerLayoutUpdated;
        foreach (var gridDock in control.GetVisualDescendants().OfType<GridDockControl>())
            Unsubscribe(gridDock);
    }

    private static void OnOwnerLayoutUpdated(object? sender, EventArgs e)
    {
        if (sender is not Control control) return;
        // DeferredContentControl materializes the RootDock content after the first
        // layout pass. Keep watching until the GridDockControl and its panel exist.
        if (Refresh(control))
            control.LayoutUpdated -= OnOwnerLayoutUpdated;
    }

    private static bool Refresh(Control owner)
    {
        var controls = owner is GridDockControl direct
            ? new[] { direct }
            : owner.GetVisualDescendants().OfType<GridDockControl>();
        var found = false;
        foreach (var gridDock in controls)
        {
            if (gridDock.DataContext is not IDock dock) continue;
            found = true;
            Subscribe(gridDock, dock);
            Apply(gridDock, dock);
        }
        return found;
    }

    private static void Subscribe(GridDockControl control, IDock dock)
    {
        if (control.Tag is Subscription) return;
        var subscription = new Subscription(control, dock);
        control.Tag = subscription;
        subscription.SubscribeDockTree();
        control.LayoutUpdated += subscription.OnLayoutUpdated;
    }

    private static void Unsubscribe(GridDockControl control)
    {
        if (control.Tag is not Subscription subscription) return;
        subscription.Dispose();
        control.Tag = null;
    }

    private static void Apply(GridDockControl control, IDock dock)
    {
        // ItemsPanelRoot can still be null while DeferredContentControl is
        // materializing the template. The panel itself is the only Grid in the
        // GridDockControl template, so find it directly once it exists.
        // GridDockControl templates can contain nested content Grids. The
        // layout grid is the one with the five columns supplied by DockFactory;
        // prefer it so a document view cannot be mistaken for the host grid.
        var grid = control.GetVisualDescendants().OfType<Grid>()
            .FirstOrDefault(candidate => candidate.ColumnDefinitions.Count == 5);
        if (grid is null)
            return;

        var visible = dock.VisibleDockables ?? Array.Empty<IDockable>();
        var left = visible.Any(item => item.Column == 0 && HasVisibleContent(item));
        var right = visible.Any(item => item.Column == 4 && HasVisibleContent(item));
        var definitions = new[]
        {
            new GridLength(left ? 200 : 0),
            new GridLength(left ? 4 : 0),
            new GridLength(1, GridUnitType.Star),
            new GridLength(right ? 4 : 0),
            new GridLength(right ? 280 : 0)
        };
        if (grid.ColumnDefinitions.Count == definitions.Length &&
            grid.ColumnDefinitions.Select((column, index) => column.Width == definitions[index]).All(match => match))
            return;

        grid.ColumnDefinitions = ColumnDefinitions.Parse(
            $"{(left ? 200 : 0)}, {(left ? 4 : 0)}, *, {(right ? 4 : 0)}, {(right ? 280 : 0)}");
        grid.InvalidateMeasure();
        grid.InvalidateArrange();
    }

    private static bool HasVisibleContent(IDockable item)
    {
        if (item is ISplitter || item.IsEmpty)
            return false;
        if (item is IDock dock && dock.VisibleDockables is { Count: > 0 } children)
            return children.Any(HasVisibleContent);
        return true;
    }


    private sealed class Subscription : IDisposable
    {
        private readonly GridDockControl _control;
        private readonly IDock _dock;
        private readonly HashSet<INotifyPropertyChanged> _propertySources = new();
        private readonly HashSet<INotifyCollectionChanged> _collectionSources = new();

        public Subscription(GridDockControl control, IDock dock)
        {
            _control = control;
            _dock = dock;
        }

        public void SubscribeDockTree()
        {
            foreach (var source in _propertySources)
                source.PropertyChanged -= OnChildPropertyChanged;
            foreach (var source in _collectionSources)
                source.CollectionChanged -= OnCollectionChanged;

            _propertySources.Clear();
            _collectionSources.Clear();
            SubscribeDock(_dock);
        }

        private void SubscribeDock(IDock dock)
        {
            if (dock is INotifyPropertyChanged notify)
                SubscribePropertySource(notify);
            if (dock.VisibleDockables is not INotifyCollectionChanged collection)
                return;

            _collectionSources.Add(collection);
            collection.CollectionChanged += OnCollectionChanged;
            foreach (var child in dock.VisibleDockables ?? Array.Empty<IDockable>())
            {
                if (child is INotifyPropertyChanged childNotify)
                    SubscribePropertySource(childNotify);

                if (child is IDock childDock)
                    SubscribeDock(childDock);
            }
        }

        private void SubscribePropertySource(INotifyPropertyChanged source)
        {
            if (_propertySources.Add(source))
                source.PropertyChanged += OnChildPropertyChanged;
        }

        public void OnChildPropertyChanged(object? sender, PropertyChangedEventArgs e) => Apply(_control, _dock);

        public void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            SubscribeDockTree();
            Apply(_control, _dock);
        }
        public void OnLayoutUpdated(object? sender, EventArgs e)
        {
            if (_control.GetVisualDescendants().OfType<Grid>().FirstOrDefault() is not Grid)
                return;

            // A Tool can be hidden after the initial layout and the change may
            // only invalidate the nested ToolDock. Reapply on later layout
            // passes so the outer Grid releases the hidden side column too.
            Apply(_control, _dock);
        }

        public void Dispose()
        {
            foreach (var source in _propertySources)
                source.PropertyChanged -= OnChildPropertyChanged;
            foreach (var source in _collectionSources)
                source.CollectionChanged -= OnCollectionChanged;
            _propertySources.Clear();
            _collectionSources.Clear();
            _control.LayoutUpdated -= OnLayoutUpdated;
        }
    }
}
