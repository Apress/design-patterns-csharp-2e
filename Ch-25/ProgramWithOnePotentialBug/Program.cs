using System;

namespace ProgramWithOnePotentialBug
{
    interface IVehicle
    {
        void Travel();
    }
    /// <summary>
    /// Bus class
    /// </summary>
    class Bus : IVehicle
    {
        public static int busCount = 0;
        public Bus()
        {
            busCount++;
        }
        public void Travel()
        {
            Console.WriteLine("Let us travel with Bus");
        }
    }
    /// <summary>
    /// Train class
    /// </summary>
    class Train : IVehicle
    {
        public static int trainCount = 0;
        public Train()
        {
            trainCount++;
        }
        public void Travel()
        {
            Console.WriteLine("Let us travel with Train");
        }
    }
    /// <summary>
    /// Client code
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***This program demonstrates the need of null object pattern.***\n");
            string input = String.Empty;
            int totalObjects = 0;

            while (input != "exit")
            {
                Console.WriteLine("Enter your choice(Type 'a' for Bus, 'b' for Train.Type 'exit' to quit application.");
                input = Console.ReadLine();
                IVehicle vehicle = null;
                switch (input)
                {
                    case "a":
                        vehicle = new Bus();
                        break;
                    case "b":
                        vehicle = new Train();
                        break;
                    case "exit":
                        Console.WriteLine("Creating one more bus and closing the application");
                        vehicle = new Bus();
                        break;
                }
                totalObjects = Bus.busCount + Train.trainCount;
                //vehicle.Travel();
                //Using null conditional operator
                //C#6.0 onwards
                vehicle?.Travel();//it will work
                Console.WriteLine($"Total objects created in the system ={totalObjects}");
            }
        }
    }
}
