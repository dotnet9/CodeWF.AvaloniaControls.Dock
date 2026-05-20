# CodeWF.AvaloniaControls.Dock

| 名称 | NuGet | 下载量 |
|------|-------|--------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |
| CodeWF.AvaloniaControls.Dock.Themes | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) |

这是 `CodeWF.AvaloniaControls.Dock` 的独立仓库，用于维护 Avalonia 12 下的 Dock 扩展控件、独立 Semi 风格主题资源和对应示例工程。

[English](README.md) | 简体中文

## 安装

```powershell
Install-Package CodeWF.AvaloniaControls.Dock
Install-Package CodeWF.AvaloniaControls.Dock.Themes
```

## 主题配置

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

`CodeWF.AvaloniaControls.Dock` 只保留可复用 Dock 控件和转换器。`CodeWF.AvaloniaControls.Dock.Themes` 独立承载 Dock 主题入口和所有 Dock XAML 样式资源。

## 仓库结构

- `src/CodeWF.AvaloniaControls.Dock`：可复用的 Dock 控件扩展
- `src/CodeWF.AvaloniaControls.Dock.Themes`：独立 Dock 主题包和 Semi 风格样式资源
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`：ReactiveUI 示例，包含嵌套 Dock 与内嵌进程文档
- `CodeWF.AvaloniaControls.Dock.slnx`：Dock 类库、主题包和示例的解决方案视图

## 脚本

- `pack.bat`：还原、构建并打包 `CodeWF.AvaloniaControls.Dock` 和 `CodeWF.AvaloniaControls.Dock.Themes` 到 `artifacts/packages`
- `publish_all.bat`：发布所有 Dock 示例工程到 `publish/`
- `publishbase.bat`：示例发布脚本共用的辅助脚本

## 说明

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` 已改为通过 NuGet 引用 `CodeWF.AvaloniaControls.Themes` `12.0.3.3`，不再引用主仓库的 `CodeWF.AvaloniaControls` 源码项目。
- `Prism.DryIoc.Avalonia` 固定使用 `8.1.97.11073`，因为 `9.x` 已转为商业版。
- 不再引用 `Semi.Avalonia.Dock`。Dock 专用的 Semi 风格资源由 `CodeWF.AvaloniaControls.Dock.Themes` 自研维护。

## 第三方开源组件审计

检查时间：2026-05-20。检查范围包括 NuGet 元数据、恢复后的 `project.assets.json`、NuGet.org 信息以及上游源码/许可证链接。优先接受 MIT / Apache-2.0 / BSD。源码开放但不是优先协议的组件，需要单独确认后再使用。

本次整改：

- 移除 `Semi.Avalonia.Dock`；该包只提供 Dock 的 Semi 主题，未找到公开源码仓库。
- 拆分 Dock 控件包和主题包。`CodeWF.AvaloniaControls.Dock` 不再引用 `Dock.Avalonia.Themes.Fluent`，只有 `CodeWF.AvaloniaControls.Dock.Themes` 引用开源的 Fluent Dock 主题包。
- 新增 `CodeWF.AvaloniaControls.Dock.Themes`，内部维护 Semi 风格 XAML 资源，样式参考并调整自 `E:\github\company\xskj\src\Semi.Avalonia.Dock` 的旧版源码快照。
- 示例工程移除 `AvaloniaUI.DiagnosticsSupport`，因为该包未公开明确的开源许可证和源码仓库。

| 包 | 协议 | 源码/项目地址 | 结论 |
| --- | --- | --- | --- |
| `Avalonia` / `Avalonia.Desktop` / `Avalonia.Fonts.Inter` / `Avalonia.Themes.Fluent` | MIT | https://github.com/AvaloniaUI/Avalonia | 通过 |
| `CodeWF.AvaloniaControls.Dock` / `CodeWF.AvaloniaControls.Dock.Themes` | MIT | https://github.com/dotnet9/CodeWF.AvaloniaControls.Dock | 自研开源包 |
| `CodeWF.AvaloniaControls.Themes` / `CodeWF.EventBus` / `CodeWF.Log.Core` | MIT | CodeWF 仓库 | 自研开源包 |
| `Dock.Avalonia` / `Dock.Avalonia.Themes.Fluent` / `Dock.Model.ReactiveUI` | MIT | https://github.com/wieslawsoltes/Dock | 通过 |
| `Irihi.Ursa.Themes.Semi` | MIT | https://github.com/irihitech/Ursa.Avalonia | 通过 |
| `Prism.DryIoc.Avalonia` `8.1.97.11073` | MIT | https://github.com/AvaloniaCommunity/Prism.Avalonia | 通过，保留 8.x 开源线 |
| `ReactiveUI.Avalonia` | MIT | https://github.com/reactiveui/reactiveui | 通过 |
| `Semi.Avalonia` | MIT | https://github.com/irihitech/Semi.Avalonia | 通过，仅使用开源主体包 |
| `StaticViewLocator` | MIT | https://github.com/wieslawsoltes/StaticViewLocator | 通过 |
| `System.Drawing.Common` / `System.Security.Permissions` / `System.Windows.Extensions` | MIT | https://github.com/dotnet/dotnet | 通过，固定到 `10.0.8` |
| `VC-LTL` | EPL-2.0 | https://github.com/Chuyu-Team/VC-LTL5 | 源码开放，按可追溯源码的非优先协议规则通过 |
| `Xaml.Behaviors` | MIT | https://github.com/wieslawsoltes/Xaml.Behaviors | 通过 |
| `YY-Thunks` | MIT | https://github.com/Chuyu-Team/YY-Thunks | 通过 |

传递依赖检查结论：Dock、Avalonia、ReactiveUI、Prism.Avalonia、Semi.Avalonia、Ursa.Avalonia 与 SkiaSharp 链路均有公开源码，许可证为 MIT 或 BSD-style。有效恢复资产中不再包含 `Semi.Avalonia.Dock`。
