namespace Learn.Lessons;

public class V019_Modifier : ILesson
{
    public string Title => "019 权限修饰符";

    public void Run()
    {
        /*
         * C# 有六种权限修饰符：
         * public 公共，所有类都可以访问
         * protected 保护，只能在当前类和派生类中访问
         * private 私有，只能在当前类中访问
         * internal 内部，只能在当前程序集中访问
         * protected internal 保护内部，只能在当前程序集和派生类中访问
         * private protected 私有保护，只能在当前类和派生类中访问
        */
    }
}
