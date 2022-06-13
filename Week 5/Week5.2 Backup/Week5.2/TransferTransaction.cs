using System;
namespace Week5._2
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
        private bool _success;
        private bool _reversed;

        //Constructor
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
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
            Console.WriteLine("Sender Account Name: " + _fromAccount.Name);
            Console.WriteLine("Sender Account Balance: " + _fromAccount.Balance.ToString("C"));
            Console.WriteLine("Recipient Account Name: " + _toAccount.Name);
            Console.WriteLine("Recipient Account Balance: " + _toAccount.Balance.ToString("C"));
            Console.WriteLine("Transfer amount: " + _amount.ToString("C"));
        }

        public void Execute()
        {
            if (_amount > _fromAccount.Balance)
            {
                throw new InvalidOperationException("Transfer amount exceeded account balance");
            }

            else if (_executed == true)
            {
                throw new InvalidOperationException("Transaction already executed");
            }

            else
            {
                _fromAccount.Balance -= _amount;
                _toAccount.Balance += _amount;
                _executed = true;
                _success = true;
            }

        }

        public void Rollback()
        {
            if (_reversed == false && (_toAccount.Balance >= _amount))
            {
                _fromAccount.Balance += _amount;
                _toAccount.Balance -= _amount;
                _reversed = true;
            }
            else if (_reversed == false && (_toAccount.Balance < _amount))
            {
                throw new InvalidOperationException("Insufficient balance in recipient account for rollback");
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
