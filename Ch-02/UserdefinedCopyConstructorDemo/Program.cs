using System;

namespace UserdefinedCopyConstructorDemo
{
    class EmpAddress
    {
        public string Address { get; set; }

        public EmpAddress(string address)
        {
            this.Address = address;
        }

        public override string ToString()
        {
            return this.Address;
        }

        public object CloneAddress()
        {
            // Shallow Copy
            return this.MemberwiseClone();
        }
    }
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmpAddress EmpAddress { get; set; }

        // Instance Constructor
        public Employee(int id, string name, EmpAddress empAddress)
        {
            this.Id = id;
            this.Name = name;
            this.EmpAddress = empAddress;
        }

        // Copy Constructor 
        public Employee(Employee originalEmployee)
        {
            this.Id = originalEmployee.Id;
            this.Name = originalEmployee.Name;            
            //this.EmpAddress = (EmpAddress)this.EmpAddress.CloneAddress(); // ok
            this.EmpAddress = originalEmployee.EmpAddress.CloneAddress() as EmpAddress; // Also ok
        }
        public override string ToString()
        {
            return string.Format("Employee Id is : {0},Employee Name is : {1}, Employee Address is : {2}", this.Id, this.Name, this.EmpAddress);
        }
    }    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***A simple copy constructor demo***\n");
            EmpAddress initialAddress = new EmpAddress("21, abc Road, USA");
            Employee emp = new Employee(1, "John",initialAddress);
            Console.WriteLine("The details of emp is as follows:");
            Console.WriteLine(emp);
            Console.WriteLine("\n Copying from emp1 to empClone now.");
            Employee empClone= new Employee(emp);
            Console.WriteLine("The details of empClone is as follows:");
            Console.WriteLine(empClone);
            Console.WriteLine("\nNow changing the id,name and address of empClone.");
            empClone.Name = "Sam";
            empClone.Id = 2;            
            empClone.EmpAddress.Address= "221, xyz Road, Canada";
            Console.WriteLine("The details of emp is as follows:");
            Console.WriteLine(emp);
            Console.WriteLine("The details of empClone is as follows:");
            Console.WriteLine(empClone);
            Console.ReadKey();
        }
    }
}
