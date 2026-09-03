# Demo 界面原型

基于 `src/CodeWF.AvaloniaControls.DockReactiveUIDemo` 现有界面与功能整理的静态原型，仅用于展示布局结构与控件用法，不包含真实停靠交互。

## 查看方式

直接用浏览器打开 `index.html` 即可，无任何外部依赖；点击页签切换文档，也支持 `index.html#p-data` 这类锚点直达指定页签。整体效果见 `preview.png`。

## 原型与 Demo 的对应关系

| 原型区域 | Demo 实现 |
| --- | --- |
| 顶部蓝色标题栏（logo、标题、已连接状态、工作区菜单） | `MainWindow.axaml` + `TitleBarRightContentView.axaml` |
| “运维工作台”信息条（标签、在线节点等统计） | `MainWindow.axaml` 仪表卡片区 |
| 文档页签（总览看板 / 数据管理 / 系统设置 / 用户中心 / 日志记录 / 帮助文档） | `DocumentDock`，页签切换对应 `ActiveDockable`，× 对应关闭文档，菜单项可重新打开 |
| 总览看板内左 70% / 右 30% 嵌套工具区 | `HomeDockFactory` 的 `ProportionalDock` + `ToolDock` 嵌套布局，工具标题栏对应 `CodeWFToolChromeControlTheme`（标题左对齐 + 固定/关闭按钮） |
| 工具内容（实时参数、进程视图、运行状态、最新告警、系统信息、活动日志） | 对应 `Views/Documents/Homes/Tools/*` 六个 Tool 视图 |
| 帮助文档中的“进程嵌入区域” | `ProcessEmbedHost` 外部进程嵌入宿主（原型以占位框表达） |
| 重置嵌套布局按钮 | `HomeViewModel.NewLayout`（重建嵌套 Dock 布局） |

## 说明

- 配色与 Demo 保持一致：页面底 `#EEF2F6`、主色 `#2563EB`、边框 `#D5DBE5`，状态色（绿 `#1E6B3B`、琥珀 `#8A5A00`、红 `#B4232C`、蓝 `#24558F`）。
- 页签切换用少量原生 JS 模拟 `DockControl` 的活动文档切换；工作区菜单用 `<details>` 实现，无其他脚本。
- 不在原型范围内：工具拖拽停靠、浮动 `HostWindow`、页签关闭后的恢复联动、分隔条拖动调宽、真实进程嵌入。
