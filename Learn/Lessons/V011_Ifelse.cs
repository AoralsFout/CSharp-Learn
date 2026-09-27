namespace Learn.Lessons;

public class V011_Ifelse : ILesson
{
    public string Title => "011 if-else";

    public void Run()
    {
        int a = 10;
        int b = 5;
        int c = 20;
        int d = 10;
        if (a > b)
        {
            Console.WriteLine("a 大于 b");
        }
        else
        {
            Console.WriteLine("a 小于等于 b");
        }

        if (a == d)
        {
            Console.WriteLine("a 等于 d");
        }
        else
        {
            Console.WriteLine("a 不等于 d");
        }

        if (a <= c)
        {
            Console.WriteLine("a 小于等于 c");
        }
        else
        {
            Console.WriteLine("a 大于 c");
        }

        // 三元运算符
        int result = a > b ? a : b;
        Console.WriteLine($"a 大于 b 的结果是：{result}");
        result = a >= b ? a : b;
        Console.WriteLine($"a 大于等于 b 的结果是：{result}");
    }
}
