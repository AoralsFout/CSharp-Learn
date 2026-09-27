namespace Learn.Lessons;

public class V018_Inheritance : ILesson
{
    public string Title => "018 继承";

    public class Animal(string name)
    {
        public string Name = name;
    }

    public class Cat(string name) : Animal(name)
    {
        public void meow()
        {
            Console.WriteLine($"{Name}:喵喵喵喵");
        }
    }

    // sealed 密封类，不允许被其他类继承

    public void Run()
    {
        Cat c = new("小白");
        c.meow();
        // C# 不允许多重继承
    }
}
