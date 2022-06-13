using System;
using System.Collections.Generic;
namespace Week6._2
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
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }
        //Methods
        public bool Deposit(decimal amount)
        {
            if (!positiveAmt(amount))
            {
                return false;
            }

            _balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (!positiveAmt(amount) || amount > _balance)
            {
                return false;
            }

            _balance -= amount;
            return true;
        }

        public void PrintWithdraw(bool withdraw)
        {
            if (withdraw)
            {
                Console.WriteLine("Remaining balance: " + _balance.ToString("C"));
            }
            else
            {
                Console.WriteLine("Error: Withdraw failed");
            }
        }

        public void PrintDeposit(bool deposit)
        {
            if (deposit)
            {
                Console.WriteLine("Remaining balance: " + _balance.ToString("C"));
            }
            else
            {
                Console.WriteLine("Error: Deposit failed");
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
