using System;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 31, b = 0, sum = 0;
            while (a >= b)
            {
                sum = sum + a;
                b = b + 2;
            }

            Console.WriteLine("a is " + a + " b is " + b + " sum is " + sum);
        }
    }
}
