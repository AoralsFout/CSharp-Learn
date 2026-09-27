namespace Learn.Lessons;

public class V022_Enum : ILesson
{
    public string Title => "022 枚举类型";

    // 枚举默认是 int 类型，也可以指定其他类型
    enum Weekday : short
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }

    public void Run()
    {
        Weekday today = Weekday.Tuesday;
        Console.WriteLine(today);       // Tuesday
        Console.WriteLine((int)today);  // 2

        // 枚举搭配 switch 语句使用
        switch (today)
        {
            case Weekday.Monday:
                Console.WriteLine("今天是周一");
                break;
            case Weekday.Tuesday:
                Console.WriteLine("今天是周二");
                break;
            default:
                Console.WriteLine("今天不是周一也不是周二");
                break;
        }
    }
}
