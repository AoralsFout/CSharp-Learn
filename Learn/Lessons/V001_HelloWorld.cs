namespace Learn.Lessons;

/// <summary>
/// 001 —— 顶级语句（top-level statements，C# 9 起支持）。
///
/// 原始写法就是文件里孤零零一行：
///     Console.WriteLine("Hello, World!");
/// 不用写 class、不用写 Main，编译器自动生成入口点。
///
/// 但一个项目只能有一处顶级语句，所以这里把它收进了 Run() 方法，
/// 由 Program.cs 统一调用。
/// </summary>
public class V001_HelloWorld : ILesson
{
    public string Title => "001 Hello World（顶级语句）";

    public void Run()
    {
        Console.WriteLine("Hello, World!");
    }
}
