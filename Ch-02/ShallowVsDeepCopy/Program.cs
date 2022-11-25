using System;

namespace ShallowVsDeepCopy
{
    /// <summary>
    /// EmpAddress class
    /// </summary>
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
            //Shallow Copy
            return this.MemberwiseClone();
        }
    }
    /// <summary>
    /// Employee class
    /// </summary>
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmpAddress EmpAddress { get; set; }

        public Employee(int id, string name, EmpAddress empAddress)
        {
            this.Id = id;
            this.Name = name;
            this.EmpAddress = empAddress;
        }       

        public override string ToString()
        {
            return string.Format("Employee Id is : {0},Employee Name is : {1}, Employee Address is : {2}", this.Id,this.Name,this.EmpAddress);
        }

        public object Clone()
        {
            //Shallow Copy
            return this.MemberwiseClone();

            //#region For deep copy

            //Employee employee = (Employee)this.MemberwiseClone();
            //employee.EmpAddress = (EmpAddress)this.EmpAddress.CloneAddress();

            /*
             * NOTE:
             * Error : MemberwiseClone() is protected, you cannot 
             * access it via a qualifier of type EmpAddress. The qualifier 
             * must be Employee or its derived type.
            */
            //employee.EmpAddress = (EmpAddress)this.EmpAddress.MemberwiseClone(); // error

            //return employee;
            //#endregion

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Shallow vs Deep Copy Demo.***\n");
            EmpAddress initialAddress = new EmpAddress("21, abc Road, USA");            
            Employee emp = new Employee(1, "John", initialAddress);

            Console.WriteLine("The original object is emp1 which is as follows:");
            Console.WriteLine(emp);

            Console.WriteLine("Making a clone of emp1 now.");
            Employee empClone = (Employee)emp.Clone();
            Console.WriteLine("empClone object is as follows:");
            Console.WriteLine(empClone);

            Console.WriteLine("\n Now changing the name, id and address of the cloned object ");
            empClone.Id=10;
            empClone.Name="Sam";
            empClone.EmpAddress.Address= "221, xyz Road, Canada";
            

            Console.WriteLine("Now emp1 object is as follows:");
            Console.WriteLine(emp);
            Console.WriteLine("And emp1Clone object is as follows:");
            Console.WriteLine(empClone);
        }

    }
}
