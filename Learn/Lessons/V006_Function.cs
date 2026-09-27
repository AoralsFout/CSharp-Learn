namespace Learn.Lessons;

public class V006_Function : ILesson
{
    public string Title => "006 方法";

    // 静态方法
    static int Sub(int a, int b)
    {
        return a - b;
    }

    public void Run()
    {
        // C# 不允许全局方法，不允许定义在类外部

        // 方法的定义
        // Bread MakeBread(Flour f, Milk m, Salt s)
        // {
        //     ...
        //     return deliciousBread;
        // }

        int Add(int a, int b)
        {
            return a + b;
        }
        int result = Add(5, 8);
        Console.WriteLine(result);

        // 调用静态方法
        int result2 = Sub(5, 8);
        Console.WriteLine(result2);

        // 表达式主体语法糖
        int encode(int a) => a * 2;
        int encoded = encode(5);
        Console.WriteLine(encoded);
    }
}
