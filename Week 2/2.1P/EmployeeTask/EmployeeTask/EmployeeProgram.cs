using System;

namespace EmployeeTask
{
    class EmployeeProgram
    {
        static void Main(string[] args)
        {
            Employee sarah = new Employee("Sarah", 35000.00);

            sarah.setName("Sarah Adams");
            sarah.setSalary(35000.00);

            Console.WriteLine("Employee Name: " + sarah.getName() + "\nCurrent Salary: " + sarah.getSalary());
            Console.WriteLine();
            sarah.raiseSalary(10);
            sarah.Tax();

            Console.WriteLine();

            Employee amy = new Employee("Amy", 63000.00);

            amy.setName("Amy Smith");
            amy.setSalary(63000.00);

            Console.WriteLine("Employee Name: " + amy.getName() + "\nCurrent Salary: " + amy.getSalary());
            Console.WriteLine();
            amy.raiseSalary(5);
            amy.Tax();

            Console.WriteLine();

            Employee boss = new Employee("Boss", 100000.00);

            boss.setName("The Boss");
            boss.setSalary(100000.00);

            Console.WriteLine("Employee Name: " + boss.getName() + "\nCurrent Salary: " + boss.getSalary());
            Console.WriteLine();
            boss.raiseSalary(20);
            boss.Tax();

        }
    }
}
