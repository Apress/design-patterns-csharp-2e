using System;
using FacadePattern.RobotParts;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Facade Pattern Demo.***\n");            
            //Making a Milano robot with green color.
            RobotFacade facade = new RobotFacade("Milano","green");
            facade.ConstructRobot();
            //Making a robonaut robot with default steel color.           
            facade = new RobotFacade("Robonaut");
            facade.ConstructRobot();
            //Destroying one robot
            facade.DestroyRobot();
            //Destroying another robot
            facade.DestroyRobot();
            //This destrcution attempt should fail.
            facade.DestroyRobot();

            ////Without Facade pattern
            //RobotBody robotBody = new RobotBody("Milano");
            //robotBody.MakeRobotBody();
            //RobotColor robotColor = new RobotColor("green");
            //robotColor.SetColor();


            Console.ReadLine();

        }
    }
}
