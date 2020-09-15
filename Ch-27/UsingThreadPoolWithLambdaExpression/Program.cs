using System;
using System.Threading;

namespace UsingThreadPoolWithLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Asynchronous Programming Demonstration.***");
            Console.WriteLine("***Using ThreadPool with Lambda Expression.***");

            // Using Threadpool
            // Not passing any parameter for ExecuteMethodTwo()
            ThreadPool.QueueUserWorkItem(ExecuteMethodTwo);
            // Using lambda Expression
            // Here the method needs a parameter(input).
            // Passing 10 as the parameter for ExecuteMethodThree
            ThreadPool.QueueUserWorkItem((number) =>
            {
                Console.WriteLine("--MethodThree has started.");
                int upperLimit = (int)number;
                for (int i = 0; i < upperLimit; i++)
                {
                    Console.WriteLine("---MethodThree prints 3.0{0}", i);
                }
                Thread.Sleep(100);
                Console.WriteLine("--MethodThree has finished.");
            }, 10

          );

            ExecuteMethodOne();
            Console.WriteLine("End Main().");
            Console.ReadKey();
        }
        /// <summary>
        /// ExecuteMethodOne()
        /// </summary>
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
        //private static void ExecuteMethodTwo()//Compilation error now
        private static void ExecuteMethodTwo(Object state)
        {
            Console.WriteLine("--MethodTwo has started.");
            // Some small task
            Thread.Sleep(100);
            Console.WriteLine("--MethodTwo has finished.");
        }
    }
}

