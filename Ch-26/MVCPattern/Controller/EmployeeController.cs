using System.Collections.Generic;
using MVCPattern.Model;
using MVCPattern.View;

namespace MVCPattern.Controller
{
    public class EmployeeController : IController
    {

        IModel model;
        IView view;

        public EmployeeController(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public void DisplayEnrolledEmployees()
        {
            //Get data from Model
            List<Employee> enrolledEmployees = model.GetEnrolledEmployeeDetailsFromModel();
            //Connect to View
            view.ShowEnrolledEmployees(enrolledEmployees);
        }

        //Sending a request to model to add an employee to the list.
        public void AddEmployee(Employee employee)
        {
            model.AddEmployeeToModel(employee);            
        }
        //Sending a request to model to remove an employee from the list.
        public void RemoveEmployee(string employeeId)
        {
            model.RemoveEmployeeFromModel(employeeId);
            
        }

    }

}
