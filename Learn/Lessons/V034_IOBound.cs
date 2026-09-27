namespace Learn.Lessons;

public class V034_IOBound : ILesson
{
    public string Title => "034 IO密集和并发";

    // 比较异步下载、同步下载和异步并发下载
    // 同步下载：下载过程中阻塞进程。
    // 异步下载：下载过程中不阻塞进程。
    // 异步并发下载：多个异步下载同时进行。

    private static string[] urls = [
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/csharp.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/HelloWorld.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/KrnlsYs.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/await.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/async.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/dotnet.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/Microsoft.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/VisualStudio.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/Abracadabra.txt",
        "https://raw.githubusercontent.com/KrnlsYs/AsyncExample/refs/heads/main/Apple.txt",
    ];

    private static HttpClient httpClient = new();

    static async Task MainAsync()
    {
        Console.WriteLine("开始异步下载");
        foreach (string url in urls)
        {
            Console.WriteLine($"[{url}]开始下载");
            string content = await httpClient.GetStringAsync(url);
            Console.WriteLine($"[{url}]下载完成:\n{content}");
        }
        Console.WriteLine("异步下载完成");
    }

    static async Task MainConcurrency()
    {
        Console.WriteLine("开始异步并发下载");
        await Task.WhenAll(urls.Select(async url =>
        {
            Console.WriteLine($"[{url}]开始下载");
            string content = await httpClient.GetStringAsync(url);
            Console.WriteLine($"[{url}]下载完成:\n{content}");
            return content;
        }));
        Console.WriteLine("异步并发下载完成");
    }

    static void MainSync()
    {
        Console.WriteLine("开始同步下载");
        foreach (string url in urls)
        {
            Console.WriteLine($"[{url}]开始下载");
            string content = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            Console.WriteLine($"[{url}]下载完成:\n{content}");
        }
        Console.WriteLine("同步下载完成");
    }

    public void Run()
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        sw.Start();
        MainAsync().Wait();
        sw.Stop();
        long asyncTime = sw.ElapsedMilliseconds;
        sw.Reset();
        Console.WriteLine("-----------------");
        sw.Start();
        MainSync();
        sw.Stop();
        long syncTime = sw.ElapsedMilliseconds;
        sw.Reset();
        Console.WriteLine("-----------------");
        sw.Start();
        MainConcurrency().Wait();
        sw.Stop();
        long concurrencyTime = sw.ElapsedMilliseconds;
        sw.Reset();
        Console.WriteLine("-----------------");
        Console.WriteLine($"异步下载耗时：{asyncTime}ms");
        Console.WriteLine($"同步下载耗时：{syncTime}ms");
        Console.WriteLine($"异步并发下载耗时：{concurrencyTime}ms");
    }
}
