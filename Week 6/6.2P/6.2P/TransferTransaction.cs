using System;
using System.Collections.Generic;
namespace Week6._2
{
    class TransferTransaction
    {
        //Instance variables
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        DepositTransaction _deposit;
        WithdrawTransaction _withdraw;
        private bool _executed;
        private bool _reversed;

        //Constructor
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _deposit = new DepositTransaction(_toAccount, _amount);
        }

        //Properties (read-only)
        public bool Executed
        {
            get
            {
                return _executed;
            }
        }

        public bool Reversed
        {
            get
            {
                return _reversed;
            }
        }

        public void Print()
        {
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("Sender Account Name: " + _fromAccount.Name);
            Console.WriteLine("Sender Account Balance: " + _fromAccount.Balance.ToString("C"));
            Console.WriteLine("Recipient Account Name: " + _toAccount.Name);
            Console.WriteLine("Recipient Account Balance: " + _toAccount.Balance.ToString("C"));
            Console.WriteLine("Transferred amount: " + _amount.ToString("C"));
        }

        public void RollbackPrint()
        {
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("Rollback done: {0} returned from {1}'s into {2}'s account", _amount.ToString("C"), _toAccount.Name, _fromAccount.Name);
            Console.WriteLine("{0}'s Account Balance: {1}", _fromAccount.Name, _fromAccount.Balance.ToString("C"));
            Console.WriteLine("{0}'s Account Balance: {1}", _toAccount.Name, _toAccount.Balance.ToString("C"));
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transfer already executed");
            }
            _executed = true;

            _withdraw.Execute();

            //Ensure withdrawal is successful, only then attempt deposit
            if (_withdraw.Success)
            {
                try
                {
                    _deposit.Execute();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Transaction unsuccessful");
                    //If deposit unsuccessful, attempt rollback to sender account
                    try
                    {
                        _withdraw.Rollback();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Rollback unsuccessful");
                    }
                }
            }
        }

        public void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Rollback already executed");
            }
            else if (!_withdraw.Success && !_deposit.Success)
            {
                throw new InvalidOperationException("Transfer was not successfully executed");
            }
            else
            {
                _deposit.Rollback();

                //First withdraw from recipient account, then deposit back to sender account
                if (_deposit.Reversed)
                {
                    try
                    {
                        _withdraw.Rollback();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Rollback unsuccessful");
                    }
                }
            }
            _reversed = true;
        }
    }
}
