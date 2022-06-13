using System;
using System.Collections.Generic;

namespace ExceptionHandling
{

    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Balance { get; private set; }

        public Account(string firstName, string lastName, int balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient fund");
            }
            Balance = Balance - amount;
        }

        public string getFirstName()
        {
            return FirstName;
        }

        public string getLastName()
        {
            return LastName;
        }
    }

    class Program
    {
        public static void Main()
        {
            //try
            //{
            //    Account account = new Account("Sergey", "P", 100);
            //    account.Withdraw(1000);
            //}
            //catch (InvalidOperationException exception)
            //{
            //    Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            //}

            //Console.ReadKey();

            //1. NullReference test
            NullReference();
            NullReferenceTwo();

            //2. IndexOutOfRange test
            PrintNumbers();

            //3. StackOverflow test
            Overflow(2);

            //4.OutOfMemory test
            try
            {
                Memory();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Ran out of memory");
            }

            //5. DivideByZero test
            try
            {
                Console.WriteLine("Enter numerator: ");
                int numerator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter denominator: ");
                int denominator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Division result is " + Division(numerator, denominator).ToString());
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Denominator cannot be zero!");
            }

            //6. ArgumentNull test
            Account nullAcc = new Account(null, null, 0);
            try
            {
                PrintName(nullAcc.getFirstName(), nullAcc.getLastName());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Name cannot be null!");
            }

            //7. ArgumentOutOfRange test
            try
            {
                Console.WriteLine("Enter your weight in lbs: ");
                double pounds = Convert.ToDouble(Console.ReadLine());
                double converted = ConvertWeight(pounds);
                Console.WriteLine("Your weight in kg is: {0:F} kg", converted);
                CheckWeight(converted);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You are too light or too heavy for the ride!");
            }

            //8. FormatException test
            try
            {
                Console.WriteLine("Guess a number between 1 and 10");
                int guess = Convert.ToInt32(Console.ReadLine());
                GuessNumber(guess);
            }
            catch (FormatException)
            {
                Console.WriteLine("Guess a NUMBER!");
            }

            //9. SystemException test
            Account anotherAcc = new Account("Spongebob", "Squarepants", 500);
            try
            {
                Cast(anotherAcc);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Error, unable to cast");
            }

        }
        //METHODS
        //1. NullReferenceException
        static void NullReference()
        {
            string name = null;
            name.ToUpper();
        }
        public static void NullReferenceTwo()
        {
            int[] array = null;
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        //2. IndexOutOfRangeException
        static void PrintNumbers()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        //3. StackOverflowException
        static void Overflow(int value)
        {
            Console.WriteLine(value);
            Overflow(value += 5);
        }

        //4. OutOfMemoryException
        static void Memory()
        {
            List<String> longList = new List<String>();
            while (longList.Count <= int.MaxValue)
            {
                longList.Add("Longer");
            }
        }

        //5. DivideByZeroException
        static int Division(int numerator, int denominator)
        {
            int result = numerator / denominator;
            return result;
        }

        //6. ArgumentNullException
        static void PrintName(string first, string last)
        {
            if (first == null || last == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Console.WriteLine("Hello, " + first + " " + last);
            }
        }

        //7. ArgumentOutOfRangeException
        static double ConvertWeight(double pounds)
        {
            double kg = pounds / 2.205;
            return kg;
        }

        static void CheckWeight(double weight)
        {
            if (weight <= 50 || weight >= 90)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Console.WriteLine("Great! You can take this ride!");
            }
        }

        //8. FormatException
        static void GuessNumber(int guess)
        {
            int answer = 7;
            if (guess == answer)
            {
                Console.WriteLine("Congrats, you've guessed it!");
            }
            else
            {
                Console.WriteLine("Nope, that wasn't it");
            }
        }
        static void GotMoney()
        {
            decimal money = 17.35m;
            Console.WriteLine("I have {0:D} in my wallet", money);
        }

        //9. SystemException (e.g InvalidCastException)
        static void Cast(Account someAcc)
        {
            int anotherInt = Convert.ToInt32(someAcc);
            Console.WriteLine(anotherInt);
        }
    }
}
