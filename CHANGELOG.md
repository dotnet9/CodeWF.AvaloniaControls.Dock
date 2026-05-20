# Changelog

English | [Simplified Chinese](CHANGELOG.zh-CN.md)

## 12.0.3.2 (2026-05-20)

- Added `CodeWF.AvaloniaControls.Dock.Themes` as a separated theme package for Dock XAML resources.
- Moved `DockSemiTheme`, `DockCodeWFTheme`, and Dock document control styles out of the main controls package.
- Removed the `Dock.Avalonia.Themes.Fluent` dependency from `CodeWF.AvaloniaControls.Dock`; it now lives only in the theme package.
- Added missing Semi-compatible document control resources, including `DocumentControlContentCornerRadius` and `DocumentControlContentBorderThickness`, so the ReactiveUI sample starts without the previous `InvalidCastException`.
- Updated the ReactiveUI sample to reference both `CodeWF.AvaloniaControls.Dock` and `CodeWF.AvaloniaControls.Dock.Themes`.
- Updated the sample version display, central package versions, README files, and package audit notes for Avalonia `12.0.3`.
- Updated `pack.bat` so it packs both the controls package and the theme package into `artifacts/packages`.

## 12.0.2 (2026-05-08)

- Migrated `CodeWF.AvaloniaControls.Dock` and its Dock sample applications into this standalone repository.
- Added the Dock-only solution, central package versions, packing script, and sample publish script.
- Updated `CodeWF.AvaloniaControls.DockReactiveUIDemo` to consume `CodeWF.AvaloniaControls.Themes` from NuGet instead of referencing the main control source project.
- Updated demo document pages to use cards, timelines, and status panels instead of directly embedding the old DataGrid sample path.
- Removed the old free grid control path from the ordinary Dock sample flow to keep the Avalonia 12 sample stable.
- Polished Chinese UI text in the sample pages.
