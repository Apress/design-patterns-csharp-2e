using System;
using System.Threading;

namespace UsingThreadClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Asynchronous Programming using Thread class.***");
            //ExecuteMethodOne();
            //Old approach.Creating a separate thread for the following task(i.e ExecuteMethodOne.)
            Thread newThread = new Thread(() =>
            {
                Console.WriteLine("MethodOne has started on a separate thread.");
                // Some big task
                Thread.Sleep(1000);
                Console.WriteLine("MethodOne has finished.");
            }
            );
            newThread.Start();
            /* 
               Taking a small sleep to increase the probability of executing 
               ExecuteMethodOne() before ExecuteMethodTwo().
            */
            Thread.Sleep(20);
            ExecuteMethodTwo();
            Console.WriteLine("End Main().");
            Console.ReadKey();
        }
        //// First Method
        //private static void ExecuteMethodOne()
        //{
        //    Console.WriteLine("MethodOne has started.");
        //    // Some big task
        //    Thread.Sleep(1000);
        //    Console.WriteLine("MethodOne has finished.");
        //}
        // Second Method
        private static void ExecuteMethodTwo()
        {
            Console.WriteLine("MethodTwo has started.");
            // Some small task
            Thread.Sleep(100);
            Console.WriteLine("MethodTwo has finished.");
        }
    }
}

