using System;

namespace PrototypePatternDemo2
{
    /// <summary>
    /// BasicCar class
    /// </summary>
    public abstract class BasicCar
    {
        public int basePrice = 0, onRoadPrice = 0;
        public string ModelName { get; set; }

        /*
        We'll add this price before the final calculation 
        of onRoadPrice.
        */

        public static int SetAdditionalPrice()
        {
            Random random = new Random();
            int additionalPrice = random.Next(200000, 500000);
            return additionalPrice;
        }
        public abstract BasicCar Clone();
    }
    /// <summary>
    /// Nano class
    /// </summary>
    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
            //Setting a basic price for Nano
            basePrice = 100000;
        }
        public override BasicCar Clone()
        {
            //Creating a shallow copy and returning it
            return this.MemberwiseClone() as Nano;
        }
    }
    /// <summary>
    /// Ford class
    /// </summary>
    public class Ford : BasicCar
    {
        public Ford(string m)
        {
            ModelName = m;
            //Setting a basic price for Ford 
            basePrice = 500000;
        }

        public override BasicCar Clone()
        {
            //Creating a shallow copy and returning it
            return this.MemberwiseClone() as Ford;
        }
    }

    /// <summary>
    /// For Modified version
    /// CarFactory class
    /// </summary>
   
    class CarFactory
    {
        private BasicCar nano, ford;
        //private readonly BasicCar nano, ford;

        //public CarFactory()
        //{
        //    //nano = new Nano("Green Nano");
        //    //ford = new Ford("Ford Yellow");
        //}
        public BasicCar GetNano()
        {
            //return  nano.Clone();
            if (nano != null)
            {
                // Nano was created earlier.
                // Returning a clone of it.
                return nano.Clone();
            }
            else
            {
                /*
                  Create a nano for the first 
                  time and return it.
                */
                nano = new Nano("Green Nano");
                return nano;
            }
        }
        public BasicCar GetFord()
        {
            // return ford.Clone();
            if (ford != null)
            {
                // Ford was created earlier.
                // Returning a clone of it.
                return ford.Clone();
            }
            else
            {
                /*
                  Create a nano for the first 
                  time and return it.
                */
                ford = new Ford("Ford Yellow");
                return ford;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Prototype Pattern Demo2.***\n");            
            CarFactory carFactory = new CarFactory();
            //Get a Nano
            BasicCar basicCar = carFactory.GetNano();
            //Working on cloned copy
            basicCar.onRoadPrice = basicCar.basePrice + BasicCar.SetAdditionalPrice();
            Console.WriteLine($"Car is: {basicCar.ModelName}, and it's price is Rs. {basicCar.onRoadPrice}");

            //Get a Ford now           
            basicCar = carFactory.GetFord();
            //Working on cloned copy
            basicCar.onRoadPrice = basicCar.basePrice + BasicCar.SetAdditionalPrice();
            Console.WriteLine($"Car is: {basicCar.ModelName}, and it's price is Rs. {basicCar.onRoadPrice}");

            Console.ReadLine();
        }
    }

}

