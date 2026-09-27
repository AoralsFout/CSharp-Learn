# C# 学习环境

> 📘 知识点梳理见 **[SUMMARY.md](SUMMARY.md)**（覆盖 V001–V036）。
> 本文件讲环境怎么搭、代码怎么跑、项目怎么组织。

## 一、环境现状（2026-09-26 检查）

| 组件 | 状态 | 说明 |
|---|---|---|
| .NET SDK 10.0.401 | ✅ 已装 | 编译靠它 |
| .NET 运行时 10.0.12 / 10.0.11 / 6.0.36 | ✅ 已装 | 运行靠它 |
| ASP.NET Core 运行时 10.0.12 | ✅ 已装 | 以后写 Web 用 |
| VS Code | ✅ `D:\Program Files\Microsoft VS Code` | 写代码用 |
| winget | ✅ 可用 | 装 SDK 用 |
| 旧版 csc.exe (.NET Framework 4.x) | ✅ 存在 | 只能写老语法，别用 |

**环境已就绪，`dotnet build` / `dotnet run` 均可正常工作。**

## 二、安装 .NET SDK 10（2026-09-26 已完成）

以管理员身份打开 PowerShell，执行：

```powershell
winget install Microsoft.DotNet.SDK.10
```

装完**重开一个终端**，验证：

```powershell
dotnet --list-sdks      # 10.0.401
```

> 为什么选 10 而不是 9：.NET 10 是 LTS（长期支持版），.NET 9 已经停止支持。

## 三、编译和运行

当前目录结构：

```
F:\Learn\C#\
├── README.md                ← 本文件
└── Learn\
    ├── Learn.csproj         ← 项目文件：告诉编译器怎么编译
    ├── Program.cs           ← 唯一的入口点
    └── Lessons\             ← 各个练习（结构见第四节）
```

### 方式 1：`dotnet run`（日常开发最常用）

```powershell
cd F:\Learn\C#\Learn
dotnet run
```

输出（先出菜单，输编号回车）：

```
═══ C# 练习清单 ═══
  1. 001 Hello World（顶级语句）
  2. 002 Hello World（传统写法）
  3. 003 数据类型
  0. 全部跑一遍
  q. 退出
选择：1

───── 001 Hello World（顶级语句） ─────
Hello, World!
```

`dotnet run` 一步完成「编译 + 运行」。第一次跑会稍慢（要还原依赖、编译）。

> `dotnet run` 后面加 `--` 才能把参数传给你的程序：
> `dotnet run -- 3` 直接跑第 3 个，跳过菜单。

### 方式 2：`dotnet build` 再单独运行

想看清「编译」和「运行」是两件事，用这个：

```powershell
cd F:\Learn\C#\Learn
dotnet build                    # 编译

# 编译产物在这里：
# bin\Debug\net10.0\Learn.dll   ← 你的程序
# bin\Debug\net10.0\Learn.exe   ← Windows 启动器

.\bin\Debug\net10.0\Learn.exe   # 运行
```

也可以直接：

```powershell
dotnet .\bin\Debug\net10.0\Learn.dll
```

> 重点理解：**C# 编译出来的是 .NET 程序集（.dll），不是原生机器码。**
> 运行时由 dotnet 虚拟机把中间语言（IL）翻译成机器码执行。`.exe` 只是个启动器外壳。

### 方式 3：Release 发布

```powershell
dotnet build -c Release
dotnet publish -c Release
```

`Debug` 带调试符号、不优化；`Release` 做了优化，是给别人用的版本。

## 四、练习项目 Learn 的结构（2026-09-27 重构）

`Learn\` 是写练习的地方，用「一个项目 + 菜单分发」组织：

```
F:\Learn\C#\Learn\
├── Learn.csproj
├── Program.cs                     ← 唯一入口点：出菜单、分发
└── Lessons\
    ├── ILesson.cs                 ← 约定：有 Title 和 Run()
    ├── V001_HelloWorld.cs
    ├── V002_HelloWorldWithClass.cs
    └── V003_DataType.cs
```

每个练习是一个类，实现 `ILesson`：

```csharp
public class V003_DataType : ILesson
{
    public string Title => "003 数据类型";

    public void Run()
    {
        int age = 18;
        Console.WriteLine(age);
    }
}
```

### 运行

```powershell
cd F:\Learn\C#\Learn
dotnet run              # 出菜单，输入编号回车
dotnet run -- 3         # 跳过菜单，直接跑第 3 个
dotnet run -- 0         # 全部跑一遍
```

> `--` 的作用：把后面的参数传给**你的程序**，而不是 `dotnet run` 自己。
> 少了它，`dotnet run 3` 会被 dotnet 当成它自己的参数而报错。

### 加一个新练习

1. 在 `Lessons\` 下新建 `V004_Operators.cs`，照抄上面的类结构，改掉类名和标题
2. 在 `Program.cs` 顶部的清单数组里加一行 `new V004_Operators(),`

菜单顺序 = 数组顺序，文件名不影响。

### 为什么不给每个文件写 Main

因为**一个项目只能有一个入口点**：

| 情况 | 结果 |
|---|---|
| 一个顶级语句文件 + 若干个带 `Main` 的类 | ⚠️ warning CS7022，`Main` 被**静默忽略** |
| 两个类都写了 `Main` | ❌ error CS0017，编译直接失败 |

重构前 `Learn\` 就是第一种：`dotnet run` 永远只跑 v001，v002 和 v003 的 `Main` 被丢掉了
（编译还能"成功"，所以特别容易被骗）。所以改成「一个入口 + 多个 `Run()`」。

**什么时候该换成「一个练习一个项目」**：当某个练习需要单独的 NuGet 包、
或者要试不同的 `<TargetFramework>` 时。那时用 `dotnet new console -o 项目名` 建独立项目。

## 六、VS Code 配置

### 首次设置

1. 装扩展：`Ctrl+Shift+X` 搜索 **C# Dev Kit**（会连带装上 C# 扩展）
2. **打开 `Learn` 文件夹本身**（不是 `F:\Learn\C#`）：

   ```powershell
   code F:\Learn\C#\Learn
   ```

   > 必须是 `Learn` 文件夹。VS Code 只读**打开的那个文件夹**里的
   > `.vscode\launch.json`，打开成上级目录会读不到，F5 直接报错。

### 按 F5 调试

`.vscode\launch.json` 里配了两套，用左上角下拉框切换：

| 配置名 | 等价命令 | 什么时候用 |
|---|---|---|
| 练习：打开菜单 | `dotnet run` | 想连着试好几个练习 |
| 练习：指定编号 | `dotnet run -- 3` | 按 F5 后弹框问编号，直奔一个 |

两套都会先跑 `.vscode\tasks.json` 里的 `build` 任务编译，再启动调试器，
所以改完代码直接按 F5 就行，不用手动 `dotnet build`。

> 关键点：配置里写的是 `"console": "integratedTerminal"`。
> 默认的 `internalConsole` 不支持键盘输入，菜单里的 `Console.ReadLine()` 会读不到东西。
> 要下断点、单步、看变量，就在练习代码左侧点一下红点，再按 F5。

### 加新练习后要改什么

不用改 `.vscode`——两套配置都是按编号传参的，加练习只需改 `Program.cs` 里的清单数组。
只有 `inputs` 里那句提示文案写死了「1-3」，练习变多了可以顺手改一下。
