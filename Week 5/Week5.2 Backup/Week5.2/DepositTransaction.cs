using System;
namespace Week5._2
{
    class DepositTransaction
    {
        //Instance variables
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        //Constructor
        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        //Properties (read-only)
        public bool Executed
        {
            get
            {
                return _executed;
            }
        }

        public bool Success
        {
            get
            {
                return _success;
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
            Console.WriteLine("Account Name: " + _account.Name);
            Console.WriteLine("Account Balance: " + _account.Balance.ToString("C"));
            Console.WriteLine("Deposit amount: " + _amount.ToString("C"));
        }

        public void Execute()
        {
            if (_amount <= 0)
            {
                throw new InvalidOperationException("Deposit amount must be more than 0");
            }

            else if (_executed == true)
            {
                throw new InvalidOperationException("Transaction already executed");
            }

            else
            {
                _account.Balance += _amount;
                _executed = true;
                _success = true;
            }

        }

        public void Rollback()
        {
            if (_reversed == false)
            {
                _account.Balance -= _amount;
                _reversed = true;
            }
            else if (_reversed == true)
            {
                throw new InvalidOperationException("Rollback already executed");
            }
            else if (_success == false)
            {
                throw new InvalidOperationException("Transaction unsuccessful");
            }
        }
    }
}