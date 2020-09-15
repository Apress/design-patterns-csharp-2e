using System;
using System.Collections.Generic;

namespace VisitorWithCompositePattern
{
    interface IEmployee
    {
        //To set an employee name
        string Name { get; set; }
        //To set an employee department
        string Dept { get; set; }
        //To set an employee designation
        string Designation { get; set; }
       
        //To display an employee details
        void DisplayDetails();

        //Newly added for this example
        //To set years of Experience
        double Experience { get; set; }
        //Newly added for this example
        void Accept(IVisitor visitor);
    }
    //Leaf node
    class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Designation { get; set; }
        public double Experience { get; set; }
        //Details of a leaf node
        public void DisplayDetails()
        {
            Console.WriteLine($"{Name} works in { Dept} department.Designation:{Designation}.Experience : {Experience} years.");
        }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitEmployees(this);
        }

    }
    //Non-leaf node
    class CompositeEmployee : IEmployee
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Designation { get; set; }
        public double Experience { get; set; }

        //The container for child objects
        //private List<IEmployee> subordinateList = new List<IEmployee>();
        //Making it public now
        public List<IEmployee> subordinateList = new List<IEmployee>();

        //To add an employee
        public void AddEmployee(IEmployee e)
        {
            subordinateList.Add(e);
        }

        //To remove an employee
        public void RemoveEmployee(IEmployee e)
        {
            subordinateList.Remove(e);
        }

        //Details of a composite node
        public void DisplayDetails()
        {
            Console.WriteLine($"\n{Name} works in {Dept} department.Designation:{Designation}.Experience : {Experience} years.");
            foreach (IEmployee e in subordinateList)
            {
                e.DisplayDetails();
            }
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitEmployees(this);
        }
    }
    /// <summary>
    /// Visitor interface    
    /// </summary>
    interface IVisitor
    {
        //To visit leaf nodes
        void VisitEmployees(Employee employee);

        //To visit composite nodes
        void VisitEmployees(CompositeEmployee employee);
    }
    /// <summary>
    /// Concrete visitor class-PromotionCheckerVisitor
    /// </summary>
    class PromotionCheckerVisitor : IVisitor
    {
        string eligibleForPromotion = String.Empty;
        public void VisitEmployees(CompositeEmployee employee)
        {
            //We'll promote them if experience is greater than 15 years
            eligibleForPromotion = employee.Experience > 15 ? "Yes" : "No";
            Console.WriteLine($"{ employee.Name } from {employee.Dept} is eligible for promotion? :{eligibleForPromotion}");

        }

        public void VisitEmployees(Employee employee)
        {
            //We'll promote them if experience is greater than 12 years
            eligibleForPromotion = employee.Experience > 12 ? "Yes" : "No";
            Console.WriteLine($"{ employee.Name } from {employee.Dept} is eligible for promotion? :{eligibleForPromotion}");
        }
    }
    /// <summary>
    /// Client
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Visitor Pattern with Composite Pattern Demo. ***");

            #region Mathematics department
            //2 lecturers work in Mathematics department
            Employee mathTeacher1 = new Employee { Name = "M.Joy", Dept = "Mathematic", Designation = "Lecturer" ,Experience=13.7};
            Employee mathTeacher2 = new Employee { Name = "M.Roony", Dept = "Mathematics", Designation = "Lecturer", Experience = 6.5 };

            //The college has a Head of Department in Mathematics
            CompositeEmployee hodMaths = new CompositeEmployee { Name = "Mrs.S.Das", Dept = "Maths", Designation = "HOD-Maths", Experience = 14 };

            //Lecturers of Mathematics directly reports to HOD-Maths
            hodMaths.AddEmployee(mathTeacher1);
            hodMaths.AddEmployee(mathTeacher2);
            #endregion

            #region Computer Science department
            //3 lecturers work in Computer Sc. department
            Employee cseTeacher1 = new Employee { Name = "C.Sam", Dept = "Computer Science", Designation = "Lecturer", Experience = 10.2 };
            Employee cseTeacher2 = new Employee { Name = "C.Jones", Dept = "Computer Science.", Designation = "Lecturer", Experience = 13.5 };
            Employee cseTeacher3 = new Employee { Name = "C.Marium", Dept = "Computer Science", Designation = "Lecturer", Experience = 7.3 };

            //The college has a Head of Department in Computer science
            CompositeEmployee hodCompSc = new CompositeEmployee { Name = "Mr. V.Sarcar", Dept = "Computer Sc.", Designation = "HOD-Computer Sc.", Experience = 16.5 };

            //Lecturers of Computer Sc. directly reports to HOD-CSE
            hodCompSc.AddEmployee(cseTeacher1);
            hodCompSc.AddEmployee(cseTeacher2);
            hodCompSc.AddEmployee(cseTeacher3);
            #endregion

            #region Top level management
            //The college also has a Principal
            CompositeEmployee principal = new CompositeEmployee { Name = "Dr.S.Som", Dept = "Planning-Supervising-Managing", Designation = "Principal", Experience = 21 };

            //Head of Departments's of Maths and Computer Science directly reports to Principal.
            principal.AddEmployee(hodMaths);
            principal.AddEmployee(hodCompSc);
            #endregion

            /* 
             * Printing the leaf-nodes and branches in the same way.
             * i.e. in each case, we are calling DisplayDetails() method.
            */           
            Console.WriteLine("\nDetails of a college structure is as follows:");
            //Prints the complete structure
            principal.DisplayDetails();            
          
          

            List<IEmployee> participants = new List<IEmployee>();

            //For employees who directly reports to Principal
            foreach (IEmployee e in principal.subordinateList)
            {
                // e.Accept(aVisitor);
                participants.Add(e);
            }
            //For employees who directly reports to HOD-Maths
            foreach (IEmployee e in hodMaths.subordinateList)
            {
                //e.Accept(aVisitor);
                participants.Add(e);
            }
            //For employees who directly reports to HOD-Comp.Sc
            foreach (IEmployee e in hodCompSc.subordinateList)
            {
                //e.Accept(aVisitor);
                participants.Add(e);
            }
            Console.WriteLine("\n***Visitor starts visiting our composite structure***\n");
            IVisitor visitor = new PromotionCheckerVisitor();
            /*
           * Principal is already holding the highest position.
           * We are not checking whether he is eligible 
           * for promotion or not.
           */
            //principal.Accept(visitor);
            //Visitor is traversing the participant list
            foreach ( IEmployee  emp in participants)
            {
                emp.Accept(visitor);
            }

            //Wait for user
            Console.ReadKey();
        }
    }
}
