using MVCPattern.Controller;
using MVCPattern.Model;
using MVCPattern.View;
using System;

namespace MVCPattern
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***MVC architecture Demo***\n");
            //Model
            IModel model = new EmployeeModel();

            //View
            IView view = new ConsoleView();

            //Controller
            IController controller = new EmployeeController(model, view);
            controller.DisplayEnrolledEmployees();

            //Add an employee
            Employee empToAdd = new Employee("Kevin", "E4");
            controller.AddEmployee(empToAdd);
            //Printing the current details
            controller.DisplayEnrolledEmployees();

            //Remove an existing employee using the employee id.            
            controller.RemoveEmployee("E2");
            //Printing the current details
            controller.DisplayEnrolledEmployees();

            //Cannot remove an  employee who does not belong to the list.
            controller.RemoveEmployee("E5");
            //Printing the current details
            controller.DisplayEnrolledEmployees();

            //Avoiding a duplicate entry
            controller.AddEmployee(empToAdd);
            //Printing the current details
            controller.DisplayEnrolledEmployees();

            /* 
             This segment is added to discuss a question in "Q&A Session" 
             and initially commented out. 
             */
            view = new MobileDeviceView();
            controller = new EmployeeController(model, view);
            controller.DisplayEnrolledEmployees();
            Console.ReadKey();
        }
    }
}
