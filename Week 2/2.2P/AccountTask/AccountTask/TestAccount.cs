using System;

namespace AccountTask
{
    class TestAccount
    {
        static void Main(string[] args)
        {
            Account john = new Account("John", 1000);
            john.Print();
            Console.WriteLine();
            john.Deposit(5500);
            john.Withdraw(4800);
            Console.WriteLine();
            john.Print();
        }
    }
}

/* Link to video explanation: https://2006242.kaf.kaltura.com/media/t/1_m3rffq5r#
 * (Alternative link): https://drive.google.com/file/d/1k7xZWUsBpXgdlSeQrd5kDAQJqy-3RgjA/view?usp=sharing */