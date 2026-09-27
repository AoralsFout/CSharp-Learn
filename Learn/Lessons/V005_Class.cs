namespace Learn.Lessons;

public class V005_Class : ILesson
{
    public string Title => "005 类";

    public class Person
    {
        // 字段，默认访问修饰符为private
        private string Name { get; set; }
        private int Age { get; set; }
        // 静态字段
        public static int MaxAge = 150;

        // 构造函数
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // 方法
        public void Say(string message)
        {
            Console.WriteLine(message);
        }

        // getter and setter
        public string GetName()
        {
            return Name;
        }
        public int GetAge()
        {
            return Age;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetAge(int age)
        {
            Age = age;
        }
    }


    public void Run()
    {
        Person p = new Person("张三", 18);
        Console.WriteLine(p.GetName());
        Console.WriteLine(p.GetAge());
        p.Say("Hello, World!");

        // 简化构造函数
        Person p1 = new ("李四", 20);
        Console.WriteLine(p1.GetName());
        Console.WriteLine(p1.GetAge());
        p1.Say("Hello, World!");
    }
}