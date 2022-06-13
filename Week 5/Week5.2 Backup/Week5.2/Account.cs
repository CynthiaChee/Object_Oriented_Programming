using System;
namespace Week5._2
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

        //Properties
        public String Name
        {
            get
            {
                return _name;
            }
        }

        /*public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }*/

        //Methods
        public void Deposit(decimal amount) //Adds money into account
        {
            if (positiveAmt(amount) == true)
            {
                _balance += amount;
                Console.WriteLine("{0} deposited into account. New balance {1}", amount.ToString("C"), _balance.ToString("C"));
            }
            else
            {
                Console.WriteLine("Error: Deposit amount must be positive");
            }

        }

        public void Withdraw(decimal amount)    //Withdraw money from account
        {
            if (positiveAmt(amount) == true)
            {
                _balance -= amount;
                Console.WriteLine("{0} withdrawn from account. New balance {1}", amount.ToString("C"), _balance.ToString("C"));
            }
            else
            {
                Console.WriteLine("Error: Withdraw amount must be positive");
            }
        }

        public void Print()     //Prints account owner and balance
        {
            Console.WriteLine("Account owner: " + Name + "\nBalance: " + _balance.ToString("C"));
        }

        public static bool positiveAmt(decimal amount)      //Checks whether input amount is positive or negative
        {
            if (amount < 0)
            {
                return false;
            }
            return true;
        }
    }

}
