using System;

namespace UsingSingleLockForSingletonPattern
{
    //Singleton implementation using single lock
    public sealed class Singleton
    {
        /* 
         * We are using volatile to ensure 
         * that assignment to the instance variable finishes 
         * before it’s access.
        */
        private static volatile Singleton Instance;
        private static object lockObject = new Object();

        private Singleton() { }

        public static Singleton GetInstance
        {
            get
            {
                // Locking it first
                lock (lockObject)
                {
                    // Single check
                    if (Instance == null)
                    {
                        Instance = new Singleton();
                    }
                }
                return Instance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton pattern demo using single lock.(Performance is NOT good)***\n");
            Console.WriteLine("***The overall performance is NOT good because you're locking each time an instance is requested.***\n");
            Console.WriteLine("Trying to get a Singleton instance, called firstInstance.");
            Singleton firstInstance = Singleton.GetInstance;
            Console.WriteLine("Trying to get another Singleton instance, called secondInstance.");
            Singleton secondInstance = Singleton.GetInstance;
            if (firstInstance.Equals(secondInstance))
            {
                Console.WriteLine("The firstInstance and secondInstance are the same.");
            }
            else
            {
                Console.WriteLine("Different instances exist.");
            }
            Console.Read();
        }
    }
}
