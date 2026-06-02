# CodeWF.AvaloniaControls.Dock

| Name | NuGet | Downloads |
|------|-------|-----------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |
| CodeWF.AvaloniaControls.Dock.Themes | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) |

Dock extension controls and theme resources for Avalonia 12. The repository keeps the reusable Dock controls separate from the Dock theme package so applications can reference only what they need.

## Install

```powershell
Install-Package CodeWF.AvaloniaControls.Dock
Install-Package CodeWF.AvaloniaControls.Dock.Themes
```

Applications that do not already reference Semi should also add `Semi.Avalonia`, because the CodeWF Tool title bar reuses Semi color resources.

```powershell
Install-Package Semi.Avalonia
```

## Theme Setup

```xml
<Application
    xmlns:codewf="https://codewf.com"
    xmlns:fluent="clr-namespace:Avalonia.Themes.Fluent;assembly=Avalonia.Themes.Fluent"
    xmlns:semi="https://irihi.tech/semi">
  <Application.Styles>
    <fluent:FluentTheme />
    <semi:SemiTheme Locale="en-US" />
    <codewf:DockCodeWFTheme />
  </Application.Styles>
</Application>
```

`DockCodeWFTheme` loads the open-source `Dock.Avalonia.Themes.Fluent` Dock theme and applies CodeWF refinements for Tool chrome buttons and Tool title bars. Keep the Fluent theme in the application style chain for the base Dock layout, and load `SemiTheme` before `DockCodeWFTheme` so Semi resource keys such as `SemiColorText0`, `SemiColorFill0`, and `SemiColorBorder` are available.

Remove the old `DockSemiTheme` entry when upgrading from earlier configurations. This package does not depend on the non-open-source `Semi.Avalonia.Dock` package.

## Tool Title Bar

`DockCodeWFTheme` exposes `CodeWFToolChromeControlTheme` for Tool panels that need a compact business-style title bar. The default title is left-aligned, uses neutral text, avoids colored active-title styling, and keeps the close button on the right.

Applications can override `CodeWFToolTitleTabHeaderTemplate` for Tool-specific title icons and `CodeWFToolTitleBarContentTemplate` for right-side title-bar content. Keep application-specific icons and actions in the application layer; the Dock package only provides the shared title-bar structure and resources.

## Repository Layout

- `src/CodeWF.AvaloniaControls.Dock`: reusable Dock control extensions
- `src/CodeWF.AvaloniaControls.Dock.Themes`: separated Fluent-based Dock theme package using Semi color resource keys
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`: ReactiveUI sample with nested Dock and process-embedding documentation
- `CodeWF.AvaloniaControls.Dock.slnx`: solution view for the Dock library, theme package, and sample

## Scripts

- `pack.bat`: restores, builds, and packs `CodeWF.AvaloniaControls.Dock` plus `CodeWF.AvaloniaControls.Dock.Themes` into `artifacts/packages`
- `publish_all.bat`: publishes all Dock sample applications into `publish/`
- `publishbase.bat`: shared publish helper used by the sample publish script

## Notes

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` keeps `Avalonia.Themes.Fluent` for the base style/layout chain, then loads `SemiTheme` so Dock title-bar resources can reuse Semi color tokens.
- `Prism.DryIoc.Avalonia` is pinned to `8.1.97.11073` because the `9.x` line is commercial.
- The controls package does not depend on Semi. The theme package references the MIT-licensed `Semi.Avalonia` package for shared color resources only, with no `Semi.Avalonia.Dock` or Ursa dependency.
- NuGet packages include the simple root logo assets: `logo.png`, `logo.svg`, and `logo.ico`.

## Third-Party Open Source Audit

Checked on 2026-06-02 with NuGet metadata, restored `project.assets.json`, package nuspec files, and upstream source/license links. MIT / Apache-2.0 / BSD are preferred. Source-open non-preferred licenses must be reviewed before use.

Remediation:

- Removed the previous Dock theme path and replaced it with the open-source `Dock.Avalonia.Themes.Fluent` theme.
- Rewired `DockCodeWFTheme` to load Fluent Dock resources plus CodeWF Tool chrome refinements.
- Reused open-source Semi color resources for CodeWF Tool title bars without using the non-open-source `Semi.Avalonia.Dock` package.
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
| `Semi.Avalonia` | MIT | https://github.com/irihitech/Semi.Avalonia | Approved; used for open-source theme resources and color tokens |
| `StaticViewLocator` | MIT | https://github.com/wieslawsoltes/StaticViewLocator | Approved |
| `System.*` runtime extension packages | MIT | https://github.com/dotnet/dotnet | Approved |
| `Tmds.DBus.Protocol` | MIT | https://github.com/tmds/Tmds.DBus | Approved |
| `VC-LTL` | EPL-2.0 | https://github.com/Chuyu-Team/VC-LTL5 | Source-open; approved under the source-traceable non-preferred license rule |
| `Xaml.Behaviors` | MIT | https://github.com/wieslawsoltes/Xaml.Behaviors | Approved |
| `YY-Thunks` | MIT | https://github.com/Chuyu-Team/YY-Thunks | Approved |

Transitive dependency check result: active restored assets are source-open and license-traceable. No closed or black-box Dock theme package is used.
