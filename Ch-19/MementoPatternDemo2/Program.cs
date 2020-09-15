using System;
using System.Collections.Generic;

namespace MementoPatternDemo2
{   
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
        static Originator.Memento currentMemento;
        static void Main(string[] args)
        {
            Console.WriteLine("***Memento Pattern Demonstration-2.***");
            Console.WriteLine("Originator (with nested internal class 'Memento') is maintained in a separate file.\n");
            //Originator is initialized.The constructor will create a born state.
            originatorObject = new Originator();            
            //Cannot create memento inside client code now
            //currentMemento = new Originator.Memento();//error:inaccessible
            //currentMemento.State = "test";//Also error, because previous line cannot be used

            IList<Originator.Memento> savedStates = new List<Originator.Memento>();
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
            foreach (Originator.Memento m in savedStates)
            {
                Console.WriteLine(m.State);
            }

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
