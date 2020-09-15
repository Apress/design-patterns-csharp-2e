namespace MVCPattern.Model
{
    //The key "data" in this application
    public class Employee
    {
        private string empName;
        private string empId;
        public string GetEmpName()
        {
            return empName;
        }
        public string GetEmpId()
        {
            return empId;
        }
        public Employee(string empName, string empId)
        {
            this.empName = empName;
            this.empId = empId;
        }

        public override string ToString()
        {
            return  $"{empName} is enrolled with id : {empId}.";
        }        
    }
}
