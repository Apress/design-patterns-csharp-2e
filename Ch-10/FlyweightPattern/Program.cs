using System;
using System.Collections.Generic;//Dictionary is used here

namespace FlyweightPattern
{
    /// <summary>
    /// The 'Flyweight' interface
    /// </summary>
    interface IVehicle
    {
        /*
         * Client will supply the color.
         * It is extrinsic state.
        */
        void AboutMe(string color);
    }
    /// <summary>
    /// A 'ConcreteFlyweight' class called Car
    /// </summary>
    class Car : IVehicle
    {
        /*
         * It is intrinsic state and 
         * it is independent of flyweight context.
         * this can be shared.So, our factory method will supply
         * this value inside the flyweight object.
         */
        private string description;
        /*
         * Flyweight factory will supply this 
         * inside the flyweight object.
        */
        public Car(string description)
        {
            this.description = description;
        }
        //Client will supply the color
        public void AboutMe(string color)
        {
            Console.WriteLine($"{description} with {color} color.");
        }
    }
    /// <summary>
    /// A 'ConcreteFlyweight' class called Bus
    /// </summary>
    class Bus : IVehicle
    {
        /*
         * It is intrinsic state and 
         * it is independent of flyweight context.
         * this can be shared.So, our factory method will supply
         * this value inside the flyweight object.
         */
        private string description;
        public Bus(string description)
        {
            this.description = description;
        }
        //Client will supply the color
        public void AboutMe(string color)
        {
            Console.WriteLine($"{description} with {color} color.");
        }
    }
    /// <summary>
    /// A 'ConcreteFlyweight' class called FutureVehicle 
    /// </summary>
    class FutureVehicle : IVehicle
    {
        /*
         * It is intrinsic state and 
         * it is independent of flyweight context.
         * this can be shared.So, our factory method will supply
         * this value inside the flyweight object.
         */
        private string description;
        public FutureVehicle(string description)
        {
            this.description = description;
        }
        //Client cannot choose color for FutureVehicle
        //since it's unshared flyweight,ignoring client's input
        public void AboutMe(string color)
        {
            Console.WriteLine($"{description} with blue color.");
        }
    }

    /// <summary>
    /// The factory class for flyweights.
    /// </summary>
    class VehicleFactory
    {
        private Dictionary<string, IVehicle> vehicles = new Dictionary<string, IVehicle>();
        /*
          * To count different types of vehicles
          * in a given moment.
         */
        public int TotalObjectsCreated
        {
            get
            {
                return vehicles.Count;
            }
        }

        public IVehicle GetVehicleFromVehicleFactory(string vehicleType)
        {
            IVehicle vehicleCategory = null;
            if (vehicles.ContainsKey(vehicleType))
            {
                vehicleCategory = vehicles[vehicleType];

            }
            else
            {
                switch (vehicleType)
                {
                    case "car":
                        vehicleCategory = new Car("One car is created");
                        vehicles.Add("car", vehicleCategory);
                        break;
                    case "bus":
                        vehicleCategory = new Bus("One bus is created");
                        vehicles.Add("bus", vehicleCategory);
                        break;
                    case "future":
                        vehicleCategory = new FutureVehicle("Vehicle 2050 is created");
                        vehicles.Add("future", vehicleCategory);
                        break;
                    default:
                        throw new Exception("Vehicle Factory can give you cars and buses only.");
                }

            }
            return vehicleCategory;
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Flyweight Pattern Demo.***\n");
            VehicleFactory vehiclefactory = new VehicleFactory();
            IVehicle vehicle;
            /*
            * Now we are trying to get the 3 cars.Note that:we need not 
            * create additional cars if we have already created one of this category.
            */
            for (int i = 0; i < 3; i++)
            {
                vehicle = vehiclefactory.GetVehicleFromVehicleFactory("car");
                vehicle.AboutMe(GetRandomColor());
            }
            int numOfDistinctRobots = vehiclefactory.TotalObjectsCreated;
            Console.WriteLine($"\n Now, total numbers of distinct vehicle object(s) is = {numOfDistinctRobots}\n");
            /*
            * Here we are trying to get the 5 more buses.Note that: we need not create 
            * additional buses if we have already created one of this category. 
            */
            for (int i = 0; i < 5; i++)
            {
                vehicle = vehiclefactory.GetVehicleFromVehicleFactory("bus");
                vehicle.AboutMe(GetRandomColor());
            }
            numOfDistinctRobots = vehiclefactory.TotalObjectsCreated;
            Console.WriteLine($"\n Now, total numbers of distinct vehicle object(s) is = {numOfDistinctRobots}\n");
            /*
             * Here we are trying to get the 2 future vehicles.Note that: we need not create 
             * additional future vehicle if we have already created one of this category. 
             */
            for (int i = 0; i < 2; i++)
            {
                vehicle = vehiclefactory.GetVehicleFromVehicleFactory("future");
                vehicle.AboutMe(GetRandomColor());
            }
            numOfDistinctRobots = vehiclefactory.TotalObjectsCreated;
            Console.WriteLine($"\n Now, total numbers of distinct vehicle object(s) is = {numOfDistinctRobots}\n");


            Console.ReadKey();
        }

        private static string GetRandomColor()
        {
            Random r = new Random();
            /*You can supply any number of your choice in nextInt argument.
             * we are simply checking the random number generated is an 
             * even number  or an odd number. And based on that we are 
             * choosing the color. For simplicity, we'll use only two 
             * colors-red and green.
             */
            int random = r.Next(100);
            if (random % 2 == 0)
            {
                return "red";
            }
            else
            {
                return "green";
            }
        }
    }
}

