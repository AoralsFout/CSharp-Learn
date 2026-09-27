namespace Learn.Lessons;

public class V028_Event : ILesson
{
    public string Title => "028 事件委托";

    /*
     * 事件event为对象之间的通信机制，基于发布者-订阅者模型
     * 当特定事件发生，发布者就会通知所有订阅者，订阅者可以对事件进行响应
     * 事件就是基于委托的封装
     * 应该使用标准事件类型而非自定义事件
     */
    
    class ProcessEventArgs(int processId) : EventArgs
    {
        public int ProcessId = processId;
    }

    // 标准事件委托
    // 发布者
    class ProcessManager
    {
        public event EventHandler? ProcessCreated;

        public void CreateProcess(int processId)
        {
            Console.WriteLine($"[ProcessManager]创建进程 {processId}");
            // 为订阅者发布事件
            ProcessCreated?.Invoke(this, new ProcessEventArgs(processId));
        }
    }

    // 订阅者
    class ProcessMonitor
    {
        public void OnProcessCreated(object? sender, EventArgs e)
        {
            if (e is ProcessEventArgs args)
            {
                Console.WriteLine($"[ProcessMonitor]收到 {args.ProcessId} 创建事件");
            }
        }
    }

    public void Run()
    {
        ProcessManager manager = new();
        ProcessMonitor monitor = new();

        // 订阅者订阅事件
        manager.ProcessCreated += monitor.OnProcessCreated;
        // 发布者发布事件
        manager.CreateProcess(1001);
    }
}
