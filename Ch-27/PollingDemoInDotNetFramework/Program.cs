using System;
using System.Threading;

namespace PollingDemoInDotNetFramework
{
    //WILL NOT WORK ON .NET CORE. 
    //RUN THIS PROGRAM ON .NET FRAMEWORK.
    class Program
    {
        public delegate void Method1Delegate(int sleepTimeinMilliSec);
        static void Main(string[] args)
        {
            Console.WriteLine("***Polling Demo.Run it in .NET Framework.***");
            Console.WriteLine("Inside Main(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            // Synchronous call
            //ExecuteMethodOne(3000);

            Method1Delegate method1Del = ExecuteMethodOne;
            IAsyncResult asyncResult = method1Del.BeginInvoke(3000, null, null);
            ExecuteMethodTwo();
            while (!asyncResult.IsCompleted)
            {
                // Keep working in main thread
                Console.Write("*");
                Thread.Sleep(5);
            }

            method1Del.EndInvoke(asyncResult);
            Console.ReadKey();
        }
        // First Method
        private static void ExecuteMethodOne(int sleepTimeInMilliSec)
        {
            Console.WriteLine("MethodOne has started.");
            Console.WriteLine($"Inside ExecuteMethodOne(),Thread id {Thread.CurrentThread.ManagedThreadId}.");
            // Some big task
            Thread.Sleep(sleepTimeInMilliSec);
            Console.WriteLine("\nMethodOne has finished.");
        }
        // Second Method
        private static void ExecuteMethodTwo()
        {
            Console.WriteLine("MethodTwo has started.");
            Console.WriteLine($"Inside ExecuteMethodTwo(),Thread id {Thread.CurrentThread.ManagedThreadId}.");
            // Some small task
            Thread.Sleep(100);
            Console.WriteLine("MethodTwo has finished.");
        }

    }
}

