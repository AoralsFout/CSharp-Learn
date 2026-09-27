namespace Learn.Lessons;

public class V005_Class : ILesson
{
    public string Title => "005 类";

    public class Person
    {
        // 属性（自动属性）：本质是 get/set 两个方法的语法糖，不是变量。
        // 判断标准：写成 { get; set; } 的就是属性，哪怕看起来像变量。
        private string Name { get; set; }
        private int Age { get; set; }

        // 字段：直接存数据的变量，没有 get/set。
        // 对比着看：Name 是属性，MaxAge 是字段。
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
        // 手写版。如果把上面的属性改成 public，这几个方法就多余了 —— p.Name 等价于 GetName()。
        // 这里两种写法都留着，方便对比「属性」和「方法」两种封装方式。
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