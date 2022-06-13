using System;
namespace Week7._1
{
    abstract class Transaction
    {
        //protected: accessible by members of base class and its derived classes
        protected decimal _amount;
        protected bool _success;
        private bool _executed;
        private bool _reversed;
        private DateTime _dateStamp;

        public abstract bool Success
        {
            get;
        }

        public bool Executed => _executed;

        public bool Reversed => _reversed;

        public DateTime DateStamp => _dateStamp;

        public Transaction(decimal amount)
        {
            _amount = amount;
        }

        public abstract void Print();

        public abstract void RollbackPrint();

        public virtual void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transaction already executed");
            }
            _executed = true;
            _success = true;
            _dateStamp = DateTime.Now;
            if (!_success)
            {
                throw new InvalidOperationException("Transaction unsuccessful");
            }
        }

        public virtual void Rollback()
        {
            if (!_success)
            {
                throw new InvalidOperationException("Transaction was previously not successfully executed");
            }
            else if (_reversed)
            {
                throw new InvalidOperationException("Rollback already executed");
            }
            _reversed = true;
            _dateStamp = DateTime.Now;
            _executed = false;
        }

    }
}
