using System;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int total = 0;
            while (x <= 10)
            {
                total = total + x;
                x = x + 1;
            }

            Console.WriteLine("x is " + x + " total is " + total);
        }
    }
}
