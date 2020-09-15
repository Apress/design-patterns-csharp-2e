using System;

namespace SimpleFactory
{
    public class Tiger : IAnimal
    {
        public void AboutMe()
        {
            Console.WriteLine("The tiger says: Halum.I prefer hunting.");
        }
    }
}
