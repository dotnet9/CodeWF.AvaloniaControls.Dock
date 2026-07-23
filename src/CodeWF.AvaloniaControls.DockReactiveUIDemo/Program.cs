using Avalonia;
using ReactiveUI.Avalonia;
using System;
using System.IO;
using CodeWF.Log.Core;

namespace CodeWF.AvaloniaControls.DockReactiveUIDemo;

internal sealed class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        // DockSettings.UseFloatingDockAdorner = true;
        // DockSettings.EnableGlobalDocking = true;

        Logger.Initialize(new LoggerOptions
        {
            File = new FileLogOptions
            {
                DirectoryPath = Path.Combine(Environment.CurrentDirectory, "Log")
            }
        });

        try
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        finally
        {
            Logger.ShutdownAsync().GetAwaiter().GetResult();
        }
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .UseReactiveUI(_ => { })
            .LogToTrace();
}
