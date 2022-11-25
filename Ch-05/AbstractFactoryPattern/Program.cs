using System;

namespace AbstractFactoryPattern
{
    //Abstract Factory
    public interface IAnimalFactory
    {
        IDog GetDog();
        ITiger GetTiger();
    }

    //Abstract Product-1
    public interface ITiger
    {
        void AboutMe();
    }
    //Abstract Product-2
    public interface IDog
    {
        void AboutMe();
    }

    //Concrete product-A1(WildTiger)
    class WildTiger : ITiger
    {
        public void AboutMe()
        {
            Console.WriteLine("Wild tiger says: I prefer hunting in jungles.Halum.");
        }
    }
    // Concrete product-B1(WildDog)
    class WildDog : IDog
    {
        public void AboutMe()
        {
            Console.WriteLine("Wild dog says: I prefer to roam freely in jungles.Bow-Wow.");
        }
    }

    // Concrete product-A2(PetTiger)
    class PetTiger : ITiger
    {
        public void AboutMe()
        {
            Console.WriteLine("Pet tiger says: Halum.I play in an animal circus.");
        }
    }

    // Concrete product-B2(PetDog)
    class PetDog : IDog
    {
        public void AboutMe()
        {
            Console.WriteLine("Pet dog says: Bow-Wow.I prefer to stay at home.");
        }
    }
    //Concrete Factory 1-Wild Animal Factory
    public class WildAnimalFactory : IAnimalFactory
    {

        public ITiger GetTiger()
        {
            return new WildTiger();
        }
        public IDog GetDog()
        {
            return new WildDog();
        }
    }
    //Concrete Factory 2-Pet Animal Factory
    public class PetAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new PetDog();
        }

        public ITiger GetTiger()
        {
            return new PetTiger();
        }
    }
    //Factory provider
    class FactoryProvider
    {
        public static IAnimalFactory GetAnimalFactory(string factoryType)
        {
            if (factoryType.Contains("wild"))
            {
                // Returning a WildAnimalFactory
                return new WildAnimalFactory();
            }
            else
           if (factoryType.Contains("pet"))
            {
                // Returning a PetAnimalFactory
                return new PetAnimalFactory();
            }
            else
            {
                throw new ArgumentException("You need to pass either wild or pet as argument.");
            }
        }
    }

    //Client
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Abstract Factory Pattern Demo.***\n");

            //Making a wild dog and wild tiger through WildAnimalFactory
            IAnimalFactory animalFactory = FactoryProvider.GetAnimalFactory("wild");
            IDog dog = animalFactory.GetDog();
            ITiger tiger = animalFactory.GetTiger();
            dog.AboutMe();
            tiger.AboutMe();

            Console.WriteLine("******************");

            //Making a pet dog and pet tiger through PetAnimalFactory now.
            animalFactory = FactoryProvider.GetAnimalFactory("pet");
            dog = animalFactory.GetDog();
            tiger = animalFactory.GetTiger();
            dog.AboutMe();
            tiger.AboutMe();

            Console.ReadLine();
        }
    }
}
