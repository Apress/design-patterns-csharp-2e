using System;

namespace SingletonPatternUsingStaticInitialization
{
    public sealed class Singleton
    {
        #region Using static initialization
        private static readonly Singleton Instance = new Singleton();        

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
        public static Singleton GetInstance
        {
            get
            {
                return Instance;
            }
        }
        /* 
         * If you like to use expression-bodied read-only
         * property, you can use the following line(C# 6.0 onwards).
         */
        //public static Singleton GetInstance => Instance;
        #endregion       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton Pattern Demonstration.***\n");
            /*The following line is used to discuss 
              the drawback of the approach.*/
            //Console.WriteLine($"The value of MyInt is :{Singleton.MyInt}");
            // Private Constructor.So,you cannot use 'new' keyword.  
            //Singleton s = new Singleton();//error
            Console.WriteLine("Trying to get a Singleton instance, called firstInstance.");
            Singleton firstInstance = Singleton.GetInstance;
            Console.WriteLine("Trying to get another Singleton instance, called secondInstance.");
            Singleton secondInstance = Singleton.GetInstance;
            if (firstInstance.Equals(secondInstance))
            {
                Console.WriteLine("The firstInstance and secondInstance are same.");
            }
            else
            {
                Console.WriteLine("Different instances exist.");
            }
            Console.Read();
        }
    }
}

