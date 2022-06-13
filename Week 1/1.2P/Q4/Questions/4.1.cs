using System;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 0, product = 0;
            while (c <= 5)
            {
                product = c * 5;
                c = c + 1;
            }

            Console.WriteLine("c is " + c + " product is " + product);
        }
    }
}
