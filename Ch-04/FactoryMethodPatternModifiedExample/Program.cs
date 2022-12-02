using System;
using System.Net;
using System.Web;

namespace FactoryMethodPatternModifiedExample
{
    #region Animal Hierarchy
    /*
     * Both the Dog and Tiger classes will 
     * implement the IAnimal interface method.
    */
    public interface IAnimal
    {
        void AboutMe();
    }
    //Dog class
    public class Dog : IAnimal
    {
        public void AboutMe()
        {
            Console.WriteLine("The dog says: Bow-Wow.I prefer barking.");
        }
    }
    //Tiger class
    public class Tiger : IAnimal
    {
        public void AboutMe()
        {
            Console.WriteLine("The tiger says: Halum.I prefer hunting.");
        }
    }
    #endregion

    #region Factory Hierarchy

    //Both DogFactory and TigerFactory will use this.
    //Modifying the AnimalFactory class.
    public abstract class AnimalFactory
    {
        public IAnimal MakeAnimal()
        {
            Console.WriteLine("AnimalFactory.MakeAnimal()-You cannot ignore parent rules.");
           
            IAnimal animal = CreateAnimal();
            animal.AboutMe();
            return animal;
        }
        /*
        Remember the GoF definition which says 
        "....Factory method lets a class defer instantiation
        to subclasses." The following method will create a Tiger 
        or a Dog, but at this point it does not know whether 
        it will get a dog or a tiger. It will be decided by 
        the subclasses i.e.DogFactory or TigerFactory.
        So, the following method is acting like a factory 
        (of creation).
        */
        public abstract IAnimal CreateAnimal();
    }
    //DogFactory is used to create dog
    public class DogFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            //Creating a Dog
            return new Dog();
        }
    }
    //TigerFactory is used to create tigers
    public class TigerFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            //Creating a Tiger
            return new Tiger();
        }
    }
    #endregion
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Factory Pattern Modified Demo.***\n");
            // Creating a Tiger Factory
            AnimalFactory tigerFactory = new TigerFactory();
            // Creating a tiger using the Factory Method
            //IAnimal tiger = tigerFactory.CreateAnimal();
            //tiger.AboutMe();
            IAnimal tiger = tigerFactory.MakeAnimal();

            // Creating a DogFactory
            AnimalFactory dogFactory = new DogFactory();
            // Creating a dog using the Factory Method

            //IAnimal dog = dogFactory.CreateAnimal();
            //dog.AboutMe();
            IAnimal dog = dogFactory.MakeAnimal();     

            Console.ReadKey();
        }
    }
}
