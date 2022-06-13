using System;
using System.Collections.Generic;

namespace Week6._2
{
    class BankSystem
    {
        enum MenuOption
        {
            ADDACCOUNT,
            WITHDRAW,
            DEPOSIT,
            TRANSFER,
            PRINT,
            QUIT 
        }

        static MenuOption ReadUserOption()              //Options to choose what to do
        {
            int option;
            do
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add new account");
                Console.WriteLine("2. Withdraw money");
                Console.WriteLine("3. Deposit money");
                Console.WriteLine("4. Transfer money");
                Console.WriteLine("5. Print account details");
                Console.WriteLine("6. Quit");
                option = Convert.ToInt32(Console.ReadLine());

            } while (option < 1 || option > 6);

            MenuOption optionCast = (MenuOption)(option - 1);
            return optionCast;
        }

        static void AddAccount(Bank bank)
        {
            Console.WriteLine("Enter name of new account: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter starting balance of new account: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            Account newAcc = new Account(name, balance);
            bank.AddAccount(newAcc);
            newAcc.Print();
        }

        private static Account FindAccount(Bank bank)
        {
            Console.WriteLine("Enter account name: ");
            string toFind = Console.ReadLine();
            Account found = bank.GetAccount(toFind);
            if (found == null)
            {
                Console.WriteLine("Account not found");
            }
            return found;
        }

        static void DoDeposit(Bank bank)          //Deposits money into account
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                Console.WriteLine("Enter amount to deposit: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                DepositTransaction deposit = new DepositTransaction(account, amount);
                try
                {
                    bank.ExecuteTransaction(deposit);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Deposit unsuccessful");
                }
            }
        }

        static void DoWithdraw(Bank bank)         //Withdraws money from account
        {
            Account account = FindAccount(bank);

            if (account != null)
            {
                Console.WriteLine("Enter amount to withdraw: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                WithdrawTransaction withdraw = new WithdrawTransaction(account, amount);
                try
                {
                    bank.ExecuteTransaction(withdraw);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Withdraw unsuccessful");
                    return;
                }
            }
        }

        static void DoTransfer(Bank bank)      //Transfers money from one account to another
        {
            Account fromAcc = FindAccount(bank);
            Account toAcc = FindAccount(bank);
            if (fromAcc != null && toAcc != null)
            {
                Console.WriteLine("Enter amount to transfer: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                TransferTransaction transfer = new TransferTransaction(fromAcc, toAcc, amount);
                try
                {
                    bank.ExecuteTransaction(transfer);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Transfer unsuccessful");
                    return;
                }
            }
        }

        static void DoPrint(Bank bank)            //Prints account details
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                account.Print();
            }
            else { Console.WriteLine("No account found"); }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Bank bank = new Bank();

            MenuOption option;

            do
            {
                option = ReadUserOption();

                switch (option)
                {
                    case MenuOption.ADDACCOUNT:
                        AddAccount(bank);
                        break;
                    case MenuOption.WITHDRAW:
                        DoWithdraw(bank);
                        break;
                    case MenuOption.DEPOSIT:
                        DoDeposit(bank);
                        break;
                    case MenuOption.TRANSFER:
                        DoTransfer(bank);
                        break;
                    case MenuOption.PRINT:
                        DoPrint(bank);
                        break;
                    case MenuOption.QUIT:
                        Console.WriteLine("Thank you for banking with us. Have a nice day!");
                        break;
                }
            } while (option != MenuOption.QUIT);
        }

    }
}
