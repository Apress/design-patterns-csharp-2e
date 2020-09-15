using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitAlternateDemonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Exploring task-based asynchronous pattern(TAP) using async and await.****");
            Console.WriteLine("***This is a modified example with three methods.***");
            Console.WriteLine("Inside Main().Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
            /*
             This call is not awaited.So,the current method 
             continues before the call is completed.
             i.e., following async call is not awaited.
             */
            _ = ExecuteTaskOne();
            Method2();
            Console.ReadKey();
        }

        private static async Task ExecuteTaskOne()
        {
            Console.WriteLine("Inside ExecuteTaskOne(), prior to await() call.");
            int value = await Task.Run(Method1);
            Console.WriteLine("Inside ExecuteTaskOne(), after await() call.");
            /*
            Method3() will be called if Method1()
            executes successfully(i.e. if it returns 0)
            */
            if (value == 0)
            {
                Method3();
            }
        }

        private static int Method1()
        {
            int flag = 0;
            try
            {
                Console.WriteLine("Method1() has started.");
                Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
                //Some big task
                Thread.Sleep(3000);
                Console.WriteLine("Method1() has completed its job now.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught Exception {0}", e);
                flag = -1;
            }
            return flag;
        }
        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            Console.WriteLine("Inside Method2(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine("Method2() is completed.");
        }
        private static void Method3()
        {
            Console.WriteLine("Method3() has started.");
            Console.WriteLine("Inside Method3(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine("Method3() is completed.");
        }
    }
}
