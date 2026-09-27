# C# 学习总结

> 覆盖 `Learn\Lessons\` 下 V001–V036 共 36 个练习。
> 2026-09-27 整理。按知识模块归类，不是按文件顺序。

---

## 一、总览

从 Hello World 一路写到 `async/await` 和异步状态机，实际覆盖的范围已经**超出「基本语法」**，
进入了 C# 核心语言特性：

| 模块 | 练习 | 状态 |
|---|---|---|
| 语言基础（类型 / 运算 / 控制流） | 001–004, 010–014 | ✅ |
| 类型系统（值/引用、装箱、枚举、结构体） | 007, 022, 023, 025 | ✅ |
| 方法与参数 | 006, 015, 016 | ✅ |
| 面向对象 | 005, 017–021 | ✅ |
| 运算符重载与自定义转换 | 024 | ✅ |
| 委托 / 事件 / Lambda | 026–029 | ✅ |
| 泛型与集合 | 030–032 | ✅ |
| 异常处理 | 009 | ✅ |
| 异步编程 | 033–036 | ✅ |

其中 **019（权限修饰符）和 036（异步状态机）是纯文字笔记**，没有可执行代码。

---

## 二、语言基础

### 入口点（001, 002）

```csharp
Console.WriteLine("Hello, World!");        // 顶级语句：编译器自动生成入口
```

```csharp
class HelloWorld                            // 传统写法：显式 class + Main
{
    static void Main() { ... }
}
```

- `static` —— 属于类而非对象，不用 `new` 就能调用
- `void` —— 不返回值；也可写 `static int Main()` 返回退出码
- `Main` —— 名字和大小写都固定

**一个项目只能有一个入口点。** 这是本项目从「每文件一个 `Main`」改成
「单一入口 + `ILesson.Run()`」的原因，详见 README 第四节。

### 类型（003）

| 类别 | 类型 | 字面量后缀 |
|---|---|---|
| 整数 | `int` `long` `short` `byte` | — |
| 浮点 | `float` `double` | `f` / 无 |
| 精确小数 | `decimal` | `m` |
| 其他 | `bool` `char` `string` | — |

- **`decimal` 用于金额、税率、汇率** —— 不能接受浮点误差的场景
- `float height = 1.8f;` —— 小数默认是 `double`，赋给 `float` 必须加 `f`
- `int` 只是 `System.Int32` 的别名，`typeof(int)` 打印出来就是 `System.Int32`

**`var` 自动推导**（003）：

```csharp
var a = 100;        // 推导为 int
var b = 3.14f;      // 推导为 float
// var d;           // ❌ 必须同时赋值
// a = "hello";     // ❌ 类型已定，不能变
```

> `var` 不是「动态类型」，它只是让你少写一遍类型名。编译后类型完全确定。

### 类型转换（004）

```
float  →  double     隐式（小范围 → 大范围，安全）
double →  float      显式 (float)d（大范围 → 小范围，可能丢精度）
```

### 运算符（010）

- 算术 `+ - * / %`、自增自减 `i++` / `++j`（**前缀先加后用，后缀先用后加**）
- 复合赋值 `o += 10`
- 逻辑 `&& || !`
- 位运算 `& | ^ ~`
- **短路**：`true || fn()` —— `fn()` 不会执行；但 `true | fn()`（单竖线）**会**执行

> 单竖线 `|` 是位运算，不短路。这是 `&&/||` 和 `&/|` 的关键区别。

### 控制流（011–014）

```csharp
if / else if / else
a > b ? a : b              // 三元运算符

switch (x) { case 1: ...; break; default: ...; }   // 支持 case 穿透合并

for (int i = 0; i < 10; i++) { }
while (cond) { }           // 先判断再执行
do { } while (cond);       // 先执行再判断，至少跑一次

