using System.Numerics;

namespace Learn.Lessons;

public class V031_GenericConstraints : ILesson
{
    public string Title => "031 泛型约束";

    class Vector2<T>(T x, T y) where T : struct, INumberBase<T>
    {
        public T X = x;
        public T Y = y;
        public static Vector2<T> operator +(Vector2<T> a, Vector2<T> b)
        {
            return new(a.X + b.X, a.Y + b.Y);
        }
        public void Show()
        {
            Console.WriteLine($"X:{X}, Y:{Y}");
        }
    }

    public void Run()
    {
        Vector2<float> v1 = new(1, 2);
        Vector2<float> v2 = new(3, 4);
        Vector2<float> v3 = v1 + v2;
        v3.Show();
    }
}
