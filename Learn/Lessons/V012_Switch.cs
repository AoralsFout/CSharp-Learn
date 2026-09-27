namespace Learn.Lessons;

public class V012_Switch : ILesson
{
    public string Title => "012 switch";

    public void Run()
    {
        int a = 10;
        switch (a)
        {
            case 10:
                Console.WriteLine("a 等于 10");
                break;
            case 20:
                Console.WriteLine("a 等于 20");
                break;
            default:
                Console.WriteLine("a 不等于 10 也不等于 20");
                break;
        }

        int month = 5;
        switch (month)
        {
            case 3:
            case 4:
            case 5:
                Console.WriteLine("春季");
                break;
            case 6:
            case 7:
            case 8:
                Console.WriteLine("夏季");
                break;
            case 9:
            case 10:
            case 11:
                Console.WriteLine("秋季");
                break;
            default:
                Console.WriteLine("冬季");
                break;
        }
    }
}