foreach (int item in arr) { }
```

**`foreach` 的迭代变量是拷贝**，改它不影响原数组（014 里的注释验证了这点）。

---

## 三、类型系统

### 值类型 vs 引用类型（007）—— 最重要的分水岭

| | 值类型 | 引用类型 |
|---|---|---|
| 变量存的是 | 值本身 | 指向堆上对象的引用 |
| 赋值时 | 复制一份 | 复制引用（两个变量指向同一对象） |
| 包含 | `int` `float` `double` `bool` `char` `enum` `struct` | `class` `interface` `delegate` `record` `object` `string` |
| 传参给方法 | 改形参**不影响**实参 | 改对象**影响**实参 |

```csharp
Person p1 = new("Tom", 18);
Person p2 = p1;             // 复制引用，p1 和 p2 指向同一个对象
setName(p2, "Jerry");
Console.WriteLine(p1.Name); // Jerry ← p1 也变了

int a = 1024;
setInt(a, 4096);
Console.WriteLine(a);       // 1024 ← 没变
```

**可空值类型**：`int?` `double?` `bool?` `char?`，给值类型加上 `null` 的能力。

### 装箱与拆箱（025）

```csharp
int a = 10;
object obj = a;        // 装箱：值类型 → 引用类型，复制一份到堆上
obj = 15;              // 改的是箱子，a 还是 10
int c = (int)obj;      // 拆箱：必须显式转换
```

- `is` —— 判断类型 → `obj is int`
- `as` —— 转换失败返回 `null`（只能用于引用类型和可空值类型）
- **模式匹配**一步到位：`if (msg is string str) { ... }`

> 装箱有性能开销，泛型集合（`List<int>`）就是为了避免它。

### 枚举（022）

```csharp
enum Weekday : short { Monday = 1, Tuesday, ... }   // 底层默认 int，可指定
(int)Weekday.Tuesday    // 2
```

常配合 `switch` 使用。

### 结构体（023）

- 是**值类型**，隐式 `sealed` 不能继承
- 适合轻量数据：坐标、颜色、向量
- 需要「有身份的对象」时用 `class`，只是「一组数值」时用 `struct`

---

## 四、方法与参数

### 方法的形态（006）

C# **不允许全局方法**，所有方法必须在类里。

```csharp
int Add(int a, int b) { return a + b; }      // 局部函数
static int Sub(int a, int b) { ... }         // 静态方法
int encode(int a) => a * 2;                  // 表达式主体（语法糖）
```

### 参数修饰符（015）—— 四个关键字

| 关键字 | 含义 | 方向 |
|---|---|---|
| `ref` | 引用参数，方法内可改实参 | 进 + 出 |
| `out` | 输出参数，方法内**必须赋值** | 只出 |
| `in` | 只读引用，避免大结构体复制 | 只进 |
| `params` | 可变参数，调用时可传任意个 | 进 |

```csharp
AddWithRef(ref a, 5);                    // a 会被改
AddWithOut(10, 5, out int result);       // 可在括号内声明
int sum(params int[] args)               // 调用：sum(1,2,3,4,5)
void Log(string msg, string level = "INFO")   // 默认参数
```

> `out` 的经典用法就是 `int.TryParse(s, out int n)`。

### 重载（016）

同名方法，**参数列表不同**（类型、个数）即可共存，编译器按实参自动选：

```csharp
add(1, 2)           → int add(int, int)
add(1.0, 2.0)       → double add(double, double)
add(1, 2, 3, 4)     → int add(params int[])
```

---

## 五、面向对象

### 类的组成（005, 017）

```csharp
class Person
{
    public string Name { get; init; }        // 自动属性，init = 只在构造阶段可写
    public int Age                            // 完整属性：可在 set 里加校验
    {
        get => _age;
        set
        {
            if (value < 0 || value > 120) throw new ArgumentException("...");
            _age = value;
        }
    }
    private int _age;

    public Person(string name, int age) { Name = name; Age = age; }
}

