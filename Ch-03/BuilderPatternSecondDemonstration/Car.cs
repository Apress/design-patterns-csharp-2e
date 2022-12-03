using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatternSecondDemonstration
{
    // Car class
    class Car : IBuilder
    {
        Product product;

        private string brandName;
        public Car(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }
        public IBuilder StartUpOperations(string optionalStartUpMessage = " Making a car for you.")
        {   // Starting with brandname           
            product.Add(optionalStartUpMessage);
            product.Add($"Car model name :{this.brandName}");
            return this;
        }
        public IBuilder BuildBody(string optionalBodyType = "Steel")
        {
            product.Add(($"Body type:{optionalBodyType}"));
            return this;
        }

        public IBuilder InsertWheels(int optionalNoOfWheels = 4)
        {
            product.Add(($"Wheels:{optionalNoOfWheels.ToString()}"));
            return this;
        }

        public IBuilder AddHeadlights(int optionalNoOfHeadLights = 2)
        {
            product.Add(($"Headlights:{optionalNoOfHeadLights.ToString()}"));
            return this;
        }

        public IBuilder EndOperations(string optionalEndMessage = "Car construction is completed.")
        {
            product.Add(optionalEndMessage);
            return this;
        }
        public Product ConstructCar()
        {
            return product;
        }     

    }
}
