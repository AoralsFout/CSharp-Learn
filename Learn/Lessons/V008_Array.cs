namespace Learn.Lessons;

public class V008_Array : ILesson
{
    public string Title => "008 数组";

    public void Run()
    {
        // 数组：int[], float[], double[], bool[], char[], enum[]
        // 数组的长度是确定的，不能改变
        // 这些类型的变量可以存储多个值
        // 数组是引用类型，存储的是数组的地址
        int[] a = new int[10];                      // 数组的长度是 10
        int[] b = new int[5] { 1, 2, 3, 4, 5 };     // 另一种初始化数组的方式
        int[] c = { 1, 2, 3, 4, 5 };                // 简化初始化数组的方式
        Console.WriteLine(a.Length);                // 10
        a[0] = 1024;
        Console.WriteLine(a[0]);                    // 1024
        a[1] = 4096;
        Console.WriteLine(a[1]);                    // 4096
        Console.WriteLine(a);                       // System.Int32[]
        Console.WriteLine(string.Join(", ", a));    // 1024, 4096, 0, 0, 0, 0, 0, 0, 0, 0

        // 二维数组
        // 两行三列的二维数组
        int[,] d = new int[2, 3];
        int[,] e = {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };
        Console.WriteLine(e[0, 0]);                // 1
        Console.WriteLine(e[1, 2]);                // 6
        Console.WriteLine(e.Length);               // 6
        Console.WriteLine(e.Rank);                 // 2
        // 传入维度，返回该维度的长度
        // 传入 0，返回行数
        // 传入 1，返回列数
        Console.WriteLine(e.GetLength(0));           // 2
        Console.WriteLine(e.GetLength(1));           // 3
    }
}
