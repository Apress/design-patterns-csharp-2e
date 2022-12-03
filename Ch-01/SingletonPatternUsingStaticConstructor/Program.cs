using System;

namespace SingletonPatternUsingStaticConstructor
{
    public sealed class Singleton
    {
        #region Singleton implementation using static constructor
        //The following line is discussed in analysis section.
        //private static readonly Singleton Instance = new Singleton();
        private static readonly Singleton Instance;        

        private static int TotalInstances;
        /*
         * Private constructor is used to prevent
         * creation of instances with 'new' keyword
         * outside this class.
        */
        private Singleton()
        {
            Console.WriteLine("--Private constructor is called.");
            Console.WriteLine("--Exit now from private constructor.");            
        }

        /*
         * A static constructor is used  for the following purposes:
         * 1. To initialize any static data;
         * 2. To perform a specific action only once.
         * 
         * The static constructor will be called automatically before         * 
         * i. You create the first instance; or 
         * ii.You refer to any static members in your code.
         * 
         */

        // Here is the static constructor
        static Singleton()
        {
            // Printing some messages before you create the instance
            Console.WriteLine("-Static constructor is called.");
            Instance = new Singleton();
            TotalInstances++;
            Console.WriteLine($"-Singleton instance is created.Number of instances:{ TotalInstances}");
            Console.WriteLine("-Exit from static constructor.");            
        }

        public static Singleton GetInstance
        {
            get
            {
                return Instance;
            }
        }
        
        /* 
         * If you like to use expression-bodied read-only
         * property, you can use the following line (C# v6.0 onwards).
         */
        //public static Singleton GetInstance => Instance;
        #endregion
        /* The following line is used to discuss 
        the drawback of the approach. */
        public static int MyInt = 25;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton Pattern Demonstration.***\n");
            /*The following line is used to discuss 
              the drawback of the approach.*/
            //Console.WriteLine($"The value of MyInt is :{Singleton.MyInt}");
            // Private Constructor.So,you cannot use the 'new' keyword.  
            //Singleton s = new Singleton(); // error
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

