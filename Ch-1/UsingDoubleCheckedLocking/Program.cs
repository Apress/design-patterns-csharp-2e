using System;

namespace UsingDoubleCheckedLocking
{
    //Singleton implementation using double checked locking.
    public sealed class Singleton
    {
        /* 
         * We are using volatile to ensure 
         * that assignment to the instance variable finishes 
         * before it’s accessed.
        */
        private static volatile Singleton Instance;
        private static object lockObject = new Object();

        private Singleton() { }

        public static Singleton GetInstance
        {
            get
            {
                //First Check
                if (Instance == null)
                {
                    lock (lockObject)
                    {
                        //Second(Double) Check
                        if (Instance == null)
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
            Console.WriteLine("***Singleton pattern demonstration using double-checked locking.***\n");
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
