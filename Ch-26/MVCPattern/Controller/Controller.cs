using MVCPattern.Model;

namespace MVCPattern.Controller
{
    interface IController
    {
        void DisplayEnrolledEmployees();
        void AddEmployee(Employee employee);
        void RemoveEmployee(string employeeId);
    }

}
