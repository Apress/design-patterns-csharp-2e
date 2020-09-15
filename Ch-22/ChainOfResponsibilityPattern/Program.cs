using System;

namespace ChainOfResponsibilityPattern
{
    /// <summary>
    /// Message priorities
    /// </summary>
    public enum MessagePriority
    {
        Normal,
        High
    }
    /// <summary>
    /// Message class
    /// </summary>
    public class Message
    {
        public string Text { get; set; }
        public MessagePriority Priority;
        public Message(string msg, MessagePriority priority)
        {
            this.Text = msg;
            this.Priority = priority;
        }
    }
    /// <summary>
    /// Abstract class -Receiver
    /// The abstract class is chosen to share 
    /// the common codes across derived classes.
    /// </summary>
    abstract class Receiver
    {
        protected Receiver nextReceiver;
        //To set the next handler in the chain.
        public void NextReceiver(Receiver nextReceiver)
        {
            this.nextReceiver = nextReceiver;
        }
        public abstract void HandleMessage(Message message);
    }
    /// <summary>
    /// FaxErrorHandler class
    /// </summary>
    class FaxErrorHandler : Receiver
    {
        bool messagePassedToNextHandler = false;
        public override void HandleMessage(Message message)
        {
            //Start processing if the error message contains "fax"
            if (message.Text.Contains("fax"))
            {
                Console.WriteLine($"FaxErrorHandler processed {message.Priority} priority issue: {message.Text}");
                //Do not leave now, if the error message contains email too.
                if (nextReceiver != null && message.Text.Contains("email"))
                {
                    Console.WriteLine("I've fixed fax side defect.Now email team needs to work on top of this fix.");
                    nextReceiver.HandleMessage(message);
                    //We'll not pass the message repeatedly to next handler.
                    messagePassedToNextHandler = true;
                }
            }
            if (nextReceiver != null && messagePassedToNextHandler != true)
            {
                nextReceiver.HandleMessage(message);
            }           
        }
    }
    /// <summary>
    /// EmailErrorHandler class
    /// </summary>
    class EmailErrorHandler : Receiver
    {
        bool messagePassedToNextHandler = false;
        public override void HandleMessage(Message message)
        {
            //Start processing if the error message contains "email"
            if (message.Text.Contains("email"))
            {
                Console.WriteLine($"EmailErrorHandler processed {message.Priority} priority issue: {message.Text}");
                //Do not leave now, if the error message contains "fax" too.
                if (nextReceiver != null && message.Text.Contains("fax"))
                {
                    Console.WriteLine("Email side defect is fixed.Now fax team needs to cross verify this fix.");
                    //Keeping the following code here.
                    //It can be useful if you place this handler before fax error handler
                     nextReceiver.HandleMessage(message);
                    //We'll not pass the message repeatedly to the next handler.
                    messagePassedToNextHandler = true;
                }
            }
            if (nextReceiver != null && messagePassedToNextHandler != true)
            {
                nextReceiver.HandleMessage(message);
            }           
        }
    }
    /// <summary>
    /// UnknownErrorHandler class
    /// </summary>
    class UnknownErrorHandler : Receiver
    {
        public override void HandleMessage(Message message)
        {
            if (!(message.Text.Contains("fax") || message.Text.Contains("email")))
            {
                Console.WriteLine("Unknown error occurs.Consult experts immediately.");
            }
            else if (nextReceiver != null)
            {
                nextReceiver.HandleMessage(message);
            }
        }
    }
    /// <summary>
    /// Client code
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Chain of Responsibility Pattern Demo***\n");

            //Different handlers
            Receiver emailHandler = new EmailErrorHandler();
            Receiver faxHandler = new FaxErrorHandler();
            Receiver unknownHandler = new UnknownErrorHandler();
            /* 
            Making the chain :
            FaxErrorhandler->EmailErrorHandler->UnknownErrorHandler.
            */
            faxHandler.NextReceiver(emailHandler);
            emailHandler.NextReceiver(unknownHandler);

            Message msg = new Message("The fax is reaching late to the destination.", MessagePriority.Normal);
            faxHandler.HandleMessage(msg);
            msg = new Message("The emails are not reaching to the destinatinations.", MessagePriority.High);
            faxHandler.HandleMessage(msg);
            msg = new Message("In email, CC field is disabled always.", MessagePriority.Normal);
            faxHandler.HandleMessage(msg);
            msg = new Message("The fax is not reaching to the destination.", MessagePriority.High);
            faxHandler.HandleMessage(msg);
            msg = new Message("Cannot login  into the system.", MessagePriority.High);
            faxHandler.HandleMessage(msg);
            msg = new Message("Neither fax nor email are working.", MessagePriority.High);
            faxHandler.HandleMessage(msg);
            Console.ReadKey();
        }
    }
}
