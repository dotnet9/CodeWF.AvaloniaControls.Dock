# 变更日志

## 12.1.0.5 (2026-07-24)

- 统一 Document 与 Tool 的白色工作区 Header、面板背景、边框、圆角和尺寸语义，减少大面积灰色与多重蓝色激活外框。
- 新增可由应用覆盖的 `CodeWFDock*` 工作区资源，移除 Tool 与 Document 容器中的圆角和边框厚度硬编码。
- Document 标签使用局部主色下划线表达激活状态，并统一标题字重、关闭按钮尺寸和悬停反馈。
- Proportional Dock 分隔器使用工作台底色，形成清晰的卡片间隙，悬停时保留可调整提示。
- 固定水平 Document Header 的测量高度，避免标签栏占满文档区并导致正文不可见；Document 与 Tool 的视觉总高度统一为 28px。
- Tool Header 仅保留下边框，不再在标题文字下重复绘制激活下划线。

## 12.1.0.4 (2026-07-16)

- `DockSemiTheme` 新增 `Locale` 属性，统一管理 Dock 拖放提示、Document 标签菜单和 Tool 菜单语言。
- 内置 `en-US` 和 `zh-CN` 资源；未指定或无法识别语言时回退到 `en-US`，应用只需在主题入口声明语言。

## 12.1.0.3 (2026-07-16)

- 修复 Avalonia 12.1 下 Tool 标题栏关闭按钮无法执行 `IFactory.CloseDockable(IDockable)` 的问题，改用显式命令适配器。
- 恢复 Tool 标题栏的固定/自动隐藏按钮，并通过原生 `IFactory.PinDockable(IDockable)` 切换状态。
- Tool 与 Document 增加跟随 Semi 主题的活动/非活动外边框，活动状态使用主题主色强调。
- Tool 固定、Tool 关闭和 Document 关闭按钮增加跟随当前主题的操作提示，并完整遵守 Dock 能力策略。

## 12.0.4.12 (2026-06-08)

- 🔨[优化]-补齐根目录 logo.svg、logo.png、logo.ico 三件套，子工程通过 MSBuild Link 引用根 logo，避免维护多份图标副本。
- 🔨[优化]-统一目标框架：NuGet 包项目支持 `net8.0;net10.0`，Demo、App、测试与内部应用项目升级到 `net11.0` / `net11.0-windows`。
- 🔨[优化]-保留运行时帮助、Markdown 示例、内置备忘录和业务设计文档，仅收敛仓库级重复文档入口。

## 12.0.4.11 (2026-06-08)

- 统一版本号维护入口，只在仓库根目录 `Directory.Build.props` 中定义 `<Version>`。
- 清理英文/双语文档入口，后续仅维护简体中文文档。
- 完善 NuGet 发布配置，补充 Source Link、符号包和标签格式规范。


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
## 2026-06-08 仓库规范整理

- 统一文档维护入口：每个仓库只保留根目录 `README.md` 和根目录 `UpdateLog.md`，清理重复日志、英文文档和语言切换入口。
- 统一版本维护入口：包版本只在仓库根目录 `Directory.Build.props` 的 `<Version>` 节点维护，移除散落的程序集版本配置。
- 不再维护 `global.json`，SDK 选择交给本机或 CI 环境；NuGet 包和应用的目标框架在项目文件中明确声明。
- 统一 NuGet 包文档入口：包 README 统一引用仓库根 `README.md`，更新日志统一引用仓库根 `UpdateLog.md`。
