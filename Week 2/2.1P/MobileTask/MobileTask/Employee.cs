using System;
namespace MobileTask
{
    class Employee
    {
        //Instance variables
        private String employeeName;
        private double currentSalary;

        public Employee(String employeeName, double currentSalary)     //object constructor
        {
            this.employeeName = employeeName;     //instance variables ('this' refers to the current instance)
            this.currentSalary = currentSalary;
        }

    }
}

