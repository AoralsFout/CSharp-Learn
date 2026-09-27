namespace Learn.Lessons;

public class V020_FunctionOverride : ILesson
{
    public string Title => "020 方法重写/覆盖";

    class Animal(string name)
    {
        public string Name = name;
        // 虚基类方法
        public virtual void eat()
        {
            Console.WriteLine($"{Name} 正在吃");
        }
    }

    class Cat(string name) : Animal(name)
    {
        // 重写、覆盖虚基类方法
        public override void eat()
        {
            Console.WriteLine($"{Name}正在吃鱼");
        }
    }

    public void Run()
    {
        Cat cat = new Cat("小白");
        cat.eat();
    }
}
