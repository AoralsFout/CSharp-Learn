namespace Learn.Lessons;

public class V030_Generic : ILesson
{
    public string Title => "030 泛型";

    class Vector2<T>(T x, T y)
    {
        public T X = x;
        public T Y = y;
    }

    public void Run()
    {
        List<int> list = [1, 2, 3];
        list.Add(4);
        // list.Add("5"); // 编译错误：泛型列表只能添加相同类型的元素

        Vector2<int> vec = new(1, 2);
        Console.WriteLine($"vec.X:{vec.X}, vec.Y:{vec.Y}");

        // 泛型委托
        // Action<T>：无返回值，有多个（最大 16 个参数）参数
        // Func<T, TResult>：有返回值，有多个（最大 16 个参数）参数
        // Predicate<T>：返回值为 bool，有一个参数
    }
}
