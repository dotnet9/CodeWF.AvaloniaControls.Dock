# CodeWF.AvaloniaControls.Dock

| 名称 | NuGet | 下载量 |
|------|-------|--------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |
| CodeWF.AvaloniaControls.Dock.Themes | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) |

面向 Avalonia 12 的 Dock 扩展控件与主题资源。本仓库将可复用的 Dock 控件和 Dock 主题包拆分维护，应用可以按需只引用需要的部分。

## 仓库规范

- 当前版本：`12.0.4.12`，版本号统一维护在根目录 `Directory.Build.props` 的 `<Version>` 节点。
- NuGet 包项目统一支持 `net8.0;net10.0`；Demo、App、测试与内部应用项目统一使用 `net11.0` / `net11.0-windows`。
- 根目录 `logo.svg`、`logo.png`、`logo.ico` 是唯一图标源，子工程只通过 MSBuild `Link` 引用，不维护图标副本。
- 运行时帮助、Markdown 示例、内置备忘录、设计说明等业务文档按功能保留；仓库级入口文档使用根目录 `README.md` 和 `UpdateLog.md`。

## 安装

```powershell
Install-Package CodeWF.AvaloniaControls.Dock
Install-Package CodeWF.AvaloniaControls.Dock.Themes
```

如果应用本身还没有引用 Semi，也需要添加 `Semi.Avalonia`，因为 CodeWF 的 Tool 标题栏会复用 Semi 色彩资源。

```powershell
Install-Package Semi.Avalonia
```

## 主题配置

```xml
<Application
    xmlns:codewf="https://codewf.com"
    xmlns:fluent="clr-namespace:Avalonia.Themes.Fluent;assembly=Avalonia.Themes.Fluent"
    xmlns:semi="https://irihi.tech/semi">
  <Application.Styles>
    <fluent:FluentTheme />
    <semi:SemiTheme Locale="zh-CN" />
    <codewf:DockSemiTheme />
  </Application.Styles>
</Application>
```

`DockSemiTheme` 会加载开源的 `Dock.Avalonia.Themes.Fluent` Dock 主题，并应用 CodeWF 对 Tool chrome 按钮和 Tool 标题栏的细节调整。请保留 `FluentTheme`，用于 Dock 基础布局样式链；同时在 `DockSemiTheme` 之前加载 `SemiTheme`，保证 `SemiColorText0`、`SemiColorFill0`、`SemiColorBorder` 等 Semi 资源键可用。

从旧配置升级时，请将 `DockCodeWFTheme` 替换为 `DockSemiTheme`。本主题包不依赖非开源的 `Semi.Avalonia.Dock` 包。

## Tool 标题栏

`DockSemiTheme` 提供 `CodeWFToolChromeControlTheme`，用于需要紧凑商务风格标题栏的 Tool 面板。默认标题左对齐，使用中性色文本，不使用彩色激活标题样式，并将关闭按钮保持在右侧。

应用可以覆盖 `CodeWFToolTitleTabHeaderTemplate` 来提供 Tool 专用标题图标，也可以覆盖 `CodeWFToolTitleBarContentTemplate` 来提供右侧标题栏内容。应用专用图标和操作应留在应用层；Dock 包只提供共享的标题栏结构和资源。

代码式创建 Dock 布局时，每个独立 `Factory` 都需要按 Dock 官方示例配置 `HostWindowLocator`，或者由对应 `DockControl` 启用 `InitializeFactory`。嵌套 Dock 使用自己的 Factory 时不能复用外层 Factory 的窗口定位器，否则 Tool/Document 会移出原布局，但无法显示浮动窗体。

## 仓库结构

- `src/CodeWF.AvaloniaControls.Dock`：可复用的 Dock 控件扩展
- `src/CodeWF.AvaloniaControls.Dock.Themes`：独立的 Fluent 基础 Dock 主题包，复用 Semi 色彩资源键
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`：包含嵌套 Dock 与进程嵌入说明的 ReactiveUI 示例
- `CodeWF.AvaloniaControls.Dock.slnx`：Dock 库、主题包和示例项目的解决方案视图

## 脚本

- `pack.bat`：还原、构建并打包 `CodeWF.AvaloniaControls.Dock` 和 `CodeWF.AvaloniaControls.Dock.Themes` 到 `artifacts/packages`
- `publish_all.bat`：将所有 Dock 示例应用发布到 `publish/`
- `publishbase.bat`：示例发布脚本使用的共享发布辅助脚本

## 说明

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` 保留 `Avalonia.Themes.Fluent` 作为基础样式和布局链，然后加载 `SemiTheme`，使 Dock 标题栏资源可以复用 Semi 色彩令牌。
- `Prism.DryIoc.Avalonia` 固定在 `8.1.97.11073`，因为 `9.x` 分支是商业版本。
- 控件包不依赖 Semi。主题包只引用 MIT 许可的 `Semi.Avalonia` 包来共享色彩资源，不包含 `Semi.Avalonia.Dock` 或 Ursa 依赖。
- NuGet 包包含根目录下的简单 logo 资源：`logo.png`、`logo.svg` 和 `logo.ico`。

