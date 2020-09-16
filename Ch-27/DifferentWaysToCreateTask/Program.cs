using System;
using System.Threading;
using System.Threading.Tasks;

namespace DifferentWaysToCreateTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using different ways to create tasks.****");
            Console.WriteLine($"Inside Main().Thread ID:{Thread.CurrentThread.ManagedThreadId}");

            #region Different ways to create and execute task
            // Using constructor.
            Task taskOne = new Task(MyMethod);
            taskOne.Start();
            // Using task factory.
            TaskFactory taskFactory = new TaskFactory();
            // StartNew Method creates and starts a task.
            // It has different overloaded versions.
            Task taskTwo = taskFactory.StartNew(MyMethod);
            // Using task factory via a task.           
            Task taskThree = Task.Factory.StartNew(MyMethod);
            #endregion           
            Console.ReadKey();
        }

        private static void MyMethod()
        {
            Console.WriteLine($"Task.id={Task.CurrentId} with Thread id {Thread.CurrentThread.ManagedThreadId} has started.");
            Thread.Sleep(100);
            Console.WriteLine($"MyMethod for Task.id={Task.CurrentId} and Thread id {Thread.CurrentThread.ManagedThreadId} is completed.");
        }
    }
}

