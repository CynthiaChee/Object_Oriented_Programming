using System;

namespace Week1Casting
{
    class DoCasting
    {
        static void Main(string[] args)
        {
            int sum = 17;
            int count = 5;
            int intAverage = sum / count;
            Console.WriteLine("Value of intAverage is: {0}", intAverage);       //Outputs 3

            double doubleAverage = sum / count;             
            Console.WriteLine("Value of doubleAverage is: {0}", doubleAverage); //Outputs 3

            double doubleAverageCast = (double)sum / count;         //unary casting
            Console.WriteLine("Value of doubleAverage after casting is: {0}", doubleAverageCast);   //Outputs 3.4
        }
    }
}
