using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatternSecondDemonstration
{
    interface IBuilder
    {
        /*
         * All these methods return types are IBuilder.
         * This will help us to apply method chaining.
         * I'm also providing values for default arguments.
         */
        IBuilder StartUpOperations(string optionalStartUpMessage = "Making a car for you.");
        IBuilder BuildBody(string optionalBodyType = "Steel");
        IBuilder InsertWheels(int optionalNoOfWheels = 4);
        IBuilder AddHeadlights(int optionalNoOfHeadLights = 2);
        IBuilder EndOperations(string optionalEndMessage = "Car construction is completed.");
        //Combine the parts and make the final product.
        Product ConstructCar();
    }
}
