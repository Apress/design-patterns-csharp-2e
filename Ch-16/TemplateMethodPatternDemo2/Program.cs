
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
        private void SoftSkills()
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
            //Include an additional subject if required.
            if (IsAdditionalPaperNeeded())
            {
                IncludeAdditionalPaper();
            }
        }

        private void IncludeAdditionalPaper()
        {
            Console.WriteLine("4.Compiler Design.");
        }
        //A hook method.
        //By default,an additional subject is needed.
        public virtual bool IsAdditionalPaperNeeded()
        {
            return true;
        }
    }


    //The concrete derived class-ComputerScience
    public class ComputerScience : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("3.Object-Oriented Programming");
        }
        //Not tested the hook method:
        //An additional subject is needed
    }

    //The concrete derived class-Electronics
    public class Electronics : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("3.Digital Logic and Circuit Theory");
        }
        //Using the hook method now.
        //Additional paper is not needed for Electronics.
        public override bool IsAdditionalPaperNeeded()
        {
            return false;
        }

    }

    //Client code
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***Template Method Pattern Demonstration-2.***\n");
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

