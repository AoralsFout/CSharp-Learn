namespace Learn.Lessons;

public class V015_FunctionParams : ILesson
{
    public string Title => "015 方法参数";

    public void Run()
    {
        /*
         * 方法参数
         * ref: 引用参数
         * out: 输出参数
         * in:  输入参数(只读引用)
         * params: 可变参数
        */
        static void AddWithRef(ref int a, int b)
        {
            a += b;
        }
        static void AddWithOut(int a, int b, out int result)
        {
            result = a + b;
        }
        int a = 10;
        AddWithRef(ref a, 5);
        Console.WriteLine(a);
        AddWithOut(10, 5, out int result); // 输出参数，可以在括号内定义，括号外也可以使用定义的输出参数。
        Console.WriteLine(result);
        static int sum(params int[] args)
        {
            int sum = 0;
            foreach (int i in args)
            {
                sum += i;
            }
            return sum;
        }
        Console.WriteLine(sum(1, 2, 3, 4, 5));
        // 默认参数
        static void Log(string msg, string level = "INFO")
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level,-5}] {msg}");
        }
        Log("这是一条信息");
        Log("这是一条错误信息", "ERROR");
    }
}
