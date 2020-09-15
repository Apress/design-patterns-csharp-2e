using System;

namespace BridgePatternDemo2
{
    //Abstraction
    public abstract class ElectronicGoods
    {
       // public IPrice Price { get; set; }
        private IPrice price;
        public string type;
        public double cost;
        public ElectronicGoods(IPrice price)
        {
            this.price = price;
        }
        public void Details()
        {
            price.DisplayDetails(type,cost);
        }
        //Additional method
        public void Discount(int percentage)
        {
           price.GetDiscount(percentage);
            //Added for Q&A session
           // price.GiveThanks();
        }
    }
    //Refined Abstraction-1
    //Television class uses the default discount method.
    public class Television : ElectronicGoods
    {
        public Television(IPrice price):base(price)
        {
            this.type = "Television";
            this.cost = 2000;
        }
        //No additional method exists for Television
       
    }
    //Refined Abstraction-2
    //DVD class can give additional discount.
    public class DVD : ElectronicGoods
    {
        public DVD(IPrice price) : base(price)
        {
            this.type = "DVD";
            this.cost = 3000;
        }

        //Specic method in DVD
        public void DoubleDiscount()
        {
            //Normal discount(10%)           
            Discount(10);
            //Festive season additional discount(5%)
            Discount(5);
        }
    }

    //Implementor
    public interface IPrice
    {
        void DisplayDetails(string product, double price);
        //Additional method
        void GetDiscount(int percentage);
        //Added for Q&A session
       // void GiveThanks();
    }
    //This is ConcreteImplementor-1
    //OnlinePrice class
    public class OnlinePrice : IPrice
    {

        public void DisplayDetails(string productType, double price)
        {
            Console.Write($"\n{productType} price at online is : {price}$");
        }
        public void GetDiscount(int percentage)
        {
            Console.Write($"\nAt online, you can get upto {percentage}% discount.");
        }
        //Added for Q&A session
        //public void GiveThanks()
        //{
        //    Console.Write("Thank you, please visit the site again.");
        //}
    }
    //This is ConcreteImplementor-2
    //ShowroomPrice class
    public class ShowroomPrice : IPrice
    {
        public virtual void DisplayDetails(string productType, double price)
        {
            //Showroom price is 300$ more
            Console.Write($"\n{productType} price at showroom is : {price + 300}$");
        }
        public void GetDiscount(int percentage)
        {
            Console.Write($"\nAt showroom, additional {percentage}% discount can be approved.");
        }

        //Added for Q&A session
        //public void GiveThanks()
        //{
        //    Console.Write("Thank you for coming. please visit the shop again.");
        //}
    }
    //Client code
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Alternative Implementation of Bridge Pattern.***");
            #region Television details
            Console.WriteLine("Verifying the market price of a television.");
             ElectronicGoods eItem = new Television(new OnlinePrice());
            //Verifying online  price details                       
            eItem.Details();
            //Giving 10% discount
            eItem.Discount(10);
            //Verifying showroom price
            eItem = new Television(new ShowroomPrice());                      
            eItem.Details();
            //Giving 10% discount
            eItem.Discount(10);
            #endregion

            #region DVD details
            Console.WriteLine("\n\nNow checking the DVD details.");
            //Verifying online  price
            eItem = new DVD(new OnlinePrice());                                 
            eItem.Details();
            //Giving 10% discount
            eItem.Discount(10);
            //Verifying showroom price
            eItem = new DVD(new ShowroomPrice());            
            eItem.Details();
            Console.WriteLine("\nIn showroom, you want to give double discounts at festive season.");
            Console.WriteLine("For DVD , you can get double discounts using the DoubleDiscount() method.");
            //eItem.Discount();
            Console.WriteLine("For example, in festive season:");
            ((DVD)eItem).DoubleDiscount();
            #endregion
        }
    }
}
