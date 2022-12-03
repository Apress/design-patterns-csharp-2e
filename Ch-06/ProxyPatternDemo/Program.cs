using System;

namespace ProxyPatternDemo
{
    /// <summary>
    /// Abstract class Subject
    /// </summary>
    public abstract class Subject
    {
        public abstract void DoSomeWork();
    }
    /// <summary>
    /// ConcreteSubject class
    /// </summary>
    public class ConcreteSubject : Subject
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("I've processed your request.");
        }
    }
    /// <summary>
    /// Proxy class
    /// </summary>
    public class Proxy : Subject
    {
        Subject subject;

        public override void DoSomeWork()
        {
            Console.WriteLine("Welcome, my client.");
            /* 
            Lazy initialization:We'll not instantiate the object until
            the method is called.
            */
            if (subject == null)
            {
                subject = new ConcreteSubject();
            }
            subject.DoSomeWork();
        }
    }
    /// <summary>
    /// Client class
    /// </summary>

    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Proxy Pattern Demo.***\n");
            Subject proxy = new Proxy();
            proxy.DoSomeWork();
            Console.ReadKey();
        }
    }
}
