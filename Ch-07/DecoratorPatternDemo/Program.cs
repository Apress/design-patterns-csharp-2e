using System;

namespace DecoratorPatternDemo
{
    abstract class AbstractHome
    {
        public double AdditionalPrice { get; set; }
        public abstract void MakeHome();
    }
    class ConcreteHome : AbstractHome
    {
        public ConcreteHome()
        {
            AdditionalPrice = 0;
        }
        public override void MakeHome()
        {
            Console.WriteLine($"Original House is constructed.Price for this $10000");
        }
    }
    abstract class AbstractDecorator : AbstractHome
    {
        protected AbstractHome home;
        public AbstractDecorator(AbstractHome home)
        {
            this.home = home;
            this.AdditionalPrice = 0;
        }
        public override void MakeHome()
        {
            home.MakeHome();//Delegating task 
        }
    }

    //Floor Decorator is used to add a floor   
    class FloorDecorator : AbstractDecorator
    {        
        public FloorDecorator(AbstractHome home) : base(home)
        {            
            this.AdditionalPrice = 2500;
        }
        public override void MakeHome()
        {
            base.MakeHome();
            //Adding a floor on top of original house.
            AddFloor();
        }
        private void AddFloor()
        {
            Console.WriteLine($"-Additional Floor added.Pay additional ${AdditionalPrice} for it .");
        }
    }

    //Paint Decorator is used to paint the home.    
    class PaintDecorator : AbstractDecorator
    {        
        public PaintDecorator(AbstractHome home):base(home)
        {
            //this.home = home;
            this.AdditionalPrice = 5000;
        }
        public override void MakeHome()
        {
            base.MakeHome();           
            //Painting home.
            PaintHome();
        }
        private void PaintHome()
        {
            Console.WriteLine($"--Painting done.Pay additional ${AdditionalPrice} for it .");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Decorator pattern Demo***\n");
            #region Scenario-1
            Console.WriteLine("\n**Scenario-1:");
            Console.WriteLine("**Building home.Adding floor and then painting it.**");
            
            AbstractHome home = new ConcreteHome();
            Console.WriteLine("Current bill breakups are as follows:");
            home.MakeHome();

            //Applying a decorator
            //Adding a floor
            home = new FloorDecorator(home);
            Console.WriteLine("\nFloor added.Current bill breakups are as follows:");
            home.MakeHome();

            //Working on top of previous decorator.
            //Painting the home 
            home = new PaintDecorator(home);
            Console.WriteLine("\nPaint applied.Current bill breakups are as follows:");
            home.MakeHome();
            #endregion

            #region Scenario-2
            Console.WriteLine("\n**Scenario-2:");
            Console.WriteLine("**Building home,painting it and then adding two additional floors on top of it.**");
            //Fresh start once again.
            home = new ConcreteHome();
            Console.WriteLine("\nGoing back to original home.Current bill breakups are as follows:");
            home.MakeHome();

            //Applying paint on original home.
            home = new PaintDecorator(home);
            Console.WriteLine("\nPaint applied.Current bill breakups are as follows:");
            home.MakeHome();

            //Adding a floor on the painted home.
            home = new FloorDecorator(home);
            Console.WriteLine("\nFloor added.Current bill breakups are as follows:");
            home.MakeHome();

            //Adding another floor on the current home.
            home = new FloorDecorator(home);
            Console.WriteLine("\nFloor added.Current bill breakups are as follows:");
            home.MakeHome();
            #endregion
            

            Console.ReadKey();
        }
    }
}
