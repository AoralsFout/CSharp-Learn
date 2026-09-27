namespace Learn.Lessons;

public class V026_Delegate : ILesson
{
    public string Title => "026 委托";

    // 委托：指向方法的引用
    // 可以用于注册回调函数，也可以用于事件处理
    public delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public static int Add(int a, int b)
        {
            Console.WriteLine($"Add: {a} + {b} = {a + b}");
            return a + b;
        }
        public int Sub(int a, int b)
        {
            Console.WriteLine($"Sub: {a} - {b} = {a - b}");
            return a - b;
        }
    }


    public void Run()
    {
        MyDelegate del = Calculator.Add;
        Calculator calc = new Calculator();
        // 多播委托：引用多个方法，依次调用
        // 返回值是最后一个方法的返回值
        del += calc.Sub;
        del(1, 2);
        del(3, 4);
    }
}
