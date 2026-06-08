# 变更日志

## 12.0.4.9 (2026-06-08)

- 规范主题入口命名，将主题类型和 XAML 文件统一为 `DockSemiTheme`。
- 更新 ReactiveUI 示例应用的主题配置，使用 `<codewf:DockSemiTheme />`。
- 将项目版本更新到 `12.0.4.9`，并更新 Avalonia / ReactiveUI.Avalonia 相关 12.0.x 版本。
- 将根目录 Markdown 文档改为中文单份维护。

## 12.0.4.4 (2026-06-02)

- 将 CodeWF Tool 标题栏调整为紧凑的商务风格布局，标题左对齐并收紧间距。
- 移除彩色激活标题样式和蓝色激活指示条；激活 Tool 标题现在使用中性的 Semi 文本和边框资源。
- 复用 Semi 资源键作为 Tool 标题栏画刷，包括 `SemiColorText0`、`SemiColorText2`、`SemiColorFill0`、`SemiColorFill1`、`SemiColorFill2`、`SemiColorBackground0` 和 `SemiColorBorder`。
- 保留 `CodeWFToolTitleTabHeaderTemplate` 和 `CodeWFToolTitleBarContentTemplate`，作为 Tool 专用图标和标题栏操作的应用扩展点。
- 添加简单的根目录 logo 资源：`logo.svg`、`logo.png` 和 `logo.ico`。
- 更新两个 NuGet 包，使其包含 `logo.png`、`logo.svg` 和 `logo.ico`。
- 移除早期单独维护的简体中文 README 和变更日志文件，文档改为单份维护。
- 更新包元数据、README、开源审计说明和示例应用主题配置，使 Fluent 保持在 Dock 样式链中，同时复用 Semi 资源键。

## 12.0.3.4 (2026-05-20)

- 在 `DockCodeWFTheme` 下添加 `CodeWFToolChromeControlTheme` 资源，用于需要商务风格标题栏的 Tool 面板：激活 Tool 标题位于左侧，可选自定义标题栏内容，右侧只保留关闭按钮。
- 保持 `DockCodeWFTheme` 作为单一主题入口；应用可以通过将该资源应用到 `ToolChromeControl` 来启用。

## 12.0.3.3 (2026-05-20)

- 重构 `CodeWF.AvaloniaControls.Dock.Themes`，将开源 Fluent Dock 主题作为唯一的 Dock 主题基础。
- 将 `DockCodeWFTheme` 改为加载 Fluent 资源，并叠加 CodeWF Tool chrome 可见性细节调整。
- 移除旧的 Dock 主题入口，以及依赖非 Fluent 主题键的自维护 XAML 资源。
- 改进 Tool chrome 标题、菜单、固定和关闭按钮的对比度，使 Tool 面板在浅色工作区中保持可读。
- 更新 ReactiveUI 示例，直接使用 Avalonia Fluent，并移除示例对额外应用主题包的间接依赖。
- 更新包审计说明，并将版本更新为 `12.0.3.3`。

## 12.0.3.2 (2026-05-20)

- 添加独立主题包 `CodeWF.AvaloniaControls.Dock.Themes`，用于 Dock XAML 资源。
- 将 `DockCodeWFTheme` 和 Dock 文档控件样式从主控件包中移出。
- 从 `CodeWF.AvaloniaControls.Dock` 移除 `Dock.Avalonia.Themes.Fluent` 依赖；该依赖现在只存在于主题包中。
- 补齐缺失的文档控件资源，包括 `DocumentControlContentCornerRadius` 和 `DocumentControlContentBorderThickness`，使 ReactiveUI 示例启动时不再出现之前的 `InvalidCastException`。
- 更新 ReactiveUI 示例，使其同时引用 `CodeWF.AvaloniaControls.Dock` 和 `CodeWF.AvaloniaControls.Dock.Themes`。
- 更新示例版本显示、中央包版本、README 文件和 Avalonia `12.0.3` 的包审计说明。
- 更新 `pack.bat`，使其同时将控件包和主题包打包到 `artifacts/packages`。

## 12.0.2 (2026-05-08)

- 将 `CodeWF.AvaloniaControls.Dock` 及其 Dock 示例应用迁移到当前独立仓库。
- 添加 Dock 专用解决方案、中央包版本、打包脚本和示例发布脚本。
- 更新 `CodeWF.AvaloniaControls.DockReactiveUIDemo`，避免引用主控件源码项目。
- 更新示例文档页面，改用卡片、时间线和状态面板，不再直接嵌入旧的 DataGrid 示例路径。
- 从普通 Dock 示例流程中移除旧的免费网格控件路径，保持 Avalonia 12 示例稳定。
- 润色示例页面中的中文 UI 文案。
