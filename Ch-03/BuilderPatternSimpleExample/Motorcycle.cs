namespace BuilderPatternSimpleExample
{
    // Motorcycle is another ConcreteBuilder
    class Motorcycle : IBuilder
    {
        private string brandName;
        private Product product;
        public Motorcycle(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }
        public void StartUpOperations()
        {
            product.Add("_________________");
        }

        public void BuildBody()
        {
            product.Add("This is a body of a Motorcycle");
        }

        public void InsertWheels()
        {
            product.Add("2 wheels are added");
        }

        public void AddHeadlights()
        {
            product.Add("1 Headlights are added");
        }
        public void EndOperations()
        {
            //Finishing up with brandname
            product.Add($"Motorcycle model name :{this.brandName}");
            product.Add("_________________");
        }
        public Product GetVehicle()
        {
            return product;
        }
    }
}
