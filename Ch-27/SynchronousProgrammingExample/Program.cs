using System;
using System.Threading;

namespace SynchronousProgrammingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***A Synchronous Program Demonstration.***");
            Console.WriteLine("ExecuteMethodTwo() needs to wait for ExecuteMethodOne() to finish first.");
            ExecuteMethodOne();
            ExecuteMethodTwo();
            Console.WriteLine("End Main().");
            Console.ReadKey();
        }
        // First Method
        private static void ExecuteMethodOne()
        {
            Console.WriteLine("MethodOne has started.");
            // Some big task
            Thread.Sleep(1000);
            Console.WriteLine("MethodOne has finished.");
        }
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
