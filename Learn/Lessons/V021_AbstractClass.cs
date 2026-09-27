namespace Learn.Lessons;

public class V021_AbstractClass : ILesson
{
    public string Title => "021 抽象类和接口";

    // 抽象类可以包含构造函数，具体属性，具体方法实现等细节。抽象类不能实例化。
    // 接口只能包含方法签名，不能包含实现代码

    // 消息发送器的接口
    interface IMessageSender
    {
        void SendMessage(string message);
    }

    // 实现 QQ 消息发送器
    public class QQMessageSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"发送 QQ 消息：{message}");
        }
    }
    // 实现微信消息发送器
    public class WechatMessageSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"发送微信消息：{message}");
        }
    }

    void Sender(IMessageSender sender, string message)
    {
        sender.SendMessage(message);
    }

    // 开闭原则：对扩展开放，对修改关闭
    // 新增新的消息发送器时，只需要实现 IMessageSender 接口即可
    public void Run()
    {
        // C# 允许实现任意多个接口
        var qqSender = new QQMessageSender();
        var wechatSender = new WechatMessageSender();
        Sender(qqSender, "你好");
        Sender(wechatSender, "你好");
    }
}