class Circle(double radius)                   // 主构造函数（C# 12）
{
    public const double Pi = 3.1415926;       // 编译期常量，通过 Circle.Pi 访问
    public readonly double Radius = radius;   // 只读字段，初始化后不可改
    public double Area => Pi * Radius * Radius;   // 只读计算属性
    ~Circle() { }                             // 终结器，几乎不用
}
```

属性访问器四种形态：`get`（只读）、`set`（可读写）、`init`（仅初始化）、
`{ get; set; }` 自动属性。

### 继承（018）

```csharp
class Animal(string name) { public string Name = name; }
class Cat(string name) : Animal(name) { ... }     // 冒号 = 继承
sealed class Dog : Animal { }                     // sealed 禁止再被继承
```

**C# 不支持多重继承**（一个类只能有一个父类），但可以实现任意多个接口。

### 权限修饰符（019）

| 修饰符 | 可访问范围 |
|---|---|
| `public` | 所有 |
| `protected` | 当前类 + 派生类 |
| `private` | 仅当前类 |
| `internal` | 仅当前程序集 |
| `protected internal` | 程序集 **或** 派生类（并集） |
| `private protected` | 程序集 **且** 派生类（交集） |

### 重写（020）

```csharp
class Animal { public virtual void eat() { ... } }   // 父类：virtual 允许被重写
class Cat : Animal { public override void eat() { ... } }  // 子类：override
```

- `virtual` / `override` 是**运行时多态**的基础
- 对比 `new`（隐藏）—— 那个不参与多态，容易踩坑

### 抽象类 vs 接口（021）

| | 抽象类 | 接口 |
|---|---|---|
| 能有实现代码吗 | ✅ 可以有具体方法 | ❌ 只有签名 |
| 能有字段/构造函数吗 | ✅ | ❌ |
| 一个类能用几个 | 只能继承 **1** 个 | 可实现 **任意多个** |

**开闭原则**：对扩展开放，对修改关闭。021 里的 `IMessageSender` 就是范例——
新增消息渠道只要实现接口，`Sender()` 一行都不用改。

---

## 六、运算符重载（024）

```csharp
public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);

