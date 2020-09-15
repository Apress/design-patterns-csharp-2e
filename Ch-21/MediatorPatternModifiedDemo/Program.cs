using System;
using System.Collections.Generic;

namespace MediatorPatternModifiedDemo
{
    interface IMediator
    {
        //To register a friend
        void Register(AbstractFriend friend);
        //To send a message from one friend to another friend
        void Send(AbstractFriend fromFriend, AbstractFriend toFriend, string msg);
        //To display currently registered objects/friends.
        void DisplayDetails();
    }
    // ConcreteMediator
    class ConcreteMediator : IMediator
    {
        //List of friends
        List<AbstractFriend> participants = new List<AbstractFriend>();
        public void Register(AbstractFriend friend)
        {
            participants.Add(friend);
        }
        public void DisplayDetails()
        {
            Console.WriteLine("Current list of registered participants is as follows:");
            foreach (AbstractFriend friend in participants)
            {

                Console.WriteLine($"{friend.Name}");
            }
        }
        /* 
         The mediator allows only registered users 
         to communicate each other and post messages
         successfully. So, the following method  
         checks whether both the sender and receiver
         are registered users or not. 
         */
        public void Send(AbstractFriend fromFriend, AbstractFriend toFriend, string msg)
        {
            /* Verifying whether the sender is a registered user or not. */
            if (participants.Contains(fromFriend))           
            {
                /* Verifying whether the receiver is a registered user and he is online.*/
                if (participants.Contains(toFriend) && toFriend.Status=="On")
                {
                    Console.WriteLine($"\n[{fromFriend.Name}] posts: {msg}Last message posted {DateTime.Now}");
                    System.Threading.Thread.Sleep(1000);
                    /*Target receiver will receive this message.*/
                    toFriend.ReceiveMessage(fromFriend, msg);
                }
                else
                {
                    Console.WriteLine($"\n{fromFriend.Name},at this moment,you cannot send message to {toFriend.Name} because he is either not a registered user or he is currently offline.");
                }
            }
            //Message sender is NOT a registered user.
            else
            {
                Console.WriteLine($"\nAn outsider named {fromFriend.Name} of [{fromFriend.GetType()}] is trying to send a message to {toFriend.Name}.");
            }
        }
    }
    /// <summary>
    /// AbstractFriend class
    /// Making it an abstract class, so that you cannot instantiate it directly.
    /// </summary>
    abstract class AbstractFriend
    {
        IMediator mediator;

        //Using auto property
        public string Name { get; set; }
        //New property for Demonstration 2
        public string Status { get; set; }

        // Constructor
        public AbstractFriend(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public void SendMessage(AbstractFriend toFriend, string msg)
        {
            mediator.Send(this, toFriend, msg);
        }
        public void ReceiveMessage(AbstractFriend fromFriend, string msg)
        {
            Console.WriteLine($"{this.Name} has received a message from {fromFriend.Name} saying: {msg} ");
        }
    }
    /// <summary>
    /// Friend class
    /// </summary>
    class Friend : AbstractFriend
    {
        // Constructor
        public Friend(IMediator mediator)
            : base(mediator)
        {

        }
    }
    /// <summary>
    /// Another class called Stranger
    /// </summary>  
    class Stranger : AbstractFriend
    {
        // Constructor
        public Stranger(IMediator mediator)
            : base(mediator)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Mediator Pattern Modified Demonstration.***\n");

            IMediator mediator = new ConcreteMediator();
            //AbstractFriend afriend = new AbstractFriend(mediator);//error

            //3 persons-Amit,Sohel,Joseph
            //Amit and Sohel from Friend class
            Friend friend1 = new Friend(mediator);
            friend1.Name = "Amit";
            friend1.Status = "On";
            Friend friend2 = new Friend(mediator);
            friend2.Name = "Sohel";
            friend2.Status = "On";
            //Joseph is from Stranger class
            Stranger stranger1 = new Stranger(mediator);
            stranger1.Name = "Joseph";
            stranger1.Status = "On";

            //Registering the participants
            mediator.Register(friend1);
            mediator.Register(friend2);
            mediator.Register(stranger1);

            //Displaying the participant's list
            mediator.DisplayDetails();

            Console.WriteLine("Communication starts among participants...");
            friend1.SendMessage(friend2, "Hi Sohel,can we discuss the mediator pattern?");
            friend2.SendMessage(friend1, "Hi Amit,Yup, we can discuss now.");
            stranger1.SendMessage(friend1, " How are you?");

            //Another friend who does not register to the mediator
            Friend friend4 = new Friend(mediator);
            friend4.Name = "Todd";
            //This message cannot reach Joseph, because Todd
            //is not the registered user.
            friend4.SendMessage(stranger1, "Hello Joseph...");

            // This message will NOT reach Todd because he
            //is not a registered user.
            friend1.SendMessage(friend4, "Hello Todd...");

            //An outsider tries to participate           
            Stranger stranger2 = new Stranger(mediator);
            stranger2.Name = "Jack";
            //mediator.Register(stranger1);
            //This message cannot reach Joseph, because Jack
            //is not the registered user.
            stranger2.SendMessage(stranger1, "Hello friend...");

            Console.WriteLine("Sohel is going to offline now.");
            friend2.Status = "Off";
            /* 
             Since Sohel is offline, he will NOT receive 
             this message.
             */
            friend1.SendMessage(friend2, "Hi Sohel, I have a gift for you.");
            Console.WriteLine("Sohel is online again.");
            friend2.Status = "On";
            stranger1.SendMessage(friend2, "Hi Sohel, Amit was looking for you.");

            // Wait for user
            Console.Read();
        }
    }
}
