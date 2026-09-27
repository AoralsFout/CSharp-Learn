namespace Learn.Lessons;

public class V003_DataType : ILesson
{
    public string Title => "003 数据类型";

    public void Run()
    {
        int age = 18;
        Console.WriteLine(age);
        Console.WriteLine(typeof(int));

        double pi = 3.1415926;
        Console.WriteLine(pi);
        Console.WriteLine(typeof(double));

        // 小数默认双精度浮点数，需要显式指定为单精度浮点数
        float height = 1.8f;
        Console.WriteLine(height);
        Console.WriteLine(typeof(float));

        // DECIMAL：精确的十进制数值类型。适合存储金额、税率、汇率、会计数据等不能接受浮点误差的场景。
        decimal decimalValue = 123.5m;
        Console.WriteLine(decimalValue);
        Console.WriteLine(typeof(decimal));

        bool isTrue = true;
        Console.WriteLine(isTrue);
        Console.WriteLine(typeof(bool));

        char c = 'A';
        Console.WriteLine(c);
        Console.WriteLine(typeof(char));

        // string是引用类型
        string name = "张三";
        Console.WriteLine(name);
        Console.WriteLine(typeof(string));

        int a = 5;
        int b = 8;
        int result = a + b;
        // 表示 a + b = result
        // 字符串插值
        Console.WriteLine($"{a} + {b} = {result}");
        // 格式化字符串
        Console.WriteLine("{0} + {1} = {2}", a, b, result);

        // 自动推导
        var autoTypeA = 100;
        var autoTypeB = 3.14f;
        var autoTypeC = "hello";
        Console.WriteLine(autoTypeA);
        Console.WriteLine(autoTypeB);
        Console.WriteLine(autoTypeC);

        // 自动推导不允许变换类型
        // autoTypeA = "hello"; ❌
        // 自动推导必须赋值
        // var autoTypeD; ❌
    }
}
