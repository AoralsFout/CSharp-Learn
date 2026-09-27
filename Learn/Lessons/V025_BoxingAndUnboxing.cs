namespace Learn.Lessons;

public class V025_BoxingAndUnboxing : ILesson
{
    public string Title => "025 装箱和拆箱";

    public void Run()
    {
        // 装箱：将值类型转换为引用类型，是对值类型副本的引用
        // 拆箱：将引用类型转换为值类型
        int a = 10;
        object obj = a;
        Console.WriteLine($"a:{a}, obj:{obj}");
        obj = 15;
        Console.WriteLine($"a:{a}, obj:{obj}");
        // 拆箱，必须是显式类型转换
        int c = (int)obj;
        Console.WriteLine($"c:{c}");

        // is 关键字：判断引用类型是否是值类型的实例
        bool isInt = obj is int;
        Console.WriteLine($"isInt:{isInt}");
        // as 关键字：将引用类型转换为值类型，如果失败则返回 null
        int? intObj = obj as int?;
        Console.WriteLine($"intObj:{intObj}");

        // 模式匹配写法
        // 判断转换一步到位
        object msg = "C#";
        if (msg is string str)
        {
            Console.WriteLine($"str:{str}");
        }
    }
}
