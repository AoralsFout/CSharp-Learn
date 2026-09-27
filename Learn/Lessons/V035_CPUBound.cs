using System.Diagnostics;

namespace Learn.Lessons;

public class V035_CPUBound : ILesson
{
    public string Title => "V035 CPU密集和异步多线程";

    // CPU密集计算
    static void CpuBound()
    {
        int sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }
    }

    static async Task MainAsync()
    {
        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        for (int i = 0; i < 1000; i++)
        {
            CpuBound();
        }
        sw.Stop();
        Console.WriteLine($"同步阻塞CPU密集计算耗时：{sw.ElapsedMilliseconds}ms");
        sw.Reset();
        sw.Start();
        await Task.Run(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                CpuBound();
            }
        });
        sw.Stop();
        Console.WriteLine($"异步非阻塞CPU密集计算耗时：{sw.ElapsedMilliseconds}ms");
        sw.Reset();
        sw.Start();
        await Task.Run(() =>
        {
            Parallel.For(0, 1000, i =>
            {
                CpuBound();
            });
        });
        sw.Stop();
        Console.WriteLine($"异步并行CPU密集计算耗时：{sw.ElapsedMilliseconds}ms");
    }

    public void Run()
    {
        MainAsync().Wait();
    }
}
