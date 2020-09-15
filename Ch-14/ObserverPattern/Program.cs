using System;
//We have used List<Observer> here
using System.Collections.Generic;
namespace ObserverPattern
{
    interface IObserver
    {
        void Update(ICelebrity subject);
    }
    class ObserverType1 : IObserver
    {
        string nameOfObserver;
        public ObserverType1(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(ICelebrity celeb)
        {
            Console.WriteLine($"{nameOfObserver} has received an alert from {celeb.Name}.Updated value is: {celeb.Flag}");
        }
    }
    class ObserverType2 : IObserver
    {
        string nameOfObserver;
        public ObserverType2(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(ICelebrity celeb)
        {
            Console.WriteLine($"{nameOfObserver} notified.Inside {celeb.Name}, the updated value is: {celeb.Flag}");
        }
    }

    interface ICelebrity
    {
        //Name of Subject
        string Name { get; }
        int Flag { get; set; }
        //To register
        void Register(IObserver o);
        //To Unregister
        void Unregister(IObserver o);
        //To notify registered users        
        void NotifyRegisteredUsers();

    }
    class Celebrity : ICelebrity
    {

        List<IObserver> observerList = new List<IObserver>();
        private int flag;
        public int Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
                //Flag value changed. So notify observer(s).
                NotifyRegisteredUsers();
            }
        }
        private string name;
        public Celebrity(string name)
        {
            this.name = name;
        }
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }           
        //}
        //Or, simply use expression bodied 
        //properties(C#6.0 onwards)
        public string Name => name;

        //To register an observer.
        public void Register(IObserver anObserver)
        {
            observerList.Add(anObserver);
        }
        //To unregister an observer.
        public void Unregister(IObserver anObserver)
        {
            observerList.Remove(anObserver);
        }
        //Notify all registered observers.
        public void NotifyRegisteredUsers()
        {            
            foreach (IObserver observer in observerList)
            {
                observer.Update(this);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Observer Pattern Demonstration.***\n");
            //We have 4 observers-2 of them are ObserverType1, 1  is of ObserverType2
            IObserver myObserver1 = new ObserverType1("Roy");
            IObserver myObserver2 = new ObserverType1("Kevin");
            IObserver myObserver3 = new ObserverType2("Bose");
            IObserver myObserver4 = new ObserverType2("Jacklin");
            Console.WriteLine("Working with first celebrity now.");
            ICelebrity celebrity = new Celebrity("Celebrity-1");
            //Registering the observers-Roy,Kevin,Bose
            celebrity.Register(myObserver1);
            celebrity.Register(myObserver2);
            celebrity.Register(myObserver3);
            Console.WriteLine(" Celebrity-1 is setting Flag = 5.");
            celebrity.Flag = 5;
            /*
            Kevin doesn't want to get further notification.
            So, unregistering the observer(Kevin)).
            */
            Console.WriteLine("\nCelebrity-1 is removing Kevin from the observer list now.");
            celebrity.Unregister(myObserver2);            
            //No notification is sent to Kevin this time. He has unregistered.
            Console.WriteLine("\n Celebrity-1 is setting Flag = 50.");
            celebrity.Flag = 50;
            //Kevin is registering himself again
            celebrity.Register(myObserver2);
            Console.WriteLine("\n Celebrity-1 is setting Flag = 100.");
            celebrity.Flag = 100;

            Console.WriteLine("\n Working with another celebrity now.");
            //Creating another celebrity
            ICelebrity celebrity2 = new Celebrity("Celebrity-2");
            //Registering the observers-Roy and Jacklin
            celebrity2.Register(myObserver1);
            celebrity2.Register(myObserver4);
            Console.WriteLine("\n --Celebrity-2 is setting Flag value as 500.--");
            celebrity2.Flag = 500;

            Console.ReadKey();
        }
    }
}
