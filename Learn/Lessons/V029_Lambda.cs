namespace Learn.Lessons;

public class V029_Lambda : ILesson
{
    public string Title => "029 Lambda表达式";

    delegate void MyDelegate(int a, int b);

    public void Run()
    {
        MyDelegate del = (a, b) => Console.WriteLine(a + b);

        del(1, 2);
    }
}
