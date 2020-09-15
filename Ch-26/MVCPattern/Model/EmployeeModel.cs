using System;
using System.Collections.Generic;


namespace MVCPattern.Model
{
    public class EmployeeModel : IModel
    {
        List<Employee> enrolledEmployees;


        public EmployeeModel()
        {
            //Adding 3 employees at the beginning.
            enrolledEmployees = new List<Employee>();
            enrolledEmployees.Add(new Employee("Amit", "E1"));
            enrolledEmployees.Add(new Employee("John", "E2"));
            enrolledEmployees.Add(new Employee("Sam", "E3"));
        }

        public List<Employee> GetEnrolledEmployeeDetailsFromModel()
        {
            return enrolledEmployees;
        }

        /* 
         * Adding an employee to the model(registered employee list) 
         */
        public void AddEmployeeToModel(Employee employee)
        {
            Console.WriteLine($"\nTrying to add an employee to the registered list.The employee name is {employee.GetEmpName()} and id is {employee.GetEmpId()}.");
            
            if (!enrolledEmployees.Contains(employee))
            {
                enrolledEmployees.Add(employee);
                Console.WriteLine(employee + " [added recently.]");
            }
            else
            {
                Console.WriteLine("This employee is already added in the registered list.So, ignoring the request of addition.");
            }
        }
        /* 
         * Removing an employee from model(registered employee list)
         */

        public void RemoveEmployeeFromModel(string employeeIdToRemove)
        {
            Console.WriteLine($"\nTrying to remove an employee from the registered list.The employee id is {employeeIdToRemove}.");
            Employee emp = FindEmployeeWithId(employeeIdToRemove);
            if (emp != null)
            {
                Console.WriteLine("Removing this employee.");
                enrolledEmployees.Remove(emp);
            }
            else
            {
                Console.WriteLine($"At present, there is no employee with id {employeeIdToRemove}.Ignoring this request.");
            }
        }
        Employee FindEmployeeWithId(string employeeIdToRemove)
        {
            Employee removeEmp = null;
            foreach (Employee emp in enrolledEmployees)
            {
                if (emp.GetEmpId().Equals(employeeIdToRemove))
                {

                    Console.WriteLine($" Employee Found.{emp.GetEmpName()} has id: { employeeIdToRemove}.");
                    removeEmp = emp;
                }
            }
            return removeEmp;
        }

    }
}
