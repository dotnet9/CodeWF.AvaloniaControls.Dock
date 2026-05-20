using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CodeWF.AvaloniaControls.DockReactiveUIDemo.EmbedProcessWindows.Core;
using System;
using System.Threading.Tasks;

namespace CodeWF.AvaloniaControls.DockReactiveUIDemo.Views;

public partial class MainWindow : Window
{
    private bool _isCloseConfirmed;

    public MainWindow()
    {
        InitializeComponent();

        PropertyChanged += async (s, e) => 
        {
            if(e.Property == WindowStateProperty && OperatingSystem.IsWindows())
            {
                if(WindowState == WindowState.Minimized)
                {
                    Hide();
                    ShowInTaskbar = false;
                }
                else
                {
                    Show();
                    Activate();
                    ShowInTaskbar = true;
                }
            }
        };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    protected override async void OnClosing(WindowClosingEventArgs e)
    {
        if (_isCloseConfirmed)
        {
            base.OnClosing(e);
            return;
        }

        e.Cancel = true;
        if (!IsVisible)
        {
            Show();
            ShowInTaskbar = true;
            Activate();
        }

        if (!await ShowExitConfirmationAsync())
        {
            return;
        }

        _isCloseConfirmed = true;
        Close();
    }

    protected override void OnClosed(EventArgs e)
    {
        ProcessEmbedHost.CloseAll();
        base.OnClosed(e);
    }

    private async Task<bool> ShowExitConfirmationAsync()
    {
        var dialog = new Window
        {
            Title = "Confirm Exit",
            Width = 360,
            Height = 170,
            CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = BuildExitConfirmationContent(out var confirmButton, out var cancelButton)
        };

        confirmButton.Click += (_, _) => dialog.Close(true);
        cancelButton.Click += (_, _) => dialog.Close(false);

        return await dialog.ShowDialog<bool>(this);
    }

    private static Control BuildExitConfirmationContent(out Button confirmButton, out Button cancelButton)
    {
        confirmButton = new Button
        {
            Content = "Exit",
            MinWidth = 86,
            HorizontalContentAlignment = HorizontalAlignment.Center
        };
        cancelButton = new Button
        {
            Content = "Cancel",
            MinWidth = 86,
            HorizontalContentAlignment = HorizontalAlignment.Center
        };

        return new Border
        {
            Padding = new Thickness(20),
            Background = Brushes.White,
            Child = new StackPanel
            {
                Spacing = 18,
                Children =
                {
                    new TextBlock
                    {
                        Text = "Are you sure you want to exit?",
                        TextWrapping = TextWrapping.Wrap,
                        Foreground = new SolidColorBrush(Color.Parse("#111827")),
                        FontSize = 14
                    },
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Spacing = 8,
                        Children =
                        {
                            cancelButton,
                            confirmButton
                        }
                    }
                }
            }
        };
    }
}
