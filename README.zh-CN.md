# CodeWF.AvaloniaControls.Dock

| 名称 | NuGet | 下载量 |
|------|-------|--------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |
| CodeWF.AvaloniaControls.Dock.Themes | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.Themes.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock.Themes/) |

这是 `CodeWF.AvaloniaControls.Dock` 的独立仓库，用于维护 Avalonia 12 下的 Dock 扩展控件和基于开源 Fluent 的 Dock 主题资源。

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
    xmlns:fluent="clr-namespace:Avalonia.Themes.Fluent;assembly=Avalonia.Themes.Fluent">
  <Application.Styles>
    <fluent:FluentTheme />
    <codewf:DockCodeWFTheme />
  </Application.Styles>
</Application>
```

`DockCodeWFTheme` 会加载开源的 `Dock.Avalonia.Themes.Fluent` 主题，并叠加 CodeWF 对 Dock Tool 标题栏按钮和标题可见性的增强。升级到 `12.0.3.3` 后，请移除旧的 `DockSemiTheme` 配置项。

## 仓库结构

- `src/CodeWF.AvaloniaControls.Dock`：可复用的 Dock 控件扩展
- `src/CodeWF.AvaloniaControls.Dock.Themes`：独立 Fluent Dock 主题包
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`：ReactiveUI 示例，包含嵌套 Dock 与内嵌进程文档
- `CodeWF.AvaloniaControls.Dock.slnx`：Dock 类库、主题包和示例的解决方案视图

## 脚本

- `pack.bat`：还原、构建并打包 `CodeWF.AvaloniaControls.Dock` 和 `CodeWF.AvaloniaControls.Dock.Themes` 到 `artifacts/packages`
- `publish_all.bat`：发布所有 Dock 示例工程到 `publish/`
- `publishbase.bat`：示例发布脚本共用的辅助脚本

## 说明

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` 现在直接使用 Avalonia Fluent，不再引用额外的应用主题包。
- `Prism.DryIoc.Avalonia` 固定使用 `8.1.97.11073`，因为 `9.x` 已转为商业版。
- 控件包、主题包和示例工程当前恢复资产中不包含 `Semi.Avalonia` 或 Ursa 相关包。

## 第三方开源组件审计

检查时间：2026-05-20。检查范围包括 NuGet 元数据、恢复后的 `project.assets.json`、包 nuspec 文件以及上游源码/许可证链接。优先接受 MIT / Apache-2.0 / BSD。源码开放但不是优先协议的组件，需要单独确认后再使用。

本次整改：

- 移除旧 Dock 主题路径，改为基于开源 `Dock.Avalonia.Themes.Fluent`。
- 将 `DockCodeWFTheme` 改为加载 Fluent 与 CodeWF Tool 标题栏可见性增强。
- 示例工程移除对 `CodeWF.AvaloniaControls.Themes`、`Semi.Avalonia`、Ursa 主题包的直接和间接依赖。
- 移除依赖非 Fluent 主题键的自维护 Dock XAML 资源。

| 包/依赖族 | 协议 | 源码/项目地址 | 结论 |
| --- | --- | --- | --- |
| `Avalonia`、`Avalonia.Desktop`、`Avalonia.Fonts.Inter`、`Avalonia.Themes.Fluent`、`Avalonia.*` 原生/平台包 | MIT | https://github.com/AvaloniaUI/Avalonia | 通过 |
| `CodeWF.AvaloniaControls.Dock`、`CodeWF.AvaloniaControls.Dock.Themes` | MIT | https://github.com/dotnet9/CodeWF.AvaloniaControls.Dock | 自研开源包 |
| `CodeWF.EventBus`、`CodeWF.Log.Core` | MIT | CodeWF 仓库 | 自研开源包 |
| `Dock.Avalonia`、`Dock.Avalonia.Themes.Fluent`、`Dock.Model.ReactiveUI`、`Dock.Controls.*`、`Dock.Model`、`Dock.Settings` | MIT | https://github.com/wieslawsoltes/Dock | 通过 |
| `DryIoc.dll` | MIT | https://github.com/dadhi/DryIoc | 通过 |
| `DynamicData`、`ReactiveUI`、`Splat`、`System.Reactive` | MIT | https://github.com/reactiveui | 通过 |
| `HarfBuzzSharp`、`SkiaSharp` 及原生资产包 | MIT | https://github.com/mono/SkiaSharp | 通过 |
| `MicroCom.Runtime` | MIT | https://github.com/AvaloniaUI/MicroCom | 通过 |
| `Prism.DryIoc.Avalonia`、`Prism.Avalonia`、`Prism.Core` | MIT | https://github.com/AvaloniaCommunity/Prism.Avalonia | 通过，保留 8.x 开源线 |
| `StaticViewLocator` | MIT | https://github.com/wieslawsoltes/StaticViewLocator | 通过 |
| `System.*` 运行时扩展包 | MIT | https://github.com/dotnet/dotnet | 通过 |
| `Tmds.DBus.Protocol` | MIT | https://github.com/tmds/Tmds.DBus | 通过 |
| `VC-LTL` | EPL-2.0 | https://github.com/Chuyu-Team/VC-LTL5 | 源码开放，按可追溯源码的非优先协议规则通过 |
| `Xaml.Behaviors` | MIT | https://github.com/wieslawsoltes/Xaml.Behaviors | 通过 |
| `YY-Thunks` | MIT | https://github.com/Chuyu-Team/YY-Thunks | 通过 |

传递依赖检查结论：当前有效恢复资产均能追溯到开放源码和明确许可证；没有使用闭源或黑盒 Dock 主题包。
