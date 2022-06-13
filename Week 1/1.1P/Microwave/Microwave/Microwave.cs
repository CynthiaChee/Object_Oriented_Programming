using System;

namespace Week1Microwave
{
    class Microwave
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of items to heat: ");
            int items = PromptInput();
            Console.WriteLine("Enter heating time for single item in minutes: ");
            int singletime = PromptInput();
            double heattime;

            if (items == 1)
            {
                heattime = singletime;
                Console.WriteLine("Heating time required is {0} minutes", heattime);
            }
            else if (items == 2)
            {
                heattime = singletime * 1.5;
                Console.WriteLine("Heating time required is {0} minutes", heattime);
            }
            else if (items == 3)
            {
                heattime = singletime * 2;
                Console.WriteLine("Heating time required is {0} minutes", heattime);
            }
            else if (items > 3)
            {
                Console.WriteLine("It is not recommended to heat more than 3 items at once");
            }

            else if (items == 0)
            {
                Console.WriteLine("There is nothing to heat");
            }
        }

        private static int PromptInput()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a valid value");
                }
            }
        }

    }
}
