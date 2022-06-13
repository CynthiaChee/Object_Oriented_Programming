using System;
using System.Collections.Generic;
namespace Week7._1
{
    class DepositTransaction : Transaction
    {
        //Instance variables
        private Account _account;

        //Constructor
        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            _account = account;
            _amount = amount;
        }

        public override bool Success => _success;

        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("{0} deposited into {1}'s account", _amount.ToString("C"), _account.Name);
            Console.WriteLine("Deposit amount: " + _amount.ToString("C"));
            Console.WriteLine("Account Balance: " + _account.Balance.ToString("C"));
            Console.WriteLine();
        }

        public override void RollbackPrint()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("Rollback done: {0} withdrawn from {1}'s account", _amount.ToString("C"), _account.Name);
            Console.WriteLine("Account Balance: " + _account.Balance.ToString("C"));
            Console.WriteLine();
        }

        public override void Execute()
        {
            base.Execute();
            _success = _account.Deposit(_amount);
            if (!_success)
            {
                throw new InvalidOperationException("Deposit amount cannot be negative");
            }
        }

        public override void Rollback()
        {
            base.Rollback();
            if (!_account.Withdraw(_amount))
            {
                throw new InvalidOperationException("Insufficient funds for rollback");
            }
        }
    }
}