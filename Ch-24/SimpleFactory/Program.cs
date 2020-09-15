using System;

namespace SimpleFactory
{
     /* 
     * A client is interested to get an animal 
     * who can tell something about it.
     */
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Simple Factory Pattern Demo.***\n");
            IAnimal preferredType = null;
            SimpleFactory simpleFactory = new SimpleFactory();
            #region The code region that can vary based on users preference.
            /* 
             * Since this part may vary,we're moving the 
             * part to CreateAnimal() in SimpleFactory class.
             */
            preferredType = simpleFactory.CreateAnimal();
            #endregion

            #region The codes that do not change frequently.
            preferredType.AboutMe();
            #endregion

            Console.ReadKey();
        }
    }
}

