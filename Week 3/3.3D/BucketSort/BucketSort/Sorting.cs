using System;
using System.Collections.Generic;
namespace BucketSort
{
    static class Sorting
    {
        public static void Sort(List<Account> accounts, int b)
        {
            //Find the maximum and minimum values of balance in the array
            decimal maximum = accounts[0].Balance, minimum = accounts[0].Balance;

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Balance > maximum)
                {
                    maximum = accounts[i].Balance;
                }
                else if (accounts[i].Balance < minimum)
                {
                    minimum = accounts[i].Balance;
                }
            }

            //Create the buckets
            List<decimal>[] buckets = new List<decimal>[b];

            for (int i = 0; i < b; i++)
            {
                buckets[i] = new List<decimal>();
            }

            //Moves the values to their repective buckets
            for (int j = 0; j < accounts.Count; j++)
            {
                int bucketIdx = (int)Math.Floor(b * accounts[j].Balance / maximum);
                if (accounts[j].Balance >= maximum)
                {
                    buckets[bucketIdx - 1].Add(accounts[j].Balance);
                }
                else
                {
                    buckets[bucketIdx].Add(accounts[j].Balance);
                }
            }


        }

        public static List<Account> InsertionSort(List<Account> bucket)
        {
            //Implements insertion sort
            int i, j;
            Account key = bucket[0];
            //Compares element [key] to the one before it
            //if [key] element is smaller than the previous value, compare to the one before the previous value
            //Shifts the larger values to the right to allow insertion of [key] value at correct index

            for (i = 1; i < bucket.Count; i++)
            {
                if (bucket[i].Balance.CompareTo(key) < 0)
                {
                    key = bucket[i];
                    j = i - 1;
                    while (j >= 0 && bucket[j].Balance.CompareTo(key) > 0)
                    {
                        bucket[j + 1] = bucket[j];
                        j--;
                    }
                    bucket[j + 1] = key;
                }
            }
            return bucket;

        }
    }
}