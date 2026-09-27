namespace Learn.Lessons;

public class V013_Loop : ILesson
{
    public string Title => "013 循环";

    public void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("-----------------");
        // 先判断再操作
        int sum = 0;
        while (sum < 100)
        {
            sum += 10;
            Console.WriteLine(sum);
        }
        Console.WriteLine("-----------------");
        // 先操作再判断
        int cnt = 0;
        do
        {
            cnt++;
            Console.WriteLine(cnt);
        }
        while (cnt < 10);
        Console.WriteLine("-----------------");
        // 九九乘法表
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{j} * {i} = {j * i,-2} | ");
            }
            Console.WriteLine();
        }
    }
}
