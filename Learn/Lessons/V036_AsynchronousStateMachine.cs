namespace Learn.Lessons;

public class V036_AsynchronousStateMachine : ILesson
{
    public string Title => "V036 异步状态机";

    public void Run()
    {
        /*
         * 异步状态机
         * 我们写的异步方法 async，编译后会被转换为状态机。
         * 状态机使用 state 存储当前状态，通过分支语句来切换要执行的代码，初始状态 state 为 -1。
         * 当 state = -1 时，表示异步方法开始执行，碰到异步操作时，会讲状态机注册为回调函数，并将状态 state 切换为 0。
         * 等待异步操作完成，再次调用状态机，此时 state = 0，表示本次异步操作已完成，继续执行其他代码。
         * 循环以上操作直到所有异步操作完成。
         * 这就是异步状态机，将整个状态机变成了 async 语法糖。
         */
    }
}
