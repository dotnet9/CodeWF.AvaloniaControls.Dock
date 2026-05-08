# CodeWF.AvaloniaControls.Dock

| 名称 | NuGet | 下载量 |
|------|-------|--------|
| CodeWF.AvaloniaControls.Dock | [![NuGet](https://img.shields.io/nuget/v/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) | [![NuGet](https://img.shields.io/nuget/dt/CodeWF.AvaloniaControls.Dock.svg)](https://www.nuget.org/packages/CodeWF.AvaloniaControls.Dock/) |

这是 `CodeWF.AvaloniaControls.Dock` 的独立仓库，用于维护 Avalonia 12 下的 Dock 扩展控件、Semi 主题样式和对应示例工程。

[English](README.md) | 简体中文

## 安装

```powershell
Install-Package CodeWF.AvaloniaControls.Dock
```

## 仓库结构

- `src/CodeWF.AvaloniaControls.Dock`：可复用的 Dock 样式与控件扩展
- `src/CodeWF.AvaloniaControls.DockDemo`：基础 Dock 示例
- `src/CodeWF.AvaloniaControls.DockPrismDemo`：Prism 容器集成示例
- `src/CodeWF.AvaloniaControls.DockReactiveUIDemo`：ReactiveUI 示例，包含嵌套 Dock 与内嵌进程文档
- `CodeWF.AvaloniaControls.Dock.slnx`：Dock 类库和示例的解决方案视图

## 脚本

- `pack.bat`：还原、构建并打包 `CodeWF.AvaloniaControls.Dock` 到 `artifacts/packages`
- `publish_all.bat`：发布所有 Dock 示例工程到 `publish/`
- `publishbase.bat`：示例发布脚本共用的辅助脚本

## 说明

- `CodeWF.AvaloniaControls.DockReactiveUIDemo` 已改为通过 NuGet 引用 `CodeWF.AvaloniaControls.Themes` `12.0.2.1`，不再引用主仓库的 `CodeWF.AvaloniaControls` 源码项目。
- `Prism.DryIoc.Avalonia` 固定使用 `8.1.97.11073`，因为 `9.x` 已转为商业版。
