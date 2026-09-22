using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.VisualTree;
using CodeWF.AvaloniaControls.DockReactiveUIDemo.EmbedProcessWindows.Contracts;
using CodeWF.AvaloniaControls.DockReactiveUIDemo.EmbedProcessWindows.Models;
using CodeWF.Log.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CodeWF.AvaloniaControls.DockReactiveUIDemo.EmbedProcessWindows.Core;

/// <summary>
/// Hosts an external process window without blocking Avalonia's UI thread.
/// </summary>
public class ProcessEmbedHost : ContentControl
{
    private static readonly object InstancesLock = new();
    private static readonly List<WeakReference<ProcessEmbedHost>> Instances = new();

    private CancellationTokenSource? _initializationCancellation;
    private Task? _initializationTask;
    private EmbeddedNativeControlHost? _nativeHost;
    private int _lifecycleVersion;

    public INativeProcessEmbedder Embedder { get; }

    public ProcessEmbedHost(ProcessEmbedOptions options)
    {
        Embedder = ProcessEmbedderFactory.Create(options);
        RegisterInstance();
        AttachedToVisualTree += OnAttachedToVisualTree;
        DetachedFromVisualTree += OnDetachedFromVisualTree;
    }

    public ProcessEmbedHost(string processPath, string? workingDirectory = null, string? arguments = null)
        : this(ProcessEmbedOptions.Create(processPath, workingDirectory, arguments))
    {
    }

    private void RegisterInstance()
    {
        lock (InstancesLock)
        {
            Instances.RemoveAll(reference => !reference.TryGetTarget(out _));
            Instances.Add(new WeakReference<ProcessEmbedHost>(this));
        }
    }

    private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        if (_initializationTask is not null)
            return;

        var version = ++_lifecycleVersion;
        _initializationCancellation = new CancellationTokenSource();
        _initializationTask = PrepareAndAttachAsync(version, _initializationCancellation.Token);
    }

    private async Task PrepareAndAttachAsync(int version, CancellationToken cancellationToken)
    {
        try
        {
            await Task.Run(Embedder.Prepare, cancellationToken);

            if (cancellationToken.IsCancellationRequested || version != _lifecycleVersion ||
                !this.IsAttachedToVisualTree())
            {
                return;
            }

            _nativeHost = new EmbeddedNativeControlHost(Embedder);
            Content = _nativeHost;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception ex)
        {
            Logger.Error("准备嵌入进程窗口异常", ex, "准备嵌入进程窗口异常，请检查进程路径和桌面会话！");
            Embedder.Close();

            if (!cancellationToken.IsCancellationRequested && version == _lifecycleVersion)
            {
                Content = new TextBlock
                {
                    Text = "无法嵌入外部进程窗口",
                    TextWrapping = TextWrapping.Wrap
                };
            }
        }
        finally
        {
            if (version == _lifecycleVersion)
                _initializationTask = null;
        }
    }

    private async void OnDetachedFromVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        ++_lifecycleVersion;
        var detachedVersion = _lifecycleVersion;
        _initializationCancellation?.Cancel();

        var initializationTask = _initializationTask;
        _initializationTask = null;
        _initializationCancellation?.Dispose();
        _initializationCancellation = null;

        Content = null;

        if (initializationTask is not null)
        {
            try
            {
                await initializationTask;
            }
            catch (Exception ex)
            {
                Logger.Error("等待嵌入进程初始化结束异常", ex, "等待嵌入进程初始化结束异常，请联系管理员！");
            }
        }

        if (detachedVersion == _lifecycleVersion)
        {
            Embedder.Close();
            _nativeHost = null;
        }
    }

    /// <summary>
    /// Stops the embedded process and releases native resources.
    /// </summary>
    public void Close()
    {
        ++_lifecycleVersion;
        _initializationCancellation?.Cancel();
        _initializationCancellation?.Dispose();
        _initializationCancellation = null;
        _initializationTask = null;
        Content = null;
        _nativeHost = null;
        Embedder.Close();
    }

    /// <summary>
    /// Closes all live embedding hosts.
    /// </summary>
    public static void CloseAll()
    {
        ProcessEmbedHost[] instances;
        lock (InstancesLock)
        {
            instances = new ProcessEmbedHost[Instances.Count];
            var count = 0;
            foreach (var reference in Instances)
            {
                if (reference.TryGetTarget(out var instance))
                    instances[count++] = instance;
            }

            Array.Resize(ref instances, count);
            Instances.Clear();
        }

        foreach (var instance in instances)
            instance.Close();
    }

    private sealed class EmbeddedNativeControlHost(INativeProcessEmbedder embedder) : NativeControlHost
    {
        protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent) =>
            embedder.AttachWindow(parent, () => base.CreateNativeControlCore(parent));

        protected override void DestroyNativeControlCore(IPlatformHandle control)
        {
            base.DestroyNativeControlCore(control);
        }
    }
}
