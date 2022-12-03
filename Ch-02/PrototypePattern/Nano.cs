//Nano.cs
//using System;

namespace PrototypePattern
{
    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
            // Setting a base price for Nano.
            basePrice = 100000;
        }
        public override BasicCar Clone()
        {
            // Creating a shallow copy and returning it.
            return this.MemberwiseClone() as Nano;
        }
    }
}

