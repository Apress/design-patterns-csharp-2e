using System;
using System.Threading;
//RUN THIS PROGRAM ON .NET FRAMEWORK.

namespace UsingWaitHandleInDotNetFramework
{
    class Program
    {
        public delegate void Method1Delegate(int sleepTimeinMilliSec);
        static void Main(string[] args)
        {
            Console.WriteLine("***Polling and WaitHandle Demo.***");
            Console.WriteLine("Inside Main(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            // Synchronous call
            //ExecuteMethodOne(3000);
            // Asynchrous call using a delegate
            Method1Delegate method1Del = ExecuteMethodOne;
            IAsyncResult asyncResult = method1Del.BeginInvoke(3000, null, null);
            ExecuteMethodTwo();
            // while (!asyncResult.IsCompleted)
            while (true)
            {
                // Keep working in main thread
                Console.Write("*");
                /* 
                 * There are 5 different overload method for WaitOne().
                 * Following method blocks the current thread until the 
                 * current System.Threading.WaitHandle receives a signal,
                 * using a 32-bit signed integer to specify the time 
                 * interval in milliseconds.
                 */
                if (asyncResult.AsyncWaitHandle.WaitOne(10))
                {
                    Console.Write("\nResult is available now.");
                    break;
                }
            }
            method1Del.EndInvoke(asyncResult);
            Console.WriteLine("\nExiting Main().");
            Console.ReadKey();
        }
        
        // First Method
        private static void ExecuteMethodOne(int sleepTimeInMilliSec)
        {
            Console.WriteLine("MethodOne has started.");
            // It will have a different thread id
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
