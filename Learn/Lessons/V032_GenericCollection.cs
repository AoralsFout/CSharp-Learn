using System.Collections;

namespace Learn.Lessons;

public class V032_GenericCollection : ILesson
{
    public string Title => "032 泛型集合类型";

    public void Run()
    {
        // List 列表：泛型可变数组，类型安全，支持随机访问，没有装箱和拆箱的性能损失，建议使用
        // ArrayList 数组列表：可变数组，类型不安全，支持随机访问，会有装箱和拆箱的性能损失，不建议使用
        // Dictionary 字典：键值对集合，支持快速查找，不支持随机访问。
        // HashSet 集合：无重复元素集合，支持快速查找，不支持随机访问。
        // Queue 队列：先进先出，支持随机访问。
        // Stack 栈：先进后出，支持随机访问。
        List<int> list = [1, 2, 3];
        list.Add(4);        // 添加元素到列表末尾
        list.RemoveAt(0);   // 删除索引为 0 的元素
        list.Remove(2);     // 删除值为 2 的元素
        list.Insert(1, 100);// 在索引为 1 的位置插入元素 100
        list.Clear();       // 清空列表
        ArrayList arrayList = [1, 2, 3];
        Dictionary<int, string> dictionary = new() 
        {
            {1,"a"},
            {2,"b"},
            {3,"c"}
        };
        dictionary.Add(4, "d");
        dictionary.Remove(2);
        dictionary.Clear();
        Console.WriteLine(dictionary[1]);
        Console.WriteLine(dictionary.ContainsKey(1));
        HashSet<int> hashSet = [1, 2, 3];
        hashSet.Add(4);
        hashSet.Remove(2);
        hashSet.Clear();
        Queue<int> queue = new();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine(queue.Dequeue());
        Stack<int> stack = new();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine(stack.Pop());
    }
}
