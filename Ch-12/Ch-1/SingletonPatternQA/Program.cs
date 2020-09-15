using System;


namespace SingletonPatternQA
{
    // public sealed class Singleton
    public class Singleton
    {
        private static readonly Singleton Instance = new Singleton();
        //private static readonly Singleton Instance;

        private static int TotalInstances;
        /*
         * Private constructor is used to prevent
         * creation of instances with 'new' keyword
         * outside this class.
        */
        private Singleton()
        {
            Console.WriteLine("--Private constructor is called.");            
            TotalInstances++;
            Console.WriteLine($"-Singleton instance is created.Number of instances:{ TotalInstances}");
            Console.WriteLine("--Exit now from private constructor.");
        }        

        public static Singleton GetInstance
        {
            get
            {
                return Instance;
            }
        }      

        //The keyword "sealed" can guard this scenario.
        public class NestedDerived : Singleton { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton Pattern Q&A***\n");
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
            Singleton.NestedDerived nestedClassObject1 = new Singleton.NestedDerived();
            Singleton.NestedDerived nestedClassObject2 = new Singleton.NestedDerived();
            
            Console.Read();
        }
    }
}

