using System;
using System.Collections.Generic;

namespace BucketSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Account john = new Account("John", 1256.3m);
            Account david = new Account("David", 1578.5m);
            Account emily = new Account("Emily", 3421.5m);
            Account sasha = new Account("Sasha", 2212.7m);
            Account arnold = new Account("Arnold", 2769.8m);
            Account vivian = new Account("Vivian", 1970);
            Account hugh = new Account("Hugh", 3506.1m);
            Account ivy = new Account("Ivy", 807.55m);
            Account kate = new Account("Kate", 4050);
            Account maurice = new Account("Maurice", 1688.7m);

            Account[] accounts = { john, david, emily, sasha, arnold, vivian, hugh, ivy, kate, maurice };

            List<Account> listAcc = new List<Account>();
            listAcc.Add(new Account("Tatyana", 5843.3m));
            listAcc.Add(new Account("Ezekiel", 3042.5m));
            listAcc.Add(new Account("Jackie", 6053.5m));
            listAcc.Add(new Account("Charles", 1112.7m));
            listAcc.Add(new Account("Freda", 3055.8m));
            listAcc.Add(new Account("Gerald", 600));
            listAcc.Add(new Account("Olivia", 998.9m));
            listAcc.Add(new Account("Rick", 1357.9m));
            listAcc.Add(new Account("Sonia", 4007));
            listAcc.Add(new Account("Natasha", 5450m));

            Console.WriteLine("Sorted array: ");
            AccountsSorter.Sort(accounts, 5);

            Console.WriteLine();

            Console.WriteLine("Sorted list: ");
            AccountsSorter.Sort(listAcc, 8);

        }
    }
}