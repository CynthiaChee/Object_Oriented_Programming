using System;

namespace Week1IfStatement
{
    class IfStatement
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number (as an integer): ");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 1)
                {
                    Console.WriteLine("ONE");
                }
                else if (number == 2)
                {
                    Console.WriteLine("TWO");
                }
                else if (number == 3)
                {
                    Console.WriteLine("THREE");
                }
                else if (number == 4)
                {
                    Console.WriteLine("FOUR");
                }
                else if (number == 5)
                {
                    Console.WriteLine("FIVE");
                }
                else if (number == 6)
                {
                    Console.WriteLine("SIX");
                }
                else if (number == 7)
                {
                    Console.WriteLine("SEVEN");
                }
                else if (number == 8)
                {
                    Console.WriteLine("EIGHT");
                }
                else if (number == 9)
                {
                    Console.WriteLine("NINE");
                }
                else
                {
                    Console.WriteLine("Please enter an integer between 1 and 9");
                }
            }
            catch
            {
                Console.WriteLine("Error: Please enter an integer");
            }
        }
    }
}
/* When an integer outside the range/negative value/letter is entered, the program simply terminates. Adding an else statement
 * allows the message "Please enter a valid integer" to be output to the terminal if an integer outside the range is entered
 * if the user enters a string instead, an unhandled exception occurs. Using the try-catch, the message to enter an integer will
 * appear instead if a string is entered.*/
