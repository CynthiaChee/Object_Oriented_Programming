using System;
namespace MobileTask
{
    class Mobile
    {
        //Instance variables
        private String accType, device, number;
        private double balance;

        //Constants
        private const double CALL_COST = 0.245;
        private const double TEXT_COST = 0.078;

        public Mobile(String accType, String device, String number)     //object constructor
        {
            this.accType = accType;     //instance variables ('this' refers to the current instance)
            this.device = device;
            this.number = number;
            this.balance = 0.0;
        }

        //Accessor methods
        public String getAccType()
        {
            return this.accType;
        }

        public String getDevice()
        {
            return this.device;
        }

        public String getNumber()
        {
            return this.number;
        }

        public String getBalance()
        {
            //returns the balance as a currency through the ToString method and the parameter "C"
            return this.balance.ToString("C");
        }

        //Mutator methods
        public void setAccType(String accType)
        {
            this.accType = accType;
        }

        public void setDevice(String device)
        {
            this.device = device;
        }

        public void setNumber(String number)
        {
            this.number = number;
        }

        public void setBalance(double balance)
        {
            this.balance = balance;
        }

        //Methods
        public void addCredit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("Credit added successfully. New balance " + getBalance());
        }

        public void makeCall(int minutes)
        {
            double cost = minutes * CALL_COST;
            this.balance -= cost;
            Console.WriteLine("Call made. New balance " + getBalance());
        }

        public void sendText(int numTexts)
        {
            double cost = numTexts * TEXT_COST;
            this.balance -= cost;
            Console.WriteLine("Text sent. New balance " + getBalance());
        }
    }
}
