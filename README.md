# CodeWF.AvaloniaControls.Dock

| Name | NuGet | Download |
|------|-------|----------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |

Dock extension controls and Semi-theme integration samples for Avalonia 12.

English | [简体中文](README.zh-CN.md)

## Install

```shell
Install-Package CodeWF.AvaloniaControls.Dock
```

## Repository Layout

- `src/CodeWF.AvaloniaControls.Dock`: reusable Dock styling and control extensions
- `src/CodeWF.AvaloniaControls.DockDemo`: basic Dock sample
- `src/CodeWF.AvaloniaControls.DockPrismDemo`: Prism container integration sample
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`: ReactiveUI sample with nested Dock and process-embedding documentation
- `CodeWF.AvaloniaControls.Dock.slnx`: solution view for the Dock library and samples

## Scripts

- `pack.bat`: restore, build, and pack `CodeWF.AvaloniaControls.Dock` into `artifacts/packages`
- `publish_all.bat`: publish all Dock sample applications into `publish/`
- `publishbase.bat`: shared publish helper used by the sample publish script

## Notes

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` uses `CodeWF.AvaloniaControls.Themes` version `12.0.2.1` from NuGet instead of referencing the main `CodeWF.AvaloniaControls` source project.
- `Prism.DryIoc.Avalonia` is pinned to `8.1.97.11073` because the `9.x` line is commercial.
