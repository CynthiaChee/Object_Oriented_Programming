using System;
using System.Collections.Generic;
namespace BucketSort
{
    static class AccountsSorter
    {
        public static void Sort(Account[] accounts, int b)      //b = number of buckets
        {
            //Find the maximum value of balance
            decimal M = accounts[0].Balance;

            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Balance > M)
                {
                    M = accounts[i].Balance;
                }
            }

            //Create the buckets
            List<Account>[] buckets = new List<Account>[b];

            for(int i = 0; i < b; i++)
            {
                buckets[i] = new List<Account>();
            }

            //Moves the values to their repective buckets
            for (int j = 0; j < accounts.Length; j++)
            {
                //The maximum value is placed in the last bucket
                int bucketIdx = (int)Math.Floor(b * accounts[j].Balance / M);
                if (accounts[j].Balance >= M)
                {
                    buckets[bucketIdx-1].Add(accounts[j]);
                }
                else
                {
                    buckets[bucketIdx].Add(accounts[j]);
                }
            }

            //Calls insertion sort on each bucket, then concatenates the sorted buckets into sortedAcc
            List<Account> sortedAcc = new List<Account>();
            for (int k = 0; k < b; k++)
            {
                if (buckets[k].Count > 0)    //if bucket not empty
                {
                    sortedAcc.AddRange(InsertionSort(buckets[k]));
                }
            }

            Print(sortedAcc);
        }

        public static List<Account> InsertionSort(List<Account> bucket)
        {
            //Implements insertion sort
            //i and j serve as pointers while key holds the smallest value to compare to
            int i, j;
            Account key = bucket[0];
            for (i = 1; i < bucket.Count; i++)
            {
                //If value in i is less than that of key, this value is stored in key
                if (bucket[i].Balance.CompareTo(key.Balance) < 0)
                {
                    key = bucket[i];
                    j = i - 1;

                    //While the value in j is greater than that of key, the larger values
                    //shift to the right to allow key value to be inserted into the correct position
                    while (j >= 0 && bucket[j].Balance.CompareTo(key.Balance) > 0)
                    {
                        bucket[j + 1] = bucket[j];
                        j--;
                    }
                    //key value inserted into correct position
                    bucket[j + 1] = key;
                }
            }
            return bucket;
        }

        public static void Sort(List<Account> accounts, int b)
        {
            //Find the maximum value of balance
            decimal M = accounts[0].Balance;

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Balance > M)
                {
                    M = accounts[i].Balance;
                }
            }

            //Create the buckets
            List<Account>[] buckets = new List<Account>[b];

            for (int i = 0; i < b; i++)
            {
                buckets[i] = new List<Account>();
            }

            //Moves the values to their repective buckets
            for (int j = 0; j < accounts.Count; j++)
            {
                //The maximum value is placed in the last bucket
                int bucketIdx = (int)Math.Floor(b * accounts[j].Balance / M);
                if (accounts[j].Balance >= M)
                {
                    buckets[bucketIdx - 1].Add(accounts[j]);
                }
                else
                {
                    buckets[bucketIdx].Add(accounts[j]);
                }
            }

            //Calls insertion sort on each bucket, then concatenates the sorted buckets into sortedAcc
            List<Account> sortedAcc = new List<Account>();
            for (int k = 0; k < b; k++)
            {
                if(buckets[k].Count > 0)    //if bucket not empty
                {
                    sortedAcc.AddRange(InsertionSort(buckets[k]));
                }
            }

            Print(sortedAcc);

        }

        //Outputs the sorted accounts to the terminal
        public static void Print(List<Account> sortedAcc)
        {
            for (int i = 0; i < sortedAcc.Count; i++)
            {
                Console.WriteLine("{0} {1}", sortedAcc[i].Name, sortedAcc[i].Balance.ToString("C"));
            }
        }

    }
    
}
