using System;

namespace Week1SwitchStatement
{
    class SwitchStatement
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number (as an integer): ");
                int number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1: Console.WriteLine("One"); break;
                    case 2: Console.WriteLine("Two"); break;
                    case 3: Console.WriteLine("Three"); break;
                    case 4: Console.WriteLine("Four"); break;
                    case 5: Console.WriteLine("Five"); break;
                    case 6: Console.WriteLine("Six"); break;
                    case 7: Console.WriteLine("Seven"); break;
                    case 8: Console.WriteLine("Eight"); break;
                    case 9: Console.WriteLine("Nine"); break;
                    default: Console.WriteLine("Error: You must enter an integer between 1 and 9"); break;
                }
            }
            catch
            {
                Console.WriteLine("Error: Please enter an integer");
            }
        }
    }
}
/* When an integer outside the range is entered, the default case runs which shows the error message. When a string is entered,
 * an unhandled exception message appears in the terminal. By implementing try-catch, a custom message appears instead. */