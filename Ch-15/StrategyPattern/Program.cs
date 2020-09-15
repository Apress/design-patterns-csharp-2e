
using System;

namespace StrategyPattern
{
    /// <summary>
    /// Abstract Behavior
    /// </summary>
    public abstract class VehicleBehavior
    {
        public abstract void AboutMe(string vehicle);
    }
    /// <summary>
    /// Floating capability
    /// </summary>
    class FloatBehavior : VehicleBehavior
    {
        public override void AboutMe(string vehicle)
        {
            Console.WriteLine($"My {vehicle} can float now.");
        }
    }
    /// <summary>
    /// Flying capability
    /// </summary>
    class FlyBehavior : VehicleBehavior
    {
        public override void AboutMe(string vehicle)
        {
            Console.WriteLine($"My {vehicle} can fly now.");
        }
    }
    /// <summary>
    /// Initial behavior.Cannot do anything special.
    /// </summary>
    class InitialBehavior : VehicleBehavior
    {
        public override void AboutMe(string vehicle)
        {
            Console.WriteLine($"My {vehicle} is just born.It cannot do anything special.");
        }
    }
    /// <summary>
    /// Context class-Vehicle
    /// </summary>
    public class Vehicle
    {
        VehicleBehavior behavior;
        string vehicleType;
        public Vehicle(string vehicleType)
        {
            this.vehicleType = vehicleType;
            //Setting the initial behavior
            this.behavior = new InitialBehavior();
        }
        /*
         * It's your choice. You may prefer to use a setter
         * method instead of using a constructor. 
         * You can call this method whenever we want
         * to change the "vehicle behavior" on the fly.
         */
        public void SetVehicleBehavior(VehicleBehavior behavior)
        {
            this.behavior = behavior;
        }
        /* 
         This method will help us to delegate the behavior to
         the object referenced by vehicle.You do not know about
         the object type, but you simply know that this object can
         tell something about it, i.e. "AboutMe()" method
        */
        public void DisplayAboutMe()
        {
            behavior.AboutMe(vehicleType);
        }
    }
    /// <summary>
    /// Client code
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Strategy Pattern Demo.***\n");
            Vehicle context = new Vehicle("Aeroplane");
            context.DisplayAboutMe();
            Console.WriteLine("Setting  flying capability to vehicle.");
            context.SetVehicleBehavior(new FlyBehavior());
            context.DisplayAboutMe();
           
            Console.WriteLine("Changing the vehicle behavior again.");
            context.SetVehicleBehavior(new FloatBehavior());
            context.DisplayAboutMe();

            Console.ReadKey();
        }
    }
}

