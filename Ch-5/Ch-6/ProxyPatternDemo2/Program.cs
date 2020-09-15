using System;
using System.Linq;//For Contains() method below

namespace ProxyPatternQAs
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
            Console.WriteLine("I've processed your request.\n");
        }
    }
    /// <summary>
    /// Proxy class
    /// </summary>
    public class Proxy : Subject
    {
        Subject subject;
        string[] registeredUsers;
        string currentUser;
        public Proxy(string currentUser)
        {
            /*
             * Avoiding to instantiate ConcreteSubject
             * inside the Proxy class constructor.
            */
            //subject = new ConcreteSubject();

            //Registered users
            registeredUsers = new string[] { "Admin", "Rohit", "Sam" };
            this.currentUser = currentUser;
        }
        public override void DoSomeWork()
        {            
            Console.WriteLine($"{currentUser} wants to access into the system.");            
            if (registeredUsers.Contains(currentUser))
            {
                Console.WriteLine($"Welcome, {currentUser}.");
                //Lazy initialization: We'll not instantiate until the method is called through an authorized user.
                if (subject == null)
                {
                    subject = new ConcreteSubject();
                }
                subject.DoSomeWork();
            }
            else
            {
                Console.WriteLine($"Sorry {currentUser}, you do not have access into the system.");
            }
        }
    }
    /// <summary>
    /// Client class
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Proxy Pattern Demo2.***\n");
            //Authorized user-Admin
            Subject proxy = new Proxy("Admin");
            proxy.DoSomeWork();
            //Authorized user-Sam
            proxy = new Proxy("Sam");
            proxy.DoSomeWork();
            //Unauthorized User-Robin
            proxy = new Proxy("Robin");
            proxy.DoSomeWork();
            Console.ReadKey();
        }
    }
}
