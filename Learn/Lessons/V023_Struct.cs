namespace Learn.Lessons;

public class V023_Struct : ILesson
{
    public string Title => "023 结构体类型";

    // 结构体类型
    // 结构体是值类型
    // 结构体必须初始化所有字段
    // 结构体通常描述简单轻量的数值结构例如颜色值，坐标，向量等
    // 结构体隐式密封，不能继承
    struct Vector2(double x, double y)
    {
        public double X = x;
        public double Y = y;
    }

    public void Run()
    {
        Vector2 p = new(10, 20);
        Console.WriteLine($"({p.X}, {p.Y})");
    }
}
