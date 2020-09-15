using System;

namespace BridgePattern
{
    //Abstraction
    public abstract class ElectronicGoods
    {
        public IPrice Price { get; set; }
        public string ProductType { get; set; }
        public abstract void Details();

    }
    //Refined Abstraction
    public class Television : ElectronicGoods
    {
        /*
         * Implementation specific:
         * Delegating the task
         * to the Implementor object.
         */

        public override void Details()
        {
            Price.DisplayDetails(ProductType);
        }
    }

    //Implementor
    public interface IPrice
    {
        void DisplayDetails(string product);
    }
    //This is ConcreteImplementor-1
    //OnlinePrice class
    public class OnlinePrice : IPrice
    {
        public void DisplayDetails(string productType)
        {
            Console.Write($"\n{productType} price at online is : 2000$");
        }
    }
    //This is ConcreteImplementor-2
    //ShowroomPrice class
    public class ShowroomPrice : IPrice
    {
        public void DisplayDetails(string productType)
        {
            Console.Write($"\n{productType} price at showroom is : 3000$");
        }
    }
    //Client code
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Bridge Pattern Demo.***");
            Console.WriteLine("Verifying the market price of a television.");
            ElectronicGoods eItem = new Television();
            eItem.ProductType = "Sony Television";
            //Verifying online  price
            IPrice price = new OnlinePrice();
            eItem.Price = price;
            eItem.Details();
            //Verifying showroom price
            price = new ShowroomPrice();
            eItem.Price = price;
            eItem.Details();
        }
    }
}
