namespace Learn.Lessons;

public class V017_Class : ILesson
{
    public string Title => "017 深入理解类";

    class Person
    {
        // 自动属性
        // get 只读属性
        // set 只写属性
        // init 初始化属性（只在构造阶段写入）
        public string Name { get; init; }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException("年龄必须在 0 到 120 之间");
                }
                _age = value;
            }
        }
        private int _age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Person()
        {
        }
    }

    // 主构造函数
    class Circle(double radius)
    {
        // 编译时确定的常量，不能被修改。
        // 通过 Circle.Pi 访问，不能通过类实例访问。
        public const double Pi = 3.1415926;
        // 只读属性，初始化后不可以修改
        public readonly double Radius = radius;
        // 只读计算属性
        public double Area
        {
            get
            {
                return Pi * Radius * Radius;
            }
        }
        // 析构方法，只有存在非C#托管资源时可能会使用，大部分情况不需要。
        ~Circle()
        {
            Console.WriteLine("销毁资源");
        }
    }

    public void Run()
    {
        try
        {
            Person p = new("张三", 18);
            Console.WriteLine($"姓名：{p.Name}，年龄：{p.Age}");
            Person p2 = new()
            {
                Name = "李四",
                Age = 150
            };
            Person p1 = new("李四", 150);
            Console.WriteLine($"姓名：{p1.Name}，年龄：{p1.Age}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Circle c = new(5);
        Console.WriteLine($"圆的面积：{c.Area}");
    }
}
