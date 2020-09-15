namespace BuilderPatternSimpleExample
{
    // The common interface
    interface IBuilder
    {
        void StartUpOperations();
        void BuildBody();
        void InsertWheels();
        void AddHeadlights();
        void EndOperations();
        Product GetVehicle();
        //An interface cannot contain instance field
        //Product product;//error
    }
}
