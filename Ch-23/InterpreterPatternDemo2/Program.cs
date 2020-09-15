using System;
using System.Collections.Generic;

namespace InterpreterPatternDemo2
{
    interface Employee
    {
        bool Interpret(Context context);
    }
    /// <summary>
    /// IndividualEmployee class
    /// </summary>
    class IndividualEmployee : Employee
    {
        private int yearOfExperience;
        private string currentGrade;
        public IndividualEmployee(int experience, string grade)
        {
            this.yearOfExperience = experience;
            this.currentGrade = grade;
        }
        public bool Interpret(Context context)
        {
            if (this.yearOfExperience >= context.GetYearofExperience()
                 && context.GetPermissibleGrades().Contains(this.currentGrade))
            {
                return true;
            }
            return false;
        }
    }
    /// <summary>
    /// OrExpression class
    /// </summary>
    class OrExpression : Employee
    {
        private Employee emp1;
        private Employee emp2;
        public OrExpression(Employee emp1, Employee emp2)
        {
            this.emp1 = emp1;
            this.emp2 = emp2;
        }
        public bool Interpret(Context context)
        {
            return emp1.Interpret(context) || emp2.Interpret(context);
        }
    }
    /// <summary>
    /// AndExpression class
    /// </summary>
    class AndExpression : Employee
    {
        private Employee emp1;
        private Employee emp2;
        public AndExpression(Employee emp1, Employee emp2)
        {
            this.emp1 = emp1;
            this.emp2 = emp2;
        }
        public bool Interpret(Context context)
        {
            return emp1.Interpret(context) && emp2.Interpret(context);
        }
    }
    /// <summary>
    /// NotExpression class
    /// </summary>
    class NotExpression : Employee
    {
        private Employee emp;
        public NotExpression(Employee expr)
        {
            this.emp = expr;
        }
        public bool Interpret(Context context)
        {
            return !emp.Interpret(context);
        }
    }
    /// <summary>
    /// Context class
    /// </summary>
    class Context
    {
        private int experienceReqdForPromotion;
        private List<string> allowedGrades;
        public Context(int experience, List<string> allowedGrades)
        {
            this.experienceReqdForPromotion = experience;
            this.allowedGrades = new List<string>();
            foreach (string grade in allowedGrades)
            {
                this.allowedGrades.Add(grade);
            }
        }
        public int GetYearofExperience()
        {
            return experienceReqdForPromotion;
        }
        public List<string> GetPermissibleGrades()
        {
            return allowedGrades;
        }
    }
    /// <summary>
    /// EmployeeBuilder class
    /// </summary>
    class EmployeeBuilder
    {
        // Building the tree
        //Complex Rule-1: emp1 and (emp2 or (emp3 or emp4))
        public Employee BuildTreeBasedOnRule1(Employee emp1, Employee emp2, Employee emp3, Employee emp4)
        {
            // emp3 or emp4
            Employee firstPhase = new OrExpression(emp3, emp4);
            // emp2 or (emp3 or emp4)
            Employee secondPhase = new OrExpression(emp2, firstPhase);
            // emp1 and (emp2 or (emp3 or emp4))
            Employee finalPhase = new AndExpression(emp1, secondPhase);
            return finalPhase;
        }
        //Complex Rule-2: emp1 or (emp2 and (not emp3 ))
        public Employee BuildTreeBasedOnRule2(Employee emp1, Employee emp2, Employee emp3)
        {
            // Not emp3
            Employee firstPhase = new NotExpression(emp3);
            // emp2 or (not emp3)
            Employee secondPhase = new AndExpression(emp2, firstPhase);
            // emp1 and (emp2 or (not emp3 ))
            Employee finalPhase = new OrExpression(emp1, secondPhase);
            return finalPhase;
        }
    }
    public class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Interpreter Pattern Demonstration-2***\n");

            // Minimum Criteria for promoton is:
            // The year of experience is minimum 10 yrs. and 
            // Employee grade should be either G2 or G3
            List<string> allowedGrades = new List<string> { "G2", "G3" };
            Context context = new Context(10, allowedGrades);
            Employee emp1 = new IndividualEmployee(5, "G1");
            Employee emp2 = new IndividualEmployee(10, "G2");
            Employee emp3 = new IndividualEmployee(15, "G3");
            Employee emp4 = new IndividualEmployee(20, "G4");

            EmployeeBuilder builder = new EmployeeBuilder();

            //Validating the 1st complex rule
            Console.WriteLine("----- Validating the first complex rule.-----");
            Console.WriteLine("Is emp1 and any of emp2,emp3, emp4 is eligible for promotion?"
                + builder.BuildTreeBasedOnRule1(emp1, emp2, emp3, emp4).Interpret(context));
            Console.WriteLine("Is emp2 and any of emp1,emp3, emp4 is eligible for promotion?"
                + builder.BuildTreeBasedOnRule1(emp2, emp1, emp3, emp4).Interpret(context));
            Console.WriteLine("Is emp3 and any of emp1,emp2, emp3 is eligible for promotion?"
                + builder.BuildTreeBasedOnRule1(emp3, emp1, emp2, emp4).Interpret(context));
            Console.WriteLine("Is emp4 and any of emp1,emp2, emp3 is eligible for promotion?"
                + builder.BuildTreeBasedOnRule1(emp4, emp1, emp2, emp3).Interpret(context));

            Console.WriteLine("-----Validating the second complex rule now.-----");
            //Validating the 2nd complex rule
            Console.WriteLine("Is emp1 or (emp2 but not emp3) is eligible for promotion?"
                + builder.BuildTreeBasedOnRule2(emp1, emp2, emp3).Interpret(context));
            Console.WriteLine("Is emp2 or (emp3 but not emp4) is eligible for promotion?"
                + builder.BuildTreeBasedOnRule2(emp2, emp3, emp4).Interpret(context));
            Console.ReadKey();
        }
    }
}