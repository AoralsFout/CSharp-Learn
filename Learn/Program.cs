// Program.cs —— 整个项目唯一的入口点。
//
// 所有练习都放在 Lessons/ 目录里，各自是一个类、实现 ILesson 接口。
// 这个文件只做两件事：出菜单、把选中的练习 Run() 起来。
//
// 为什么必须这样：一个项目只能有一个入口点（Main 或顶级语句）。
// 如果每个练习文件都写自己的 Main，编译器只会认其中一个，
// 其余的会被静默忽略（warning CS7022）—— 这就是之前 v002/v003 跑不起来的原因。

using Learn.Lessons;

// ── 练习清单：新增练习时，在这里加一行 ──
ILesson[] lessons =
{
    new V001_HelloWorld(),
    new V002_HelloWorldWithClass(),
    new V003_DataType(),
    new V004_TypeConversion(),
    new V005_Class(),
    new V006_Function(),
    new V007_ValueTypeReferenceType(),
    new V008_Array(),
    new V009_Exception(),
    new V010_operator(),
    new V011_Ifelse(),
    new V012_Switch(),
    new V013_Loop(),
    new V014_foreach(),
    new V015_FunctionParams(),
    new V016_FunctionOverload(),
    new V017_Class(),
    new V018_Inheritance(),
    new V019_Modifier(),
    new V020_FunctionOverride(),
    new V021_AbstractClass(),
    new V022_Enum(),
    new V023_Struct(),
    new V024_OperatorOverload(),
    new V025_BoxingAndUnboxing(),
    new V026_Delegate(),
    new V027_CustomEvent(),
    new V028_Event(),
    new V029_Lambda(),
    new V030_Generic(),
    new V031_GenericConstraints(),
    new V032_GenericCollection(),
};

// ── 带了编号参数就直接跑，跳过菜单：dotnet run -- 3 ──
if (args.Length > 0)
{
    if (int.TryParse(args[0], out int requested))
    {
        RunByNumber(requested);
    }
    else
    {
        Console.WriteLine($"参数「{args[0]}」不是编号。用法：dotnet run -- 3");
    }

    return;
}

// ── 不带参数就出菜单 ──
while (true)
{
    Console.WriteLine();
    Console.WriteLine("═══ C# 练习清单 ═══");

    for (int i = 0; i < lessons.Length; i++)
    {
        // i 从 0 开始，给人看的编号从 1 开始，所以显示时 +1
        Console.WriteLine($"  {i + 1}. {lessons[i].Title}");
    }

    Console.WriteLine("  0. 全部跑一遍");
    Console.WriteLine("  q. 退出");
    Console.Write("选择：");

    string? input = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(input))
    {
        continue;                       // 直接回车 → 重画菜单
    }

    if (input is "q" or "Q")
    {
        return;
    }

    if (input == "0")
    {
        foreach (ILesson lesson in lessons)
        {
            RunLesson(lesson);
        }

        continue;
    }

    if (int.TryParse(input, out int choice))
    {
        RunByNumber(choice);
    }
    else
    {
        Console.WriteLine($"「{input}」不是编号，请重新输入。");
    }
}

// ── 本地函数：顶级语句里可以照样定义函数，并且能直接用上面的 lessons ──
void RunByNumber(int number)
{
    if (number < 1 || number > lessons.Length)
    {
        Console.WriteLine($"没有第 {number} 个练习，可选范围 1~{lessons.Length}。");
        return;
    }

    RunLesson(lessons[number - 1]);
}

void RunLesson(ILesson lesson)
{
    Console.WriteLine();
    Console.WriteLine($"───── {lesson.Title} ─────");
    lesson.Run();
}
