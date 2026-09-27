namespace Learn.Lessons;

/// <summary>
/// 002 —— 传统写法：显式的 class + static void Main。
///
/// 课本原样长这样：
///     class HelloWorld
///     {
///         static void Main()
///         {
///             Console.WriteLine("Hello World!");
///         }
///     }
///
/// 三个要点：
///   static —— Main 属于「类」而不是「某个对象」，所以不用 new 就能跑
///   void   —— 不返回值。也可以写成 static int Main() 返回退出码
///   Main   —— 名字固定，编译器靠它找入口；大小写敏感
///
/// 在这个项目里入口点已经由 Program.cs 占用了，所以 Main 换成了 Run()。
/// </summary>
public class V002_HelloWorldWithClass : ILesson
{
    public string Title => "002 Hello World（传统写法）";

    public void Run()
    {
        Console.WriteLine("Hello World!");
    }
}
