using System;
using System.Threading;
using System.Threading.Tasks;

namespace TAPDemonstration2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Task-based Asynchronous Pattern.Using lambda expression into it.****");
            Console.WriteLine("Inside Main().Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
            // Task taskForMethod1 = new Task(Method1);
            // taskForMethod1.Start();
            Task<string> taskForMethod1 = ExecuteMethodOne();
            /*
             Wait for task to complete.
             If you use Wait() method as follows,you’ll not see the asynchonous behavior.
             */
            //taskForMethod1.Wait();
            // Continue the task
            // The taskForMethod3 will continue once taskForMethod1 is finished
            Task taskForMethod3 = taskForMethod1.ContinueWith(ExecuteMethodThree, TaskContinuationOptions.OnlyOnRanToCompletion);
            ExecuteMethodTwo();
            Console.WriteLine($"Task for Method1 was a : {taskForMethod1.Result}");
            Console.ReadKey();
        }
        // Using lambda expression
        private static Task<string> ExecuteMethodOne()
        {
            return Task.Run(() =>
            {
                string result = "Failure";
                try
                {
                    Console.WriteLine("Method1 has started.");
                    Console.WriteLine($"Inside Method1(),Task.id={Task.CurrentId}");                    
                    Console.WriteLine($"Inside Method1(),Thread id {Thread.CurrentThread.ManagedThreadId}.");
                    //Some big task
                    Thread.Sleep(1000);
                    Console.WriteLine("Method1 has completed its job now.");
                    result = "Success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught:{0}", ex.Message);
                }
                return result;
            }
            );
        }

        private static void ExecuteMethodTwo()
        {
            Console.WriteLine("Method2 has started.");
            Console.WriteLine($"Inside ExecuteMethodTwo(),Thread id {Thread.CurrentThread.ManagedThreadId}.");
            Thread.Sleep(100);
            Console.WriteLine("Method2 is completed.");
        }
        private static void ExecuteMethodThree(Task task)
        {
            Console.WriteLine("Method3 starts now.");
            Console.WriteLine($"Task.id is:{Task.CurrentId} with Thread id is:{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(20);
            Console.WriteLine($"Method3 with Task.id {Task.CurrentId} and Thread id {Thread.CurrentThread.ManagedThreadId} is completed.");
        }
    }
}
