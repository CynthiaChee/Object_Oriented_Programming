using System;
using System.Collections.Generic;

namespace Week7._1
{
    class Bank
    {
        private List<Account> _accounts = new List<Account>();
        private List<Transaction> _transactions = new List<Transaction>();

        public Bank()
        {
        }

        public List<Transaction> Transactions => _transactions;

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetAccount(String name)
        {
            foreach (Account account in _accounts)
            {
                if (name.ToLower() == account.Name.ToLower())
                {
                    return account;
                }
            }
            return null;
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            transaction.Execute();
            transaction.Print();
        }

        public void RollbackTransaction(Transaction transaction)
        {
            transaction.Rollback();
            transaction.RollbackPrint();
        }

        public void PrintTransactionHistory()
        {
            for (int i = 0; i < _transactions.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Transaction No. {i+1}: ");
                Console.WriteLine(_transactions[i].DateStamp);
                _transactions[i].Print();
                Console.WriteLine();
            }
        }
    }
}
