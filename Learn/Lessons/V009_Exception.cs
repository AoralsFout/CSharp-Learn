namespace Learn.Lessons;

public class V009_Exception : ILesson
{
    public string Title => "009 异常";

    public void Run()
    {
        try
        {
            int a = 10;
            int b = 0;
            int c = a / b;
            Console.WriteLine(c);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("除数不能为 0");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("finally");
        }

        try
        {
            int result = int.Parse(Console.ReadLine());
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("请输入一个整数");
        }

        try
        {
            // 手动抛出异常
            throw new Exception("这是一个异常");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
