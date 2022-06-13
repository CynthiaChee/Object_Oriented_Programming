using System;

namespace Week5._2
{
    class BankSystem
    {
        enum MenuOption
        {
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
                Console.WriteLine("1. Withdraw money");
                Console.WriteLine("2. Deposit money");
                Console.WriteLine("3. Transfer money");
                Console.WriteLine("4. Print account details");
                Console.WriteLine("5. Quit");
                option = Convert.ToInt32(Console.ReadLine());

            } while (option < 1 || option > 5);

            MenuOption optionCast = (MenuOption)(option - 1);
            return optionCast;
        }

        static void DoDeposit(Account account)          //Deposits money into account
        {
            Console.WriteLine("Enter amount to deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            DepositTransaction deposit = new DepositTransaction(account, amount);
            deposit.Execute();
            deposit.Print();
        }

        static void DoWithdraw(Account account)         //Withdraws money from account
        {
            Console.WriteLine("Enter amount to withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            WithdrawTransaction withdraw = new WithdrawTransaction(account, amount);
            withdraw.Execute();
            withdraw.Print();
        }

        static void DoTransfer(Account fromAccount, Account toAccount)      //Transfers money from one account to another
        {
            Console.WriteLine("Enter amount to transfer: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
            transfer.Execute();
            transfer.Print();
        }

        static void DoPrint(Account account)            //Prints account details
        {
            account.Print();
        }

        static void Main(string[] args)
        {
            Account john = new Account("John", 1000);
            Account shannon = new Account("Shannon", 2500);
            Account caroline = new Account("Caroline", 4680);
            Account derek = new Account("Derek", 3285);
            john.Print();
            shannon.Print();
            caroline.Print();
            derek.Print();
            Console.WriteLine();

            //Testing all transactions and exception-causing situations
            /*WithdrawTransaction withdraw = new WithdrawTransaction(john, 300);
            withdraw.Execute();
            withdraw.Print();
            withdraw.Rollback();
            withdraw.RollbackPrint();

            DepositTransaction deposit = new DepositTransaction(caroline, 1000);
            deposit.Execute();
            deposit.Rollback();
            deposit.Rollback();

            TransferTransaction transfer = new TransferTransaction(derek, shannon, 500);
            transfer.Execute();
            transfer.Execute();
            transfer.Print();
            WithdrawTransaction withdraw = new WithdrawTransaction(shannon, 2600);
            withdraw.Execute();
            transfer.Rollback();
            transfer.RollbackPrint();
            transfer.Rollback();
            transfer.RollbackPrint();*/

            MenuOption option;

            do
            {
                option = ReadUserOption();

                switch (option)
                {
                    case MenuOption.WITHDRAW:
                        DoWithdraw(john);
                        break;
                    case MenuOption.DEPOSIT:
                        DoDeposit(john);
                        break;
                    case MenuOption.TRANSFER:
                        DoTransfer(john, caroline);
                        break;
                    case MenuOption.PRINT:
                        DoPrint(john);
                        break;
                    case MenuOption.QUIT:
                        Console.WriteLine("Thank you for banking with us. Have a nice day!");
                        break;
                }
            } while (option != MenuOption.QUIT);
        }

    }
}
