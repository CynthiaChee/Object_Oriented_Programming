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
            Console.WriteLine("{0} deposited into {1}'s account", _amount.ToString("C"), _account.Name);
            Console.WriteLine("Deposit amount: " + _amount.ToString("C"));
            Console.WriteLine("Account Balance: " + _account.Balance.ToString("C"));
        }

        public void RollbackPrint()
        {
            Console.WriteLine("Transaction details: ");
            Console.WriteLine("=========================");
            Console.WriteLine("Rollback done: {0} withdrawn from {1}'s account", _amount.ToString("C"), _account.Name);
            Console.WriteLine("Account Balance: " + _account.Balance.ToString("C"));
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Deposit already executed");
            }
            _executed = true;
            _success = _account.Deposit(_amount);

            if (!_success)
            {
                throw new InvalidOperationException("Deposit unsuccessful");
            }
        }

        public void Rollback()
        {
            if (!_success)
            {
                throw new InvalidOperationException("Deposit was not successfully executed");
            }
            else if (_reversed)
            {
                throw new InvalidOperationException("Rollback already executed");
            }

            _reversed = _account.Withdraw(_amount);
            if (!_reversed)
            {
                throw new InvalidOperationException("Rollback unsuccessful");
            }
            _reversed = true;
        }
    }
}