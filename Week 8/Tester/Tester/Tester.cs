using System;
using System.Collections.Generic;
namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<Account> myStack = new MyStack<Account>(5);
            myStack.Push(new Account("One", 1501));
            myStack.Push(new Account("Two", 2360.2m));
            myStack.Push(new Account("Three", 5321.3m));
            myStack.Push(new Account("Four", 1829.7m));
            myStack.Push(new Account("Five", 778.5m));

            MyStack<Account> anotherStack = new MyStack<Account>(10);
            anotherStack.Push(new Account("Sam", 1605));
            anotherStack.Push(new Account("Tamara", 3456.7m));
            anotherStack.Push(new Account("Sam", 2170));
            anotherStack.Push(new Account("Bruce", 800));
            anotherStack.Push(new Account("Aiden", 3456.7m));
            anotherStack.Push(new Account("Jackie", 800));
            anotherStack.Push(new Account("Sam", 1474));
            anotherStack.Push(new Account("Manuel", 800));
            anotherStack.Push(new Account("Tamara", 1474));
            anotherStack.Push(new Account("Louis", 4000));

            MyStack<Account> thirdStack = new MyStack<Account>(5);
            thirdStack.Push(new Account("Credit card", 500));
            thirdStack.Push(new Account("Short term deposit", 2500));
            thirdStack.Push(new Account("Credit card", 1650));
            thirdStack.Push(new Account("Credit card", 2100));
            thirdStack.Push(new Account("Short term deposit", 730));

            //Testing Find method
            //========================
            decimal toFind = 1829.7m;
            Account found = myStack.Find(x => x.Balance == toFind);
            Console.WriteLine($"Account {found.Name} has balance {toFind:C}");


            //Testing FindAll with various criteria
            //========================================
            Account[] filtered = anotherStack.FindAll(y => y.Balance == 800);
            //Account[] filtered = anotherStack.FindAll(y => y.Name == "Sam");
            //Account[] filtered = anotherStack.FindAll(y => y.Balance > 2000);
            foreach (Account account in filtered)
            {
                Console.WriteLine($"{account.Name}: {account.Balance:C}");
            }
            Console.WriteLine("There are {0} accounts found", filtered.Length);


            Account[] credit = thirdStack.FindAll(y => y.Name.ToLower() == "credit card");
            foreach (Account account in credit)
            {
                Console.WriteLine($"{account.Name}: {account.Balance:C}");
            }
            Console.WriteLine("There are {0} accounts found", credit.Length);

            //Testing RemoveAll method
            //==============================
            int removed = anotherStack.RemoveAll(z => z.Balance > 1500);
            Console.WriteLine("Removed {0} accounts", removed);
            Console.WriteLine("There are {0} accounts left", anotherStack.Count);

            //Testing Max and Min methods
            //===============================
            Account max = anotherStack.Max();
            Account min = anotherStack.Min();

            Console.WriteLine($"Max: {max.Name} with {max.Balance:C}");
            Console.WriteLine($"Min: {min.Name} with {min.Balance:C}");

            MyStack<Account> emptyStack = new MyStack<Account>(0);
            try
            {
                Account largest = emptyStack.Max();
                Console.WriteLine($"Max: {largest.Name} with {largest.Balance:C}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("There are no accounts");
            }

        }
    }
}
