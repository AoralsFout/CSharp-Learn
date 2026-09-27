namespace Learn.Lessons;

public class V007_ValueTypeReferenceType : ILesson
{
    public string Title => "007 值类型和引用类型";

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    void setInt(int a, int value)
    {
        a = value;
    }

    // 引用类型的参数，会改变实参的值
    void setName(Person p, string value)
    {
        p.Name = value;
    }

    public void Run()
    {
        // 引用类型：class, interface, delegate, record, dynamic, object, string
        // 这些类型的变量存储的是引用，不是值
        Person p1 = new("Tom", 18);
        Person p2 = p1;

        setName(p2, "Jerry");
        Console.WriteLine(p1.Name); // Jerry
        Console.WriteLine(p2.Name); // Jerry

        // 值类型：int, float, double, bool, char, enum. struct
        // 这些类型的变量直接存储值
        int a = 1024;
        setInt(a, 4096);
        Console.WriteLine(a); // 1024

        // 可空值类型：int?, float?, double?, bool?, char?, enum?
        // 这些类型的变量可以存储 null
        int? b = 10;
        Console.WriteLine(b); // 10
        b = null;
        Console.WriteLine(b); // "\n"什么也不显示
    }
}
