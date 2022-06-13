using System;

namespace Repetition
{
    class Repetition
    {
        static void Main(string[] args)
        {
            int sum = 0;
            double average;
            int upperbound = 100;
            int number = 1;

            while (number <= upperbound)
            {
                sum += number;
                number++;
                Console.WriteLine("Current number: " + number + " The sum is " + sum);
            }

            average = (double)sum / upperbound;     //casting

            Console.WriteLine("Sum is: " + sum);                //returns 5050
            Console.WriteLine("Upper bound is: " + upperbound); //returns 100
            Console.WriteLine("Average is: " + average);        //returns 50.5
        }
    }
}
