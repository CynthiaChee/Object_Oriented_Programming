using System;

namespace Q5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int j = -5;
            while (sum <= 350)
            {
                sum += j;
                j += 5;
            }
            Console.WriteLine(sum);
            Console.WriteLine(j);

            int k = -5;
            int sum2 = 0;
            for (k = -5; sum2 <= 350; k+=5)
            {
                sum2 += k;
                
                
            }
            Console.WriteLine(sum2);
            Console.WriteLine(k);
        }
    }
}
