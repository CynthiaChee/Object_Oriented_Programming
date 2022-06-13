using System;

namespace EmployeeTask
{
    class Employee
    {
        //Instance variables
        private String employeeName;
        private double currentSalary;
        private double taxAmount;

        public Employee(String employeeName, double currentSalary)     //object constructor
        {
            this.employeeName = employeeName;     //instance variables ('this' refers to the current instance)
            this.currentSalary = currentSalary;
        }

        //Accessor Methods
        public String getName()
        {
            return this.employeeName;
        }

        public String getSalary()
        {
            return this.currentSalary.ToString("C");
        }

        public String getTax()
        {
            return this.taxAmount.ToString("C");
        }

        //Mutator Methods
        public void setName(string employeeName)
        {
            this.employeeName = employeeName;
        }

        public void setSalary(double currentSalary)
        {
            this.currentSalary = currentSalary;
        }


        //Methods
        public void raiseSalary(double percentage)
        {
            this.currentSalary += this.currentSalary * percentage/100;
            Console.WriteLine("This employee received a {0} percent raise. New salary " + getSalary(), percentage);
        }

        public void Tax()
        {
            if (this.currentSalary < 18200)
            {
                Console.WriteLine("No tax amount");
            }
            else if (this.currentSalary >18200 && this.currentSalary < 37000)
            {
                this.taxAmount = (this.currentSalary - 18200) * 0.19;
                Console.WriteLine("Amount of tax deducted from annual pay " + getTax());
            }
            else if (this.currentSalary > 37000 && this.currentSalary < 90000)
            {
                this.taxAmount = (this.currentSalary - 37000) * 0.325 + 3572;
                Console.WriteLine("Amount of tax deducted from annual pay " + getTax());
            }
            else if (this.currentSalary > 90000 && this.currentSalary < 180000)
            {
                this.taxAmount = (this.currentSalary - 90000) * 0.37 + 20797;
                Console.WriteLine("Amount of tax deducted from annual pay " + getTax());
            }
            else if (this.currentSalary > 180000)
            {
                this.taxAmount = (this.currentSalary - 90000) * 0.45 + 54096;
                Console.WriteLine("Amount of tax deducted from annual pay " + getTax());
            }
        }
    }
}
