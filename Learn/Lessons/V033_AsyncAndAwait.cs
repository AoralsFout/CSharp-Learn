namespace Learn.Lessons;

public class V033_AsyncAndAwait : ILesson
{
    public string Title => "033 异步编程";

    static void OrderDelivery()
    {
        Console.WriteLine("开始配送");
    }

    static async Task WaitForDelivery()
    {
        Console.WriteLine("等待配送完成");
        await Task.Delay(5000);
        Console.WriteLine("配送完成");
    }

    static async Task Eat()
    {
        Console.WriteLine("开始吃");
        await Task.Delay(5000);
        Console.WriteLine("吃完");
    }

    static async Task LearnCSharp()
    {
        Console.WriteLine("开始学习C#");
        await Task.Delay(10000);
        Console.WriteLine("学习完成");
    }

    static async Task MainAsync()
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();

        OrderDelivery();
        var waitingTask = WaitForDelivery();
        var learningTask = LearnCSharp();
        await waitingTask;
        await Eat();
        await learningTask;
        sw.Stop();
        Console.WriteLine($"耗时：{sw.ElapsedMilliseconds}ms");
    }

    public void Run()
    {
        // 等外卖到的同时开始学习，外卖到达后一边学习一边吃。
        MainAsync().Wait();
    }
}
