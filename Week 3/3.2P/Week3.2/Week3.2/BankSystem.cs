using System;

namespace Week3._2
{
    class BankSystem
    {
        enum MenuOption
        {
            WITHDRAW,
            DEPOSIT,
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
                Console.WriteLine("3. Print account details");
                Console.WriteLine("4. Quit");
                option = Convert.ToInt32(Console.ReadLine());

            } while (option < 1 || option > 4);

            MenuOption optionCast = (MenuOption)(option - 1);
            return optionCast;
        }

        static void DoDeposit(Account account)          //Deposits money into account
        {
            Console.WriteLine("Enter amount to deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            account.PrintDeposit(account.Deposit(amount));
        }

        static void DoWithdraw(Account account)         //Withdraws money from account
        {
            Console.WriteLine("Enter amount to withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            account.PrintWithdraw(account.Withdraw(amount));
        }

        static void DoPrint(Account account)            //Prints account details
        {
            account.Print();
        }

        static void Main(string[] args)
        {
            Account john = new Account("John", 1000);
            john.Print();

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
