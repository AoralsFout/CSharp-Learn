namespace Learn.Lessons;

/// <summary>
/// 所有练习的统一约定。
///
/// 只要一个类实现了这个接口，它就能被 Program.cs 的菜单认出来。
/// 接口 = 一份「你必须有什么」的合同：这里要求两样东西——
///   Title：菜单上显示的名字
///   Run()：被选中时执行的代码
/// </summary>
public interface ILesson
{
    string Title { get; }

    void Run();
}
