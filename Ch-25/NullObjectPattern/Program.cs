using System;
//using System.Collections.Generic;//Use it when you List<IVehicle>

namespace NullObjectPattern
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
            Console.WriteLine("Let us travel with Bus.");
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
            Console.WriteLine("Let us travel with Train.");
        }
    }
    /// <summary>
    /// NullVehicle class
    /// </summary>
    class NullVehicle : IVehicle
    {
        private static readonly NullVehicle instance = new NullVehicle();
        private NullVehicle()
        {
            nullVehicleCount++;
        }

        public static int nullVehicleCount;
        public static NullVehicle Instance
        {
            get
            {
                return instance;
            }
        }
        public void Travel()
        {
            //Do Nothing
        }
    }
    /// <summary>
    /// Client code
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Null Object Pattern Demonstration.***\n");
            string input = String.Empty;
            int totalObjects = 0;

            while (input != "exit")
            {
                Console.WriteLine("Enter your choice( Type 'a' for Bus, 'b' for Train.Type 'exit' to quit) ");
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
                        Console.WriteLine("Closing the application.");
                        vehicle = NullVehicle.Instance;
                        break;
                    default:
                        Console.WriteLine("Please supply the correct input(a/b/exit)");
                        vehicle = NullVehicle.Instance;                       
                        break;
                }
                totalObjects = Bus.busCount + Train.trainCount + NullVehicle.nullVehicleCount;
                //No need to do null check now.
                //if (vehicle != null)
                vehicle.Travel();
                //}
                Console.WriteLine("Total objects created in the system ={0}",
                totalObjects);

            }
            ////A case study
            ////Another context
            //List<IVehicle> vehicleList = new List<IVehicle>();
            //vehicleList.Add(new Bus());
            //vehicleList.Add(new Train());
            ////vehicleList.Add(null);
            //vehicleList.Add(NullVehicle.Instance);

            //foreach (IVehicle vehicle in vehicleList)
            //{
            //    vehicle.Travel();
            //}

            Console.ReadKey();
        }
    }
}
