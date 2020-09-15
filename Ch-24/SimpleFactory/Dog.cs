using System;
namespace SimpleFactory
{
    public class Dog : IAnimal
    {
        public void AboutMe()
        {
            Console.WriteLine("The dog says: Bow-Wow.I prefer barking.");
        }
    }
}
