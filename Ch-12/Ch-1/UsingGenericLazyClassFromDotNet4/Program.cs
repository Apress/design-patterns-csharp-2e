using System;

namespace UsingGenericLazyClassFromDotNet4
{
    //Singleton implementation using Lazy<T>      
    public sealed class Singleton
    {
        //Custom delegate
        delegate Singleton SingletonDelegateWithNoParameter();
        static SingletonDelegateWithNoParameter myDel = MakeSingletonInstance;

        //Using built-in Func<out TResult> delegate
        static Func<Singleton> myFuncDelegate= MakeSingletonInstance;

        private static readonly Lazy<Singleton> Instance = new Lazy<Singleton>(            
            //myDel()  //Also ok.Using a custom delegate
            myFuncDelegate()
            //() => new Singleton()  //Using lambda expression
            );

        private static Singleton MakeSingletonInstance()
        {
            return new Singleton();
        }
        private Singleton() { }

        public static Singleton GetInstance
        {
            get
            {
                return Instance.Value;
            }
        }      
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton pattern demo using Lazy<T> from .NET4***\n");         
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
