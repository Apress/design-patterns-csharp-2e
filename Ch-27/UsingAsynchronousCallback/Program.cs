using System;
using System.Threading;

namespace UsingAsynchronousCallback
{
    class Program
    {
        public delegate void Method1Delegate(int sleepTimeinMilliSec);
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Asynchronous Callback.***");
            Console.WriteLine("Inside Main(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);

            // Asynchrous call using a delegate
            Method1Delegate method1Del = ExecuteMethodOne;
            //IAsyncResult asyncResult = method1Del.BeginInvoke(3000, ExecuteCallbackMethod, null);
            //Passing a string argument for the final parameter of BeginInvoke
            IAsyncResult asyncResult = method1Del.BeginInvoke(3000, ExecuteCallbackMethod, "Method1Delegate, Thank you for using me.");
            //Using lambda expression(For Q&A session)
            //IAsyncResult asyncResult = method1Del.BeginInvoke(3000,
            // (result) =>
            // {
            //     if (result != null)//if null you can throw some exception
            //     {
            //         Console.WriteLine("\nCallbackMethod has started.");
            //         Console.WriteLine($"Inside ExecuteCallbackMethod(),Thread id { Thread.CurrentThread.ManagedThreadId }.");
            //         // Do some housekeeping work/ clean-up operation
            //         Thread.Sleep(100);
            //         Console.WriteLine("CallbackMethod has finished.");
            //     }
            // },
            //null);

            ExecuteMethodTwo();
            while (!asyncResult.IsCompleted)
            {
                // Keep working in main thread
                Console.Write("*");
                Thread.Sleep(5);
            }

            method1Del.EndInvoke(asyncResult);
            Console.WriteLine("Exit Main().");
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

        /* 
         It's a callback method.This method will be invoked 
         when Method1Delegate instance completes its work.
         */
        private static void ExecuteCallbackMethod(IAsyncResult asyncResult)
        {
            if (asyncResult != null)//if null you can throw some exception
            {
                Console.WriteLine("\nCallbackMethod has started.");
                Console.WriteLine($"Inside ExecuteCallbackMethod(...),Thread id {Thread.CurrentThread.ManagedThreadId} .");
                // Do some housekeeping work/ clean-up operation
                Thread.Sleep(100);
                // For Q&A 27.7
                //string msg = (string)asyncResult.AsyncState;
                //Console.WriteLine($"Callback method says : ‘{msg}’");
                Console.WriteLine("CallbackMethod has finished.");
            }
        }
    }
}
