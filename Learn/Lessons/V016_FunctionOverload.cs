namespace Learn.Lessons;

public class V016_FunctionOverload : ILesson
{
    public string Title => "016 方法重载";

    static int add(int a, int b)
    {
        return a + b;
    }
    static double add(double a, double b)
    {
        return a + b;
    }
    static int add(params int[] args)
    {
        int sum = 0;
        foreach (int i in args)
        {
            sum += i;
        }
        return sum;
    }

    public void Run()
    {
        Console.WriteLine(add(1, 2));
        Console.WriteLine(add(1.0, 2.0));
        Console.WriteLine(add(1, 2, 3, 4));
    }
}
