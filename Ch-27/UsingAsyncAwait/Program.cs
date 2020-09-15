using System;
using System.Threading;
using System.Threading.Tasks;

namespace UsingAsyncAwait
{
    class Program
    {
        static void Main(string[] args)        
        {
            Console.WriteLine("***Exploring task-based asynchronous pattern(TAP) using async and await.****");
            Console.WriteLine("Inside Main().Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
            /*
             This call is not awaited.So,the current method 
             continues before the call is completed.
             i.e., following async call is not awaited.
             */
            // ExecuteTaskOne();
            //ExecuteMethod1();
             _ = ExecuteMethod1();
            //await ExecuteMethod1();
            
            //Thread.Sleep(100);
            Method2();
            Console.ReadKey();
        }

        //private static async Task ExecuteTaskOne()
        //{
        //    await Task.Run(Method1);
        //}
        //private static void Method1()
        //{
        //    Console.WriteLine("Method1() has started.");
        //    Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
        //    // Some big task
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Method1() has completed its job now.");
        //}

        // Using lambda expression
        private static async Task ExecuteMethod1()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Method1() has started.");
                Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
                // Some big task
                Thread.Sleep(1000);
                Console.WriteLine("Method1() has completed its job now.");
            }
        );
        }

        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            Console.WriteLine("Inside Method2(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Some small task
            Thread.Sleep(100);
            Console.WriteLine("Method2() is completed.");
        }
    }
}

