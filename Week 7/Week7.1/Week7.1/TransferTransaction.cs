using System;
using System.Collections.Generic;
namespace Week7._1
{
    class TransferTransaction : Transaction
    {
        //Instance variables
        private Account _fromAccount;
        private Account _toAccount;
        DepositTransaction _deposit;
        WithdrawTransaction _withdraw;

        //Constructor
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _deposit = new DepositTransaction(_toAccount, _amount);
        }

        public override bool Success => _withdraw.Success && _deposit.Success;

        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("Sender Account Name: " + _fromAccount.Name);
            Console.WriteLine("Sender Account Balance: " + _fromAccount.Balance.ToString("C"));
            Console.WriteLine("Recipient Account Name: " + _toAccount.Name);
            Console.WriteLine("Recipient Account Balance: " + _toAccount.Balance.ToString("C"));
            Console.WriteLine("Transferred amount: " + _amount.ToString("C"));
            Console.WriteLine();
        }

        public override void RollbackPrint()
        {
            Console.WriteLine();
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("Rollback done: {0} returned from {1}'s into {2}'s account", _amount.ToString("C"), _toAccount.Name, _fromAccount.Name);
            Console.WriteLine("{0}'s Account Balance: {1}", _fromAccount.Name, _fromAccount.Balance.ToString("C"));
            Console.WriteLine("{0}'s Account Balance: {1}", _toAccount.Name, _toAccount.Balance.ToString("C"));
            Console.WriteLine();
        }

        public override void Execute()
        {
            base.Execute();
            _withdraw.Execute();
            _deposit.Execute();
        }

        public override void Rollback()
        {
            _deposit.Rollback();
            _withdraw.Rollback();
            base.Rollback();
        }
    }
}
