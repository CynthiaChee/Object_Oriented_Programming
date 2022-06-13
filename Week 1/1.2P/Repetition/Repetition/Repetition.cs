using System;

namespace Week1Repetition
{
    class Repetition
    {
        static void Main(string[] args)
        {
            int sum = 0;
            double average;
            int upperbound = 100;
            int number = 1;

            do
            {
                sum += number;
                number++;
            } while (number <= 100);

            average = (double)sum / upperbound;     //casting

            Console.WriteLine("Sum is: " + sum);                //returns 5050
            Console.WriteLine("Upper bound is: " + upperbound); //returns 100
            Console.WriteLine("Average is: " + average);        //returns 50.5
        }
    }
}
/* do...while executes the loop once before checking the condition. While loops start with the condition checking, so the instructions
 * inside the loop may or may not be executed. for loops allow the implementation of repetitions with a single line of code with format:
 * (initialization; condition; increment) */