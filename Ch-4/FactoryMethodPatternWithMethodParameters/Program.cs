using System;

namespace FactoryMethodPatternWithMethodParameters
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
    public abstract class AnimalFactory
    {
        /*
        Remember the GoF definition which says 
        "....Factory method lets a class defer instantiation
        to subclasses." Following method will create a Tiger 
        or a Dog, but at this point it does not know whether 
        it will get a dog or a tiger. It will be decided by 
        the subclasses i.e.DogFactory or TigerFactory.
        So, the following method is acting like a factory 
        (of creation).
        */
        public abstract IAnimal CreateAnimal(string animalType);
    }
    /*
     * ConcreteAnimalFactory is used to create dogs or tigers 
     * based on method parameter of CreateAnimal() method.
     */
    public class ConcreteAnimalFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal(string animalType)
        {
            if (animalType.Contains("dog"))
            {
                //Creating a Dog
                return new Dog();
            }
            else
            if (animalType.Contains("tiger"))
            {
                //Creating a Dog
                return new Tiger();
            }
            else
            {
                throw new ArgumentException("You need to pass either a dog or a tiger as an argument.");
            }
        }
    }

    #endregion
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Factory Pattern Demo.***");
            Console.WriteLine("***It's a modified version using method parameter(s).***\n");
            // Creating a factory that can produce animals
            AnimalFactory animalFactory = new ConcreteAnimalFactory();
            // Creating a tiger using the Factory Method
            IAnimal tiger = animalFactory.CreateAnimal("tiger");
            tiger.AboutMe();
            //Now creating a dog.          
            IAnimal dog = animalFactory.CreateAnimal("dog");
            dog.AboutMe();

            Console.ReadKey();
        }
    }
}
