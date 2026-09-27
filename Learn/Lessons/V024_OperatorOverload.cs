namespace Learn.Lessons;

public class V024_OperatorOverload : ILesson
{
    public string Title => "024 运算符重载";

    class Vector2(double x, double y)
    {
        public double X = x;
        public double Y = y;
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new(a.X + b.X, a.Y + b.Y);
        }
        // 隐式类型转换
        public static implicit operator Vector3(Vector2 v)
        {
            return new(v.X, v.Y, 0);
        }
    }

    class Vector3(double x, double y, double z)
    {
        public double X = x;
        public double Y = y;
        public double Z = z;
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        // 强制类型转换
        public static explicit operator Vector2(Vector3 v)
        {
            return new(v.X, v.Y);
        }
    }

    public void Run()
    {
        Vector2 a = new(1, 2);
        Vector2 b = new(3, 4);
        Vector2 c = a + b;
        Console.WriteLine($"({c.X}, {c.Y})");

        // 类型转换
        Vector3 e = new(1, 2, 3);
        Vector2 f = (Vector2)e; // 强制类型转换
        Console.WriteLine($"({f.X}, {f.Y})");

        Vector2 g = new(1, 2);
        Vector3 h = g; // 隐式类型转换
        Console.WriteLine($"({h.X}, {h.Y}, {h.Z})");
    }
}
