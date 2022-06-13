using System;
using System.Collections.Generic;

namespace Week6._2
{
    class Bank
    {
        private List<Account> _accounts = new List<Account>();

        public Bank()
        {
        }

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

        public void ExecuteTransaction(DepositTransaction transaction)
        {
            transaction.Execute();
            transaction.Print();
        }

        public void ExecuteTransaction(WithdrawTransaction transaction)
        {
            transaction.Execute();
            transaction.Print();
        }

        public void ExecuteTransaction(TransferTransaction transaction)
        {
            transaction.Execute();
            transaction.Print();
        }
    }
}
