using System;
using System.Threading;

namespace UsingThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Asynchronous Programming using ThreadPool class.***");

            // Using Threadpool
            // Not passing any parameter for ExecuteMethodTwo
            ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteMethodTwo));
            // Passing 10 as the parameter for ExecuteMethodThree
            ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteMethodThree), 10);
            ExecuteMethodOne();

            Console.WriteLine("End Main().");
            Console.ReadKey();
        }

        private static void ExecuteMethodOne()
        {
            Console.WriteLine("-MethodOne has started.");
            // Some big task
            Thread.Sleep(1000);
            Console.WriteLine("-MethodOne has finished.");
        }

        /* 
        The following method's signature should match 
        the delegate WaitCallback.It is as follows:
        public delegate void WaitCallback(object state)
        */
        private static void ExecuteMethodTwo(object state)
        {
            Console.WriteLine("--MethodTwo has started.");
            // Some small task
            Thread.Sleep(100);
            Console.WriteLine("--MethodTwo has finished.");
        }
        /* 
        The following method has a parameter.
        This method's signature also matches the WaitCallBack  
        delegate signature.
        */
        private static void ExecuteMethodThree(object number)
        {
            Console.WriteLine("---MethodThree has started.");
            int upperLimit = (int)number;
            for (int i = 0; i < upperLimit; i++)
            {
                Console.WriteLine($"---MethodThree prints 3.0{i}");
            }
            Thread.Sleep(100);
            Console.WriteLine("---MethodThree has finished.");
        }
    }
}
