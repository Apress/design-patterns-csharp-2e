
using System;

namespace TemplateMethodPattern
{
    /// <summary>
    /// Basic skeleton of actions/steps
    /// </summary>
    public abstract class BasicEngineering
    {
        
        //The following method(step) will NOT vary
        private void Math()
        {
            Console.WriteLine("1.Mathematics");
        }
        //The following method(step) will NOT vary
        private  void SoftSkills()
        {
            Console.WriteLine("2.SoftSkills");
        }
        /*
        The following method will vary.It will be 
        overridden by derived classes.
        */

        public abstract void SpecialPaper();
        
        //The "Template Method"
        public void DisplayCourseStructure()
        {
            //Common Papers:
            Math();
            SoftSkills();
            //Specialized Paper:
            SpecialPaper();
        }
    }


    //The concrete derived class-ComputerScience
    public class ComputerScience : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("3.Object-Oriented Programming");
        }
    }

    //The concrete derived class-Electronics
    public class Electronics : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("3.Digital Logic and Circuit Theory");
        }
    }

    //Client code
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***Template Method Pattern Demonstration-1.***\n");
            BasicEngineering bs = new ComputerScience();
            Console.WriteLine("Computer Science course includes the following subjects:");
            bs.DisplayCourseStructure();
            Console.WriteLine();
            bs = new Electronics();
            Console.WriteLine("Electronics course includes the following subjects:");
            bs.DisplayCourseStructure();
            Console.ReadLine();
        }
    }
}

