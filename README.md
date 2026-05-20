# CodeWF.AvaloniaControls.Dock

| Name | NuGet | Download |
|------|-------|----------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |
| CodeWF.AvaloniaControls.Dock.Themes | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) |

Dock extension controls and separated Semi-compatible theme resources for Avalonia 12.

English | [简体中文](README.zh-CN.md)

## Install

```shell
Install-Package CodeWF.AvaloniaControls.Dock
Install-Package CodeWF.AvaloniaControls.Dock.Themes
```

## Theme Setup

```xml
<Application
    xmlns:codewf="https://codewf.com"
    xmlns:semi="https://irihi.tech/semi">
  <Application.Styles>
    <semi:SemiTheme Locale="zh-CN" />
    <codewf:DockSemiTheme />
    <codewf:DockCodeWFTheme />
  </Application.Styles>
</Application>
```

`CodeWF.AvaloniaControls.Dock` contains only reusable Dock controls and converters. `CodeWF.AvaloniaControls.Dock.Themes` contains the Dock theme entry points and all Dock XAML style resources.

## Repository Layout

- `src/CodeWF.AvaloniaControls.Dock`: reusable Dock control extensions
- `src/CodeWF.AvaloniaControls.Dock.Themes`: separated Dock theme package and Semi-compatible style resources
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`: ReactiveUI sample with nested Dock and process-embedding documentation
- `CodeWF.AvaloniaControls.Dock.slnx`: solution view for the Dock library, theme package, and sample

## Scripts

- `pack.bat`: restore, build, and pack `CodeWF.AvaloniaControls.Dock` plus `CodeWF.AvaloniaControls.Dock.Themes` into `artifacts/packages`
- `publish_all.bat`: publish all Dock sample applications into `publish/`
- `publishbase.bat`: shared publish helper used by the sample publish script

## Notes

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` uses `CodeWF.AvaloniaControls.Themes` version `12.0.3.3` from NuGet instead of referencing the main `CodeWF.AvaloniaControls` source project.
- `Prism.DryIoc.Avalonia` is pinned to `8.1.97.11073` because the `9.x` line is commercial.
- `Semi.Avalonia.Dock` is not referenced. The Dock-specific Semi style resources are maintained in `CodeWF.AvaloniaControls.Dock.Themes`.

## Third-Party Open Source Audit

Checked on 2026-05-20 with NuGet metadata, restored `project.assets.json`, and upstream source/license links. MIT / Apache-2.0 / BSD are preferred. Source-open non-preferred licenses must be reviewed before use.

Remediation:

- Removed `Semi.Avalonia.Dock`; it only provides a Semi Dock theme and no public source repository was found.
- Split the Dock package into controls and themes. `CodeWF.AvaloniaControls.Dock` no longer references `Dock.Avalonia.Themes.Fluent`; only `CodeWF.AvaloniaControls.Dock.Themes` depends on the open-source Fluent Dock theme package.
- Added `CodeWF.AvaloniaControls.Dock.Themes` with self-maintained Semi-compatible XAML resources, adapted from the old source snapshot under `E:\github\company\xskj\src\Semi.Avalonia.Dock`.
- Removed `AvaloniaUI.DiagnosticsSupport` from samples because the package does not publish a clear open-source license or source repository.

| Package | License | Source | Status |
| --- | --- | --- | --- |
| `Avalonia` / `Avalonia.Desktop` / `Avalonia.Fonts.Inter` / `Avalonia.Themes.Fluent` | MIT | https://github.com/AvaloniaUI/Avalonia | Approved |
| `CodeWF.AvaloniaControls.Dock` / `CodeWF.AvaloniaControls.Dock.Themes` | MIT | https://github.com/dotnet9/CodeWF.AvaloniaControls.Dock | Own open-source packages |
| `CodeWF.AvaloniaControls.Themes` / `CodeWF.EventBus` / `CodeWF.Log.Core` | MIT | CodeWF repositories | Own open-source packages |
| `Dock.Avalonia` / `Dock.Avalonia.Themes.Fluent` / `Dock.Model.ReactiveUI` | MIT | https://github.com/wieslawsoltes/Dock | Approved |
| `Irihi.Ursa.Themes.Semi` | MIT | https://github.com/irihitech/Ursa.Avalonia | Approved |
| `Prism.DryIoc.Avalonia` | MIT | https://github.com/AvaloniaCommunity/Prism.Avalonia | Approved, pinned to 8.x |
| `ReactiveUI.Avalonia` | MIT | https://github.com/reactiveui/reactiveui | Approved |
| `Semi.Avalonia` | MIT | https://github.com/irihitech/Semi.Avalonia | Approved, only the open core package is used |
| `StaticViewLocator` | MIT | https://github.com/wieslawsoltes/StaticViewLocator | Approved |
| `System.Drawing.Common` / `System.Security.Permissions` / `System.Windows.Extensions` | MIT | https://github.com/dotnet/dotnet | Approved, pinned to `10.0.8` |
| `VC-LTL` | EPL-2.0 | https://github.com/Chuyu-Team/VC-LTL5 | Source-open; approved under the source-traceable non-preferred license rule |
| `Xaml.Behaviors` | MIT | https://github.com/wieslawsoltes/Xaml.Behaviors | Approved |
| `YY-Thunks` | MIT | https://github.com/Chuyu-Team/YY-Thunks | Approved |

Transitive dependencies from Dock, Avalonia, ReactiveUI, Prism.Avalonia, Semi.Avalonia, Ursa.Avalonia, and SkiaSharp were checked and are source-open under MIT or BSD-style licenses. Active restore assets no longer contain `Semi.Avalonia.Dock`.
