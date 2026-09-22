using Avalonia.Controls.Platform;
using Avalonia.Platform;
using System;

namespace CodeWF.AvaloniaControls.DockReactiveUIDemo.EmbedProcessWindows.Platforms.Linux;

/// <summary>
/// Linux 窗口句柄实现
/// </summary>
internal class LinuxWindowHandle : PlatformHandle, INativeControlHostDestroyableControlHandle
{
    private IntPtr _x11Display;

    public LinuxWindowHandle(IntPtr handle, string? descriptor, IntPtr x11Display = default) : base(handle, descriptor)
    {
        _x11Display = x11Display == default ? X11Api.XOpenDisplay(IntPtr.Zero) : x11Display;
    }

    public void Destroy()
    {
        // The handle belongs to the external process. Destroying it here can
        // terminate the child window before the embedder has restored it.
        SetDisplayInvalid();
    }

    public void SetDisplayInvalid()
    {
        _x11Display = IntPtr.Zero;
    }
}
