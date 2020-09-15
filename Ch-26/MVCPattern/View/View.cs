using MVCPattern.Model;
using System.Collections.Generic;


namespace MVCPattern.View
{
    public interface IView
    {
        void ShowEnrolledEmployees(List<Employee> enrolledEmployees);
    }
}
