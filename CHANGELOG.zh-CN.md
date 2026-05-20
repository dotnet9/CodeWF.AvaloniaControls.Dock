# 更新日志

[English](CHANGELOG.md) | 简体中文

## 12.0.3.3（2026-05-20）

- 将 `CodeWF.AvaloniaControls.Dock.Themes` 重构为只以开源 Fluent Dock 主题作为 Dock 主题底座。
- 新增 `DockFluentTheme`，并将 `DockCodeWFTheme` 改为加载 Fluent 与 CodeWF Tool 标题栏可见性增强。
- 移除旧 Dock 主题入口，以及依赖非 Fluent 主题键的自维护 XAML 资源。
- 提升 Tool 标题、菜单、固定和关闭按钮的对比度，使浅色工作区中的 Tool 面板始终清晰可见。
- ReactiveUI 示例改为直接使用 Avalonia Fluent，并移除额外应用主题包带来的间接依赖。
- 更新开源审计说明与版本号到 `12.0.3.3`。

## 12.0.3.2（2026-05-20）

- 新增 `CodeWF.AvaloniaControls.Dock.Themes` 独立主题包，用于承载 Dock XAML 样式资源。
- 将 `DockCodeWFTheme` 和 Dock 文档控件样式从主控件包迁移到主题包。
- `CodeWF.AvaloniaControls.Dock` 移除 `Dock.Avalonia.Themes.Fluent` 依赖，该依赖现在只由主题包承担。
- 补齐 `DocumentControlContentCornerRadius`、`DocumentControlContentBorderThickness` 等文档控件资源，修复 ReactiveUI 示例启动时的 `InvalidCastException`。
- ReactiveUI 示例改为同时引用 `CodeWF.AvaloniaControls.Dock` 与 `CodeWF.AvaloniaControls.Dock.Themes`，验证控件包和主题包拆分后的加载链路。
- 示例版本展示、中央包版本、README 和开源审计说明同步到 Avalonia `12.0.3`。
- 更新 `pack.bat`，一次性打包控件包和主题包到 `artifacts/packages`。

## 12.0.2（2026-05-08）

- 将 `CodeWF.AvaloniaControls.Dock` 和 Dock 示例应用迁移到独立仓库。
- 新增 Dock 专用解决方案、中央包版本管理、打包脚本和示例发布脚本。
- `CodeWF.AvaloniaControls.DockReactiveUIDemo` 不再引用主控件源码项目。
- 将数据管理与日志记录文档页改为卡片、时间线和状态面板，不再直接嵌入旧 DataGrid 示例链路。
- 移除普通 Dock 示例对旧版免费表格控件链路的直接依赖，避免影响 Avalonia 12 主线运行与展示。
- 补齐并修正相关页面的中文界面文案，提升开源示例的可读性与专业观感。
