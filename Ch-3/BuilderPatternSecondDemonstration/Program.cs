using System;


namespace BuilderPatternSecondDemonstration
{    
    // Director class(Client Code) 
    class Program
    {
        static Product customCar;
        static void Main(string[] args)
        {
            
            Console.WriteLine("***Builder Pattern alternative implementation.***");
            /*Making a custom car (through builder)
              Note the steps:
              Step1:Get a builder object with required parameters
              Step2:Setter like methods are used.They will set the optional fields also.
              Step3:Invoke the ConstructCar() method to get the final car.
             */
            customCar = new Car("Suzuki Swift").StartUpOperations()//will take default message
                    .AddHeadlights(6)
                    .InsertWheels()//Will consider default value
                    .BuildBody("Plastic")
                    .EndOperations("Suzuki construction Completed.")
                    .ConstructCar();

            customCar.Show();
            /* Making another custom car (through builder) with a different 
             * sequence and steps.
             */
            // Directly using the Product class now
            // (Just for a variation of usage)         
            Product customCar2 = new Car("Sedan")
                     .InsertWheels(7)
                     .AddHeadlights(6)
                     .StartUpOperations("Sedan creation in progress")
                     .BuildBody()
                     .EndOperations()//will take default end message
                     .ConstructCar();
            customCar2.Show();

        }
    }
}
