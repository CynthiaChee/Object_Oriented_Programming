using System;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            Console.WriteLine(DAYS_IN_MONTHS[1]);
            Console.WriteLine(MONTHS[6]);
            Console.WriteLine(DAYS[5]);
            Console.WriteLine("Enter month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(DAYS_IN_MONTHS[month-1]);
            Console.WriteLine(MONTHS[month-1]);
            Console.WriteLine(DAYS[5]);*/

            MyDate date = new MyDate(2023, 9, 17);
            Console.WriteLine(date.getDay());
            Console.WriteLine(date.getMonth());
            Console.WriteLine(date.getYear());
            date.setDay(240);
            date.setMonth(50);
            date.setYear(30000);
            Console.WriteLine(date.getDay());
            Console.WriteLine(date.getMonth());
            Console.WriteLine(date.getYear());
            date.setDate(3050, 3, 31);
            Console.WriteLine(date.getDay());
            Console.WriteLine(date.getMonth());
            Console.WriteLine(date.getYear());
            MyDate next = date.nextDay();
            Console.WriteLine(next.getDay());
            Console.WriteLine(next.getMonth());
            Console.WriteLine(next.getYear());
        }
    }
}
