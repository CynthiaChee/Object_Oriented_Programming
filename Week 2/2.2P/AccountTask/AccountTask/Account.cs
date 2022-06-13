using System;
namespace AccountTask
{
    class Account
    {
        //Instance variables
        private String _name;
        private decimal _balance;

        //Constructor
        public Account(String name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        //Property (read-only)
        public String Name
        {
            get
            {
                return _name;
            }
        }

        //Methods
        public void Deposit(decimal amount) //Adds money into account
        {
            _balance += amount;
            Console.WriteLine("{0} deposited into account. New balance {1}", amount.ToString("C"), _balance.ToString("C"));
        }

        public void Withdraw(decimal amount)    //Withdraw money from account
        {
            _balance -= amount;
            Console.WriteLine("{0} withdrawn from account. New balance {1}", amount.ToString("C"), _balance.ToString("C"));
        }

        public void Print()     //Prints account owner and balance
        {
            Console.WriteLine("Account owner: " + Name + "\nBalance: " + _balance.ToString("C"));
        }
    }
}