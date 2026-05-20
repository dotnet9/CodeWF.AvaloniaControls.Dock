# Changelog

English | [Simplified Chinese](CHANGELOG.zh-CN.md)

## 12.0.3.3 (2026-05-20)

- Reworked `CodeWF.AvaloniaControls.Dock.Themes` to use the open-source Fluent Dock theme as its only Dock theme base.
- Added `DockFluentTheme` and rewired `DockCodeWFTheme` to load Fluent plus CodeWF tool chrome visibility refinements.
- Removed the old Dock theme entry point and self-maintained XAML resources that depended on non-Fluent theme keys.
- Improved Tool chrome title, menu, pin, and close button contrast so tool panels stay readable in light workspaces.
- Updated the ReactiveUI sample to use Avalonia Fluent directly and removed indirect sample dependencies on extra application theme packages.
- Updated the package audit notes and version to `12.0.3.3`.

## 12.0.3.2 (2026-05-20)

- Added `CodeWF.AvaloniaControls.Dock.Themes` as a separated theme package for Dock XAML resources.
- Moved `DockCodeWFTheme` and Dock document control styles out of the main controls package.
- Removed the `Dock.Avalonia.Themes.Fluent` dependency from `CodeWF.AvaloniaControls.Dock`; it now lives only in the theme package.
- Added missing document control resources, including `DocumentControlContentCornerRadius` and `DocumentControlContentBorderThickness`, so the ReactiveUI sample starts without the previous `InvalidCastException`.
- Updated the ReactiveUI sample to reference both `CodeWF.AvaloniaControls.Dock` and `CodeWF.AvaloniaControls.Dock.Themes`.
- Updated the sample version display, central package versions, README files, and package audit notes for Avalonia `12.0.3`.
- Updated `pack.bat` so it packs both the controls package and the theme package into `artifacts/packages`.

## 12.0.2 (2026-05-08)

- Migrated `CodeWF.AvaloniaControls.Dock` and its Dock sample applications into this standalone repository.
- Added the Dock-only solution, central package versions, packing script, and sample publish script.
- Updated `CodeWF.AvaloniaControls.DockReactiveUIDemo` to avoid referencing the main control source project.
- Updated demo document pages to use cards, timelines, and status panels instead of directly embedding the old DataGrid sample path.
- Removed the old free grid control path from the ordinary Dock sample flow to keep the Avalonia 12 sample stable.
- Polished Chinese UI text in the sample pages.
