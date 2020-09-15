using System;
using System.Threading;
using System.Threading.Tasks;

namespace UsingTAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Task-based Asynchronous Pattern.****");
            Console.WriteLine($"Inside Main().The thread ID:{Thread.CurrentThread.ManagedThreadId}");
            Task taskForMethod1 = new Task(ExecuteMethodOne);
            taskForMethod1.Start();
            ExecuteMethodTwo();
            Console.ReadKey();
        }

        private static void ExecuteMethodOne()
        {
            Console.WriteLine("Method1 has started.");
            Console.WriteLine($"Inside ExecuteMethodOne(),Thread id {Thread.CurrentThread.ManagedThreadId}.");
            // Some big task
            Thread.Sleep(1000);
            Console.WriteLine("Method1 has completed its job now.");
        }

        private static void ExecuteMethodTwo()
        {
            Console.WriteLine("Method2 has started.");
            Console.WriteLine($"Inside ExecuteMethodTwo(),Thread id {Thread.CurrentThread.ManagedThreadId}.");
            Thread.Sleep(100);
            Console.WriteLine("Method2 is completed.");
        }
    }
}
