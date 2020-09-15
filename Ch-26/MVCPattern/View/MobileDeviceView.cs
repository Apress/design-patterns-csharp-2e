using System;
using System.Collections.Generic;
using MVCPattern.Model;
namespace MVCPattern.View
{
    public class MobileDeviceView:IView
    {    

        public void ShowEnrolledEmployees(List<Employee> enrolledEmployees)
        {
            Console.WriteLine("\n +++This is a mobile device view of currently enrolled employees.+++ ");
            foreach (Employee emp in enrolledEmployees)
            {
                Console.WriteLine(emp.GetEmpId() + "\t" + emp.GetEmpName());
            }
            Console.WriteLine("+++++++++++++++++++++");
        }
    }
}
