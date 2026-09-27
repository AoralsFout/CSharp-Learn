namespace Learn.Lessons;

public class V004_TypeConversion : ILesson
{
    public string Title => "004 类型转换";

    public void Run()
    {
        float f = 1.5f;
        double d = 3.0;

        // f = d; 不可以，双精度浮点数不能直接赋值给单精度浮点数
        // d = f; 可以，单精度浮点数可以赋值给双精度浮点数，发生隐式类型转换
        f = (float)d; // 显式类型转换
    }
}
