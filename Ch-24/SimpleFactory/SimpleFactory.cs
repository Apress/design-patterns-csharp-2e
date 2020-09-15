using System;
namespace SimpleFactory
{
    public class SimpleFactory
    {
        public IAnimal CreateAnimal()
        {
            IAnimal intendedAnimal = null;
            Console.WriteLine("Enter your choice(0 for Dog, 1 for Tiger)");
            string b1 = Console.ReadLine();
            int input;
            if (int.TryParse(b1, out input))
            {
                Console.WriteLine("You have entered {0}", input);
                switch (input)
                {
                    case 0:
                        intendedAnimal = new Dog();
                        break;
                    case 1:
                        intendedAnimal = new Tiger();
                        break;
                    default:
                        Console.WriteLine("You must enter either 0 or 1");
                        //We'll throw a runtime exception for any other choices.
                        throw new ApplicationException(String.Format
                        (" Unknown Animal cannot be instantiated."));
                }
            }
            return intendedAnimal;
        }
    }
}
