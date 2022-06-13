using System;

namespace Week1GuessingNumber
{
    class GuessingNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to be guessed between 1 and 10: "); //Prompt for number to guess
            int number = PromptInput();
            Console.WriteLine("Guess a number between 1 and 10: ");               //Guess the number
            int guess = PromptInput();

            while (guess != number)
            {
                if (guess < 1 || guess > 10)        //If out of range
                {
                    Console.WriteLine("Please enter a number between 1 and 10: ");
                    guess = Convert.ToInt32(Console.ReadLine());
                }

                else if (guess != number)      //If guess incorrect
                {
                    Console.WriteLine("Thats not right, try again.");
                    guess = Convert.ToInt32(Console.ReadLine());
                }
            }
            if (guess == number)            //If guess correct
            {
                Console.WriteLine("You have guessed the number! Well done!");
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
                    Console.WriteLine("Please enter an integer");
                }
            }
        }
    }
}
