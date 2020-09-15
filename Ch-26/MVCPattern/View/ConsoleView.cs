using System;
using System.Collections.Generic;
using MVCPattern.Model;

namespace MVCPattern.View
{

    public class ConsoleView : IView
    {

        public void ShowEnrolledEmployees(List<Employee> enrolledEmployees)
        {
            Console.WriteLine("\n ***This is a console view of currently enrolled employees.*** ");
            foreach (Employee emp in enrolledEmployees)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("---------------------");
        }
    }

}
