using System;
using System.Collections.Generic;
namespace Week7._1
{
    class WithdrawTransaction : Transaction
    {
        //Instance variables
        private Account _account;

        //Constructor
        public WithdrawTransaction(Account account, decimal amount) : base(amount)
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
            Console.WriteLine("{0} withdrawn from {1}'s account", _amount.ToString("C"), _account.Name);
            Console.WriteLine("Account Balance: " + _account.Balance.ToString("C"));
            Console.WriteLine();
        }

        public override void RollbackPrint()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("Rollback done: {0} deposited into {1}'s account", _amount.ToString("C"), _account.Name);
            Console.WriteLine("Account Balance: " + _account.Balance.ToString("C"));
            Console.WriteLine();
        }

        public override void Execute()
        {
            base.Execute();
            _success = _account.Withdraw(_amount);
            if (!_success)
            {
                throw new InvalidOperationException("Withdraw amount exceeded balance");
            }
        }

        public override void Rollback()
        {
            base.Rollback();
            _account.Deposit(_amount);
        }
    }
}