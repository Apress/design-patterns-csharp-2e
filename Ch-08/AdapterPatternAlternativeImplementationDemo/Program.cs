using System;

namespace AdapterPatternAlternativeImplementationDemo
{
    interface IRectangle
    {
        void AboutMe();
    }
    class Rectangle : IRectangle
    {
        public void AboutMe()
        {
            Console.WriteLine("Actually, I am a Rectangle.");
        }
    }

    interface ITriangle
    {
        void AboutTriangle();
    }
    class Triangle : ITriangle
    {
        public void AboutTriangle()
        {
            Console.WriteLine("Actually, I am a Triangle.");
        }
    }

    /*
     * RectangleAdapter is implementing IRectangle.
     * So, it needs to implement all the methods 
     * defined in the target interface.
     */
    class RectangleAdapter : Triangle, IRectangle
    {
        public void AboutMe()
        {
            //Invoking the adaptee method
            //For Q&A
            //Console.WriteLine("You are using an adapter now.");
            AboutTriangle();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Adapter Pattern Alternative Implementation Technique Demo.***\n");
            IRectangle rectangle = new Rectangle();
            Console.WriteLine("For initial verification purposes, printing the details from of both shapes.");
            Console.WriteLine("The rectangle.AboutMe() says:");
            rectangle.AboutMe();
            ITriangle triangle = new Triangle();
            Console.WriteLine("The triangle.AboutTriangle() says:");
            triangle.AboutTriangle();

            Console.WriteLine("\nNow using the adapter.");
            IRectangle adapter = new RectangleAdapter();
            Console.Write("True fact : ");
            adapter.AboutMe();       
        }        
    }
}
