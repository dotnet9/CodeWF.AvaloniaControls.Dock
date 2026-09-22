using Avalonia.Controls.Platform;
using Avalonia.Platform;
using System;

namespace CodeWF.AvaloniaControls.DockReactiveUIDemo.EmbedProcessWindows.Platforms.Windows;

/// <summary>
/// Windows 窗口句柄实现
/// </summary>
internal class WindowsWindowHandle : PlatformHandle, INativeControlHostDestroyableControlHandle
{
    public WindowsWindowHandle(IntPtr handle, string? descriptor) : base(handle, descriptor)
    {
    }

    public void Destroy()
    {
        // The HWND belongs to the external process. Process shutdown owns its
        // lifetime; destroying it here can leave that process in a bad state.
    }
}
