using System.Collections.Generic;

namespace MVCPattern.Model
{
    public interface IModel
    {

        List<Employee> GetEnrolledEmployeeDetailsFromModel();
        void AddEmployeeToModel(Employee employeee);
        void RemoveEmployeeFromModel(string employeeId);
    }
}
