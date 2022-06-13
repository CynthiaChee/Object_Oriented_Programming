using System;

namespace Week1DivisibleFour
{
    class DivisibleFour
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("List of numbers divisible by 4 AND not divisible by 5 between 1 and " + n);
            for(int i = 1; i <= n; i++)
            {
                if (i%4 == 0 && i%5 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
