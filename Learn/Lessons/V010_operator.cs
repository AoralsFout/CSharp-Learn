namespace Learn.Lessons;

public class V010_operator : ILesson
{
    public string Title => "010 运算符";

    public void Run()
    {
        int a = 3;
        int b = 5;

        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * {b} = {a * b}");
        Console.WriteLine($"{a} / {b} = {(double)(a / b)}");
        Console.WriteLine($"{a} % {b} = {a % b}");

        int i = 1;
        Console.WriteLine($"i = {i}");
        Console.WriteLine($"i++ = {i++}");
        Console.WriteLine($"i = {i}");
        int j = 1;
        Console.WriteLine($"j = {j}");
        Console.WriteLine($"++j = {++j}");
        Console.WriteLine($"j = {j}");

        int o = 10;
        Console.WriteLine($"o = {o}");
        o += 10; // o = o + 10;
        Console.WriteLine($"o+=10");
        Console.WriteLine($"o = {o}");

        // 逻辑运算符
        Console.WriteLine($"True && True = {true && true}");
        Console.WriteLine($"True && False = {true && false}");
        Console.WriteLine($"False && True = {false && true}");
        Console.WriteLine($"False && False = {false && false}");
        Console.WriteLine($"True || True = {true || true}");
        Console.WriteLine($"True || False = {true || false}");
        Console.WriteLine($"False || True = {false || true}");
        Console.WriteLine($"False || False = {false || false}");
        Console.WriteLine($"!True = {!true}");
        Console.WriteLine($"!False = {!false}");

        // 逻辑运算符的短路效果
        bool fn()
        {
            Console.Write("fn() 被调用:");
            return true;
        }
        Console.WriteLine($"true || fn() = {true || fn()} ");    // fn()未被调用

        // 按位运算符
        // 与：&，或：|，异或：^，取反：~
        Console.WriteLine($"{a} & {b} = {a & b}");  // 1
        Console.WriteLine($"{a} | {b} = {a | b}");  // 7
        Console.WriteLine($"{a} ^ {b} = {a ^ b}");  // 6
        Console.WriteLine($"~{a} = {~a}");          // -4
        Console.WriteLine($"true | fn() = {true | fn()} ");    // fn()被调用
    }
}
