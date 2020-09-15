using System;
using System.Collections.Generic;

namespace MementoPattern
{
    /// <summary>
    /// Memento class
    /// As per GoF:
    /// 1.A Memento object stores the snapshot of Originator's internal state.
    /// 2.Ideally,only the originator that created a memento is allowed to access it.
    /// </summary>
    class Memento
    {
        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        /*
        C#3.0 onwards, you can use
        automatic properties as follows:
        public string State { get; set; }
        */        

    }

    /// <summary>
    ///  Originator class
    ///  As per GoF:
    ///  1.It creates a memento that contains a snapshot of its current internal state.
    ///  2.It uses a memento to restore its internal state.
    /// </summary>    
    class Originator
    {
        private string state;
        Memento myMemento;
        public Originator()
        {
            //Creating a memento with born state.
            state = "Snapshot #0.(Born state)";
            Console.WriteLine($"Originator's current state is: {state}");            
            
        }
        public string State
        {
            get { return state; }
            set
            {
                state = value;           
                Console.WriteLine($"Originator's current state is: {state}");
            }
        }

        /* 
        Originator will supply the memento
        (which contains it's current state)
        in respond to caretaker's request.
        */
        public Memento CurrentMemento()
        {
            myMemento = new Memento();
            myMemento.State = state;
            return myMemento;
        }

        // Back to an old state (Restore)
        public void RestoreMemento(Memento restoreMemento)
        {
            this.state = restoreMemento.State;
            Console.WriteLine("Restored to state : {0}", state);
        }
    }

    /// <summary>
    /// The 'Caretaker' class.
    /// As per GoF:
    /// 1.This class is responsible for memento's safe-keeping.
    /// 2.Never operates or Examines the content of a Memento.
    
    /// Additional notes( for your reference):
    ///The originator object has an internal state, and a client
    ///can set a state in it.A client(or, caretaker) requests a 
    ///memento from the originator to save the current internal state of the originator).
    ///It can also pass a memento back to the originator to restore
    ///it to a previous state that the memento holds in it.
    ///This enables to save and restore the internal state of an 
    ///originator without violating its encapsulation.
    /// </summary>      

    class Client
    {
        static Originator originatorObject;
        static Memento currentMemento;
        static void Main(string[] args)
        {
            Console.WriteLine("***Memento Pattern Demonstration-1.***\n");            
            //Originator is initialized.The constructor will create a born state.
            originatorObject = new Originator();
            ////For Q&A session only(Shouldn't be used)
            //currentMemento = new Memento();
            //currentMemento.State = "Arbitrary state set by caretaker";
            
            IList<Memento> savedStates = new List<Memento>();
            /* 
             Adding a memento the list.This memento stores
             the current state of the Origintor.
            */
            savedStates.Add(originatorObject.CurrentMemento());

            //Snapshot #1.
            originatorObject.State = "Snapshot #1";
            //Adding this memento as a  restore point            
             savedStates.Add(originatorObject.CurrentMemento());
           

            //Snapshot #2.
            originatorObject.State = "Snapshot #2";
            //Adding this memento as a  restore point            
            savedStates.Add(originatorObject.CurrentMemento());

            //Snapshot #3.
            originatorObject.State = "Snapshot #3";
            //Adding this memento as a  restore point            
            savedStates.Add(originatorObject.CurrentMemento());

            //Snapshot #4. It is not added as a restore point.
            originatorObject.State = "Snapshot #4";

            //Available restore points
            Console.WriteLine("\nCurrently available restore points are :");
            foreach (Memento m in savedStates)
            {
                Console.WriteLine(m.State);
            }
            ////Directly going back to Snapshot #2
            //currentMemento = savedStates[2];
            //originatorObject.RestoreMemento(currentMemento);          

            //Undo's
            //Roll back starts...            
            Console.WriteLine("\nPeforming undo's now.");
            for (int i = savedStates.Count; i > 0; i--)
            {
                //Get a restore point
                currentMemento = savedStates[i - 1];
                originatorObject.RestoreMemento(currentMemento);
            }
            //Redo's
            Console.WriteLine("\nPeforming redo's now.");
            for (int i = 1; i < savedStates.Count; i++)
            {
                currentMemento = savedStates[i];
                originatorObject.RestoreMemento(currentMemento);
            }
            // Wait for user
            Console.ReadKey();
        }
    }
}
