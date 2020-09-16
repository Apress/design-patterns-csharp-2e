using System;

namespace MementoPatternDemo2
{
    /// <summary>
    ///  Originator class
    ///  As per GoF:
    ///  1.It creates a memento that contains a snapshot of its current internal state.
    ///  2.It uses a memento to restore its internal state.
    /// </summary>    
    class Originator
    {
        private string state;
        //Memento myMemento;//not needed now
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
            //Code segment used in Demonstration-1
            //myMemento = new Memento();//error now, because of private constructor
            //myMemento.State = state;
            //return myMemento;

            //Modified code for Demonstration-2
            return new Memento(this.State);
        }

        // Back to an old state (Restore)
        public void RestoreMemento(Memento restoreMemento)
        {
            this.state = restoreMemento.State;
            //Console.WriteLine("Restored to state : {0}", state);
            Console.WriteLine($"Restored to state : {state}");
        }
        /// <summary>
        /// Memento class
        /// As per GoF:
        /// 1.A Memento object stores the snapshot of Originator's internal state.
        /// 2.Ideally,only the originator that created a memento is allowed to access it.
        /// </summary>
        internal class Memento        
        {
            private string state;
            //Now Memento class cannot be initialized outside
            private Memento() { }
            public Memento(string state)
            {
                this.state = state;
            }
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
        }

    }
}
