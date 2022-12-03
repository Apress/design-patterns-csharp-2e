// Ford.cs

namespace PrototypePattern
{
    public class Ford : BasicCar
    {
        public Ford(string m)
        {
            ModelName = m;
            // Setting a basic price for Ford. 
            basePrice = 500000;
        }

        public override BasicCar Clone()
        {
            // Creating a shallow copy and returning it.
            return this.MemberwiseClone() as Ford;
        }
    }
}

