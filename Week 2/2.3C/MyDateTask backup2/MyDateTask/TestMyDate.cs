using System;

namespace MyDateTask
{
    class TestMyDate
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MyDate!");
            MyDate date = new MyDate(21, 7, 2021);

            //Testing
            date.NextDay().NextDay().PreviousDay();
            date.NextMonth().NextMonth().PreviousMonth();
            date.NextYear().PreviousYear().PreviousYear();
            date.SetYear(5000);
            date.SetMonth(6);
            date.SetDay(15);

            //For easier testing
            Console.WriteLine("The date is: " + date.ToString());
            int option;
            do
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Change date");
                Console.WriteLine("2. Next day");
                Console.WriteLine("3. Next month");
                Console.WriteLine("4. Next year");
                Console.WriteLine("5. Previous day");
                Console.WriteLine("6. Previous month");
                Console.WriteLine("7. Previous year");
                Console.WriteLine("8. Quit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Set new day: ");
                        int newDate = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Set new month: ");
                        int newMonth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Set new year: ");
                        int newYear = Convert.ToInt32(Console.ReadLine());
                        date.SetDate(newDate, newMonth, newYear);
                        Console.WriteLine("New date: " + date.ToString());
                        break;
                    case 2:
                        Console.WriteLine("Next day: " + date.NextDay().ToString());
                        break;
                    case 3:
                        Console.WriteLine("Next month: " + date.NextMonth().ToString());
                        break;
                    case 4:
                        Console.WriteLine("Next year: " + date.NextYear().ToString());
                        break;
                    case 5:
                        Console.WriteLine("Previous day: " + date.PreviousDay().ToString());
                        break;
                    case 6:
                        Console.WriteLine("Previous month: " + date.PreviousMonth().ToString());
                        break;
                    case 7:
                        Console.WriteLine("Previous year: " + date.PreviousYear().ToString());
                        break;
                    case 8:
                        Console.WriteLine("Have a nice day!");
                        break;
                }
            } while (option != 8);
            

        }
    }
}