public static implicit operator Vector3(Vector2 v) => new(v.X, v.Y, 0);  // 隐式，自动
public static explicit operator Vector2(Vector3 v) => new(v.X, v.Y);     // 显式，需 (Vector2) 强转
```

- 必须 `public static`，且至少一个参数是所在类型
- `implicit` 要谨慎——转换必须是**不会失败、不丢信息**的
- `Vector2 → Vector3` 补 0 安全，所以隐式；`Vector3 → Vector2` 丢 Z，所以显式

---

## 七、委托、事件、Lambda

### 委托（026）

**委托 = 指向方法的引用**，可以当参数传、当字段存。

```csharp
public delegate int MyDelegate(int a, int b);
MyDelegate del = Calculator.Add;
del += calc.Sub;        // 多播：挂多个方法，依次调用
del(1, 2);              // 有返回值时，只取最后一个方法的返回值
```

### 事件（027, 028）—— 发布者/订阅者模型

```csharp
// 发布者
class ProcessManager
{
    public event EventHandler? ProcessCreated;         // 标准写法
    public void CreateProcess(int id)
        => ProcessCreated?.Invoke(this, new ProcessEventArgs(id));
}
// 订阅者
manager.ProcessCreated += monitor.OnProcessCreated;
```

**028 相对 027 的进步**：从「自定义委托」升级到「标准 `EventHandler` + `EventArgs` 子类」。
这是 .NET 的通用约定，别人一看就懂，应该优先用。

> `?.Invoke()` 里的 `?` 是必需的——没有订阅者时事件为 `null`。

### Lambda（029）

```csharp
MyDelegate del = (a, b) => Console.WriteLine(a + b);
```

Lambda 就是「匿名方法的简写」，配合委托和 LINQ 用得极多。

---

## 八、泛型与集合

### 泛型（030, 031）

```csharp
class Vector2<T>(T x, T y) { public T X = x; public T Y = y; }
Vector2<int> vec = new(1, 2);
```

**泛型约束**（031）—— 给 `T` 加条件，才能对它做运算：

```csharp
class Vector2<T>(T x, T y) where T : struct, INumberBase<T>
{
    public static Vector2<T> operator +(Vector2<T> a, Vector2<T> b)
        => new(a.X + b.X, a.Y + b.Y);       // 没有约束，+ 是编译不过的
}
```

常用内置泛型委托：

| 类型 | 签名 |
|---|---|
| `Action<T...>` | 无返回值，最多 16 个参数 |
| `Func<T..., TResult>` | 有返回值 |
| `Predicate<T>` | 返回 `bool`，一个参数 |

### 集合类型（032）

| 类型 | 特点 | 随机访问 |
|---|---|---|
| `List<T>` | 泛型可变数组，类型安全，**首选** | ✅ `list[i]` |
| `ArrayList` | 非泛型老古董，有装箱开销 | ✅ |
| `Dictionary<K,V>` | 键值对，快速查找 | ❌ 按 key |
| `HashSet<T>` | 无重复元素，快速查找 | ❌ |
| `Queue<T>` | 先进先出 | ❌ |
| `Stack<T>` | 先进后出 | ❌ |

常用操作：`Add` / `Remove` / `RemoveAt` / `Insert` / `Clear` / `ContainsKey`。

---

## 九、异常处理（009）

```csharp
try
{
    int c = a / b;
}
catch (DivideByZeroException)      // 具体异常在前
{
    Console.WriteLine("除数不能为 0");
}
catch (Exception e)                // 兜底在后
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("无论如何都执行");   // 释放资源
}
```

- **catch 顺序：具体 → 宽泛**，反过来编译不过
- `throw new Exception("...")` 手动抛出
- `int.TryParse` 是「不靠异常」的写法——能预料到的失败，优先用 `Try` 系列而不是抛异常

---

## 十、异步编程（033–036）

### 核心（033）

```csharp
static async Task WaitForDelivery()
{
    Console.WriteLine("等待配送完成");
    await Task.Delay(5000);          // 让出线程，5 秒后回来
    Console.WriteLine("配送完成");
}
```

- `async` 标记方法可以 `await`，返回 `Task` / `Task<T>`
- `await` = **不阻塞线程地等**。等的时候线程可以去干别的

**并发执行**（033 外卖例子）：

```csharp
var waitingTask = WaitForDelivery();   // 不 await，先启动
var learningTask = LearnCSharp();      // 也启动，两个并行跑
await waitingTask;                     // 5 秒
await Eat();                           // 再 5 秒
await learningTask;                    // 此时早就好了
// 总耗时 ≈ 10 秒，不是 20 秒
```

> 关键：**先拿到 Task 再统一 await**，才是并发；每个都立刻 `await` 就退化成串行了。

### IO 密集（034）

下载 10 个文件，三种写法对比：

| 写法 | 行为 |
|---|---|
| 同步 `GetAwaiter().GetResult()` | 阻塞线程，一个接一个 |
| 异步 `await GetStringAsync()` | 不阻塞线程，但仍是**一个接一个** |
| 异步并发 `Task.WhenAll(...)` | 10 个同时发出去 |

> **异步 ≠ 并发。** 异步说的是「不干等」，并发说的是「同时干几件事」。
> `Task.WhenAll` 才是并发。

### CPU 密集（035）

```csharp
Task.Run(() => { ... })              // 丢到线程池，不阻塞调用方
Parallel.For(0, 1000, i => { ... })  // 多核并行
```

**判断标准**：

| 场景 | 用什么 |
|---|---|
| IO 密集（网络、文件、数据库） | `async/await`，不需要额外线程 |
| CPU 密集（计算） | `Task.Run` + `Parallel`，需要真线程 |

> 用 `async` 包 CPU 计算是没用的——CPU 本来就在忙，`await` 没东西可让。

### 异步状态机（036，纯笔记）

`async` 方法编译后会被改写成**状态机**：

- 用 `state` 字段记录执行到哪了，初始 `-1`
- 遇到 `await` 时把状态机注册为回调，`state` 切到下一个值
- 回调触发后再进来，从 `state` 对应的地方继续往下跑
- 循环往复直到方法结束

**结论**：`async/await` 是编译器给的语法糖，底层就是状态机 + 回调。

---

## 十一、几个容易搞混的概念（笔记已修正）

复习时最容易记串的四个点：

### private protected 的双重限制

| 修饰符 | 可访问范围 |
|---|---|
| `protected internal` | 程序集 **或** 派生类（并集，宽松） |
| `private protected` | 程序集 **且** 派生类（交集，严格） |

`private protected` 必须**同时**满足「同一程序集内」和「是派生类」两个条件，
比 `protected internal` 严格得多。

### Queue / Stack 不支持随机访问

只有 `List<T>` / `ArrayList` / 数组能用 `[i]` 下标访问。
`Queue<T>` 只能 `Dequeue()` 从队首取，`Stack<T>` 只能 `Pop()` 从栈顶取。