## 第三方开源审计

2026-06-02 根据 NuGet 元数据、还原后的 `project.assets.json`、包 nuspec 文件以及上游源码和许可证链接完成检查。优先采用 MIT、Apache-2.0、BSD 许可证。源码可见但不属于优先许可证的依赖，在使用前必须复审。

整改内容：

- 移除原有 Dock 主题路径，改为使用开源的 `Dock.Avalonia.Themes.Fluent` 主题。
- 将 `DockSemiTheme` 接入 Fluent Dock 资源，并叠加 CodeWF Tool chrome 细节调整。
- 复用开源 Semi 色彩资源，用于 CodeWF Tool 标题栏，不使用非开源的 `Semi.Avalonia.Dock` 包。
- 移除依赖非 Fluent 主题键的自维护 Dock XAML 资源。

| 包 / 家族 | 许可证 | 源码 | 状态 |
| --- | --- | --- | --- |
| `Avalonia`, `Avalonia.Desktop`, `Avalonia.Fonts.Inter`, `Avalonia.Themes.Fluent`, `Avalonia.*` 原生 / 平台包 | MIT | https://github.com/AvaloniaUI/Avalonia | 已批准 |
| `CodeWF.AvaloniaControls.Dock`, `CodeWF.AvaloniaControls.Dock.Themes` | MIT | https://github.com/dotnet9/CodeWF.AvaloniaControls.Dock | 自有开源包 |
| `CodeWF.EventBus`, `CodeWF.Log.Core` | MIT | CodeWF 仓库 | 自有开源包 |
| `Dock.Avalonia`, `Dock.Avalonia.Themes.Fluent`, `Dock.Model.ReactiveUI`, `Dock.Controls.*`, `Dock.Model`, `Dock.Settings` | MIT | https://github.com/wieslawsoltes/Dock | 已批准 |
| `DryIoc.dll` | MIT | https://github.com/dadhi/DryIoc | 已批准 |
| `DynamicData`, `ReactiveUI`, `Splat`, `System.Reactive` | MIT | https://github.com/reactiveui | 已批准 |
| `HarfBuzzSharp`, `SkiaSharp` 与原生资源 | MIT | https://github.com/mono/SkiaSharp | 已批准 |
| `MicroCom.Runtime` | MIT | https://github.com/AvaloniaUI/MicroCom | 已批准 |
| `Prism.DryIoc.Avalonia`, `Prism.Avalonia`, `Prism.Core` | MIT | https://github.com/AvaloniaCommunity/Prism.Avalonia | 已批准，固定在 8.x |
| `Semi.Avalonia` | MIT | https://github.com/irihitech/Semi.Avalonia | 已批准；用于开源主题资源和色彩令牌 |
| `StaticViewLocator` | MIT | https://github.com/wieslawsoltes/StaticViewLocator | 已批准 |
| `System.*` 运行时扩展包 | MIT | https://github.com/dotnet/dotnet | 已批准 |
| `Tmds.DBus.Protocol` | MIT | https://github.com/tmds/Tmds.DBus | 已批准 |
| `VC-LTL` | EPL-2.0 | https://github.com/Chuyu-Team/VC-LTL5 | 源码可见；已按源码可追溯的非优先许可证规则批准 |
| `Xaml.Behaviors` | MIT | https://github.com/wieslawsoltes/Xaml.Behaviors | 已批准 |
| `YY-Thunks` | MIT | https://github.com/Chuyu-Team/YY-Thunks | 已批准 |

传递依赖检查结果：当前还原的依赖资源均源码可见且许可证可追溯。未使用闭源或黑盒 Dock 主题包。
## 包版本维护约定

XML 文件统一使用两个空格缩进。`Directory.Packages.props` 统一承载 NuGet 中央包管理开关和包版本变量，包括 `AvaloniaVersion` 等共享版本属性；`Directory.Build.props` 仅保留项目构建、编译选项和 NuGet 元数据。仓库如引用 `VC-LTL`、`YY-Thunks`，这两个兼容旧版操作系统的特殊包必须使用最新预览版。
