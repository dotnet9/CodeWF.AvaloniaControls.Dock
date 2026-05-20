# CodeWF.AvaloniaControls.Dock

| Name | NuGet | Download |
|------|-------|----------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |
| CodeWF.AvaloniaControls.Dock.Themes | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) |

Dock extension controls and Fluent-based theme resources for Avalonia 12.

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
    xmlns:fluent="clr-namespace:Avalonia.Themes.Fluent;assembly=Avalonia.Themes.Fluent">
  <Application.Styles>
    <fluent:FluentTheme />
    <codewf:DockCodeWFTheme />
  </Application.Styles>
</Application>
```

`DockCodeWFTheme` loads the open-source `Dock.Avalonia.Themes.Fluent` theme and applies CodeWF visibility refinements for Dock tool chrome buttons and headers. Remove the old `DockSemiTheme` entry when upgrading to `12.0.3.3`.

`DockCodeWFTheme` also exposes the opt-in `CodeWFToolChromeControlTheme` resource for Tool panels that should render a business-style title bar: the active Tool title is shown on the left, custom title-bar content can be supplied through the `CodeWFToolTitleBarContentTemplate` resource, and only the close button is shown on the right.

## Repository Layout

- `src/CodeWF.AvaloniaControls.Dock`: reusable Dock control extensions
- `src/CodeWF.AvaloniaControls.Dock.Themes`: separated Fluent-based Dock theme package
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`: ReactiveUI sample with nested Dock and process-embedding documentation
- `CodeWF.AvaloniaControls.Dock.slnx`: solution view for the Dock library, theme package, and sample

## Scripts

- `pack.bat`: restore, build, and pack `CodeWF.AvaloniaControls.Dock` plus `CodeWF.AvaloniaControls.Dock.Themes` into `artifacts/packages`
- `publish_all.bat`: publish all Dock sample applications into `publish/`
- `publishbase.bat`: shared publish helper used by the sample publish script

## Notes

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` now uses Avalonia Fluent directly and no longer references a separate application theme package.
- `Prism.DryIoc.Avalonia` is pinned to `8.1.97.11073` because the `9.x` line is commercial.
- The active restore assets for the controls, themes, and sample projects contain no `Semi.Avalonia` or Ursa packages.

## Third-Party Open Source Audit

Checked on 2026-05-20 with NuGet metadata, restored `project.assets.json`, package nuspec files, and upstream source/license links. MIT / Apache-2.0 / BSD are preferred. Source-open non-preferred licenses must be reviewed before use.

Remediation:

- Removed the previous Dock theme path and replaced it with the open-source `Dock.Avalonia.Themes.Fluent` theme.
- Rewired `DockCodeWFTheme` to load Fluent plus CodeWF tool chrome visibility refinements.
- Removed direct and indirect sample dependencies on `CodeWF.AvaloniaControls.Themes`, `Semi.Avalonia`, and Ursa theme packages.
- Removed self-maintained Dock XAML resources that depended on non-Fluent theme keys.

| Package / family | License | Source | Status |
| --- | --- | --- | --- |
| `Avalonia`, `Avalonia.Desktop`, `Avalonia.Fonts.Inter`, `Avalonia.Themes.Fluent`, `Avalonia.*` native/platform packages | MIT | https://github.com/AvaloniaUI/Avalonia | Approved |
| `CodeWF.AvaloniaControls.Dock`, `CodeWF.AvaloniaControls.Dock.Themes` | MIT | https://github.com/dotnet9/CodeWF.AvaloniaControls.Dock | Own open-source packages |
| `CodeWF.EventBus`, `CodeWF.Log.Core` | MIT | CodeWF repositories | Own open-source packages |
| `Dock.Avalonia`, `Dock.Avalonia.Themes.Fluent`, `Dock.Model.ReactiveUI`, `Dock.Controls.*`, `Dock.Model`, `Dock.Settings` | MIT | https://github.com/wieslawsoltes/Dock | Approved |
| `DryIoc.dll` | MIT | https://github.com/dadhi/DryIoc | Approved |
| `DynamicData`, `ReactiveUI`, `Splat`, `System.Reactive` | MIT | https://github.com/reactiveui | Approved |
| `HarfBuzzSharp`, `SkiaSharp` and native assets | MIT | https://github.com/mono/SkiaSharp | Approved |
| `MicroCom.Runtime` | MIT | https://github.com/AvaloniaUI/MicroCom | Approved |
| `Prism.DryIoc.Avalonia`, `Prism.Avalonia`, `Prism.Core` | MIT | https://github.com/AvaloniaCommunity/Prism.Avalonia | Approved, pinned to 8.x |
| `StaticViewLocator` | MIT | https://github.com/wieslawsoltes/StaticViewLocator | Approved |
| `System.*` runtime extension packages | MIT | https://github.com/dotnet/dotnet | Approved |
| `Tmds.DBus.Protocol` | MIT | https://github.com/tmds/Tmds.DBus | Approved |
| `VC-LTL` | EPL-2.0 | https://github.com/Chuyu-Team/VC-LTL5 | Source-open; approved under the source-traceable non-preferred license rule |
| `Xaml.Behaviors` | MIT | https://github.com/wieslawsoltes/Xaml.Behaviors | Approved |
| `YY-Thunks` | MIT | https://github.com/Chuyu-Team/YY-Thunks | Approved |

Transitive dependency check result: active restored assets are source-open and license-traceable. No closed or black-box Dock theme package is used.
