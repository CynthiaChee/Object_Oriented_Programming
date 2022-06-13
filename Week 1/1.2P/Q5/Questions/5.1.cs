using System;

namespace Q5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int j = -5; sum <= 350; j += 5)
            {
                sum += j;
                Console.WriteLine("sum is " + sum + " j is " + j);
            }
        }
    }
}
