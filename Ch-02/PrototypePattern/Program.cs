// Client

using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Prototype Pattern Demo***\n");
            //Base or Original Copy
            BasicCar nano = new Nano("Green Nano");
            BasicCar ford = new Ford("Ford Yellow");

            //Console.WriteLine("Before clone, base prices:");
            //Console.WriteLine($"Car is: {nano.ModelName}, and it's base price is Rs. {nano.basePrice}");
            //Console.WriteLine($"Car is: {ford.ModelName}, and it's base price is Rs. {ford.basePrice}");

            BasicCar basicCar;
            // Nano
            basicCar = nano.Clone();
            // Working on cloned copy
            basicCar.onRoadPrice = basicCar.basePrice + BasicCar.SetAdditionalPrice();
            Console.WriteLine($"Car is: {basicCar.ModelName}, and it's price is Rs. {basicCar.onRoadPrice}");

            // Ford            
            basicCar = ford.Clone();
            // Working on cloned copy
            basicCar.onRoadPrice = basicCar.basePrice + BasicCar.SetAdditionalPrice();
            Console.WriteLine($"Car is: {basicCar.ModelName}, and it's price is Rs. {basicCar.onRoadPrice}");           
            Console.ReadLine();
        }
    }
}

