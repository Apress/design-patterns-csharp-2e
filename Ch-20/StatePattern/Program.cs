using System;
namespace StatePattern
{
    interface IPossibleStates
    {
        //Users can press any of these buttons-On, Off or Mute
        void PressOnButton(TV context);
        void PressOffButton(TV context);
        void PressMuteButton(TV context);
    }
    //Subclasses does not contain any local state.
    //Only one unique instance of IPossibleStates is required.
    /// <summary>
    /// Off state behavior
    /// </summary>
    class Off : IPossibleStates
    {    
        public Off()
        {
            Console.WriteLine("---TV is Off now.---\n");            
        }
        
        //TV is Off now, user is pressing On button
        public void PressOnButton(TV context)
        {
            Console.WriteLine("TV was Off.Going from Off to On state.");
            context.CurrentState = new On();
        }
        //TV is Off already, user is pressing Off button again
        public void PressOffButton(TV context)
        {
            Console.WriteLine("TV was already in Off state.So, ignoring this opeation.");
        }
        //TV is Off now, user is pressing Mute button
        public void PressMuteButton(TV context)
        {
            Console.WriteLine("TV was already off.So, ignoring this operation.");
        }
    }
    /// <summary>
    /// On state behavior
    /// </summary>
    class On : IPossibleStates
    {
       public On()
        {
            Console.WriteLine("---TV is On now.---\n");            
        }
        //Users can press any of these buttons at this state-On, Off or Mute
        //TV is On already, user is pressing On button again
        public void PressOnButton(TV context)
        {
            Console.WriteLine("TV is already in On state.Ignoring repeated on button press operation.");
        }
        //TV is On now, user is pressing Off button
        public void PressOffButton(TV context)
        {
            Console.WriteLine("TV was on.So,switching off the TV.");
            context.CurrentState = new Off();
        }
        //TV is On now, user is pressing Mute button
        public void PressMuteButton(TV context)
        {
            Console.WriteLine("TV was on.So,moving to silent mode.");
            context.CurrentState = new Mute();
        }
    }
    /// <summary>
    /// Mute state behavior
    /// </summary>
    class Mute : IPossibleStates
    {
        
        public Mute()
        {
            Console.WriteLine("---TV is in Mute mode now.---\n");            
        }
        //Users can press any of these buttons at this state-On, Off or Mute
        //TV is in mute, user is pressing On button
        public void PressOnButton(TV context)
        {
            Console.WriteLine("TV was in mute mode.So, moving to normal state.");
            context.CurrentState = new On();
        }
        //TV is in mute, user is pressing Off button
        public void PressOffButton(TV context)
        {
            Console.WriteLine("TV was in mute mode. So, switching off the TV.");
            context.CurrentState = new Off();
        }
        //TV is in mute already, user is pressing mute button again
        public void PressMuteButton(TV context)
        {
            Console.WriteLine(" TV is already in Mute mode, so, ignoring this operation.");
        }
    }
    /// <summary>
    /// TV is the context class
    /// </summary>
    class TV
    {
        private IPossibleStates currentState;
        public IPossibleStates CurrentState
        {
            get
            {
                return currentState;
            }
            /*
             * Usually this value will be set by the class that
              implements the interface "IPossibleStates"
              */
            set
            {
                currentState = value;
            }
        }
        public TV()
        {
            //Starting with Off state
            this.currentState = new Off();
        }
        public void ExecuteOffButton()
        {
           Console.WriteLine("You pressed Off button.");
            //Delegating the state behavior
            currentState.PressOffButton(this);
        }
        public void ExecuteOnButton()
        {
            Console.WriteLine("You pressed On button.");
            //Delegating the state behavior
            currentState.PressOnButton(this);
        }
        public void ExecuteMuteButton()
        {
            Console.WriteLine("You pressed Mute button.");
            //Delegating the state behavior
            currentState.PressMuteButton(this);
        }
    }
    /// <summary>
    /// Client code
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***State Pattern Demo***\n");
            //TV is initialized with Off state.
            TV tv = new TV();
            Console.WriteLine("User is pressing buttons in the following sequence:");
            Console.WriteLine("Off->Mute->On->On->Mute->Mute->Off\n");
            //TV is already in Off state
            tv.ExecuteOffButton();
            //TV is already in Off state, still pressing the Mute button
            tv.ExecuteMuteButton();
            //Making the TV on
            tv.ExecuteOnButton();
            //TV is already in On state, pressing On button again
            tv.ExecuteOnButton();
            //Putting the TV in Mute mode
            tv.ExecuteMuteButton();
            //TV is already in Mute, pressing Mute button again
            tv.ExecuteMuteButton();
            //Making the TV off
            tv.ExecuteOffButton();
            // Wait for user
            Console.Read();
        }
    }
}
