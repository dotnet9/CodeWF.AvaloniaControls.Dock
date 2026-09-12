using System;
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
        if (dock is INotifyPropertyChanged notify) notify.PropertyChanged += subscription.OnPropertyChanged;
        if (dock.VisibleDockables is INotifyCollectionChanged collection)
            collection.CollectionChanged += subscription.OnCollectionChanged;
        subscription.SubscribeChildren();
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
        var grid = control.GetVisualDescendants().OfType<Grid>().FirstOrDefault();
        if (grid is null)
            return;

        var visible = dock.VisibleDockables ?? Array.Empty<IDockable>();
        var left = visible.Any(item => item.Column == 0 && HasVisibleContent(item));
        var right = visible.Any(item => item.Column == 4 && HasVisibleContent(item));
        grid.ColumnDefinitions = ColumnDefinitions.Parse($"{(left ? 200 : 0)}, {(left ? 4 : 0)}, *, {(right ? 4 : 0)}, {(right ? 280 : 0)}");
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

        public Subscription(GridDockControl control, IDock dock)
        {
            _control = control;
            _dock = dock;
        }

        public void SubscribeChildren()
        {
            if (_dock.VisibleDockables is null) return;
            foreach (var child in _dock.VisibleDockables.OfType<INotifyPropertyChanged>())
                child.PropertyChanged += OnChildPropertyChanged;
        }

        public void OnPropertyChanged(object? sender, PropertyChangedEventArgs e) => Apply(_control, _dock);
        public void OnChildPropertyChanged(object? sender, PropertyChangedEventArgs e) => Apply(_control, _dock);

        public void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems is not null)
                foreach (var child in e.OldItems.OfType<INotifyPropertyChanged>())
                    child.PropertyChanged -= OnChildPropertyChanged;
            if (e.NewItems is not null)
                foreach (var child in e.NewItems.OfType<INotifyPropertyChanged>())
                    child.PropertyChanged += OnChildPropertyChanged;
            Apply(_control, _dock);
        }
        public void OnLayoutUpdated(object? sender, EventArgs e)
        {
            if (_control.GetVisualDescendants().OfType<Grid>().FirstOrDefault() is not Grid)
                return;

            _control.LayoutUpdated -= OnLayoutUpdated;
            Apply(_control, _dock);
        }

        public void Dispose()
        {
            if (_dock is INotifyPropertyChanged notify) notify.PropertyChanged -= OnPropertyChanged;
            if (_dock.VisibleDockables is INotifyCollectionChanged collection)
                collection.CollectionChanged -= OnCollectionChanged;
            if (_dock.VisibleDockables is not null)
                foreach (var child in _dock.VisibleDockables.OfType<INotifyPropertyChanged>())
                    child.PropertyChanged -= OnChildPropertyChanged;
            _control.LayoutUpdated -= OnLayoutUpdated;
        }
    }
}
