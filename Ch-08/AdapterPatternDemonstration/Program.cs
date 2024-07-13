using System;

namespace AdapterPatternDemonstration
{
    interface IRectangle
    {
        void AboutMe();
        double CalculateArea();
    }
    class Rectangle : IRectangle
    {
        double length;
        public double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double CalculateArea()
        {
            return length * width;
        }

        public void AboutMe()
        {
            Console.WriteLine("Actually, I am a Rectangle");
        }
    }

    interface ITriangle
    {
        void AboutTriangle();
        double CalculateAreaOfTriangle();
    }
    class Triangle : ITriangle
    {
        double baseLength;//base
        double height;//height
        public Triangle(double length, double height)
        {
            this.baseLength = length;
            this.height = height;
        }
        public double CalculateAreaOfTriangle()
        {
            return 0.5 * baseLength * height;
        }
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
    class RectangleAdapter : IRectangle
    {
        ITriangle triangle;
        public RectangleAdapter(ITriangle triangle)
        {
            this.triangle = triangle;
        }

        public void AboutMe()
        {
            triangle.AboutTriangle();
        }

        public double CalculateArea()
        {
            return triangle.CalculateAreaOfTriangle();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Adapter Pattern  Demo***\n");           
            IRectangle rectangle = new Rectangle(20, 10);
            Console.WriteLine("For initial verification purposes, printing the areas of both shapes.");
            Console.WriteLine("Rectangle area is:{0} Square unit", rectangle.CalculateArea());
            ITriangle triangle = new Triangle(20, 10);
            Console.WriteLine("Triangle area is:{0} Square unit", triangle.CalculateAreaOfTriangle());

            Console.WriteLine("\nNow using the adapter.");
            IRectangle adapter = new RectangleAdapter(triangle);
            Console.Write("True fact : ");
            adapter.AboutMe();
            Console.WriteLine($" and my area is : {adapter.CalculateArea()} square unit.");

            //Alternative way:
            Console.WriteLine("\nUsing the adapter in a different way now.");
            //Passing a Triangle instead of a Rectangle
            Console.WriteLine($"Area of the triangle using the adapter is :{GetDetails(adapter)} square unit.");
            Console.ReadKey();
        }
        /* 
         * The following method does not know 
         * that through the adapter,it can actually process a 
         * Triangle instead of a Rectangle.
         */
        static double GetDetails(IRectangle rectangle)
        {
            rectangle.AboutMe();
            return rectangle.CalculateArea();
        }
    }
}
