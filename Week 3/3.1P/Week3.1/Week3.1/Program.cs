using System;
using System.Collections.Generic;

namespace Week3._1
{
    class Program
    {
        /*TASK(9) Creating a static method that merges two sorted Lists and returns null if either list is unsorted
        ============================================================================================================*/
        static void Main(string[] args)
        {
            List<int> list_a = new List<int>();
            List<int> list_b = new List<int>();

            Console.WriteLine("Enter size for List A: ");   //Input values into List A
            int listASize = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < listASize; i++)
            {
                Console.WriteLine("Enter value to add to List A ({0}): ", i + 1);
                list_a.Add(Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("Enter size for List B: ");   //Input values into List B
            int listBSize = Convert.ToInt32(Console.ReadLine());
            for (int j = 0; j < listBSize; j++)
            {
                Console.WriteLine("Enter value to add to List B ({0}): ", j + 1);
                list_b.Add(Convert.ToInt32(Console.ReadLine()));
            }

            List<int> list_c = new List<int>();         //List C is the merged list
            list_c = Merge(list_a, list_b);
            Console.WriteLine("Merged List: ");
            try
            {
                for (int i = 0; i < list_c.Count; i++)
                {
                    Console.Write(list_c[i] + " ");
                }
            }
            catch
            {
                Console.WriteLine("Unable to merge lists"); //If both lists are empty or any list is unsorted
            }
        }

        static bool checkSort(List<int> listToCheck)    //Checks if the lists are sorted
        {
            for (int i = (listToCheck.Count - 1); i > 0; i--)
            {
                if (listToCheck[i] < listToCheck[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkEmpty(List<int> listToCheck)   //Checks if any list is empty
        {
            return listToCheck.Count == 0 ? true : false;
        }

        static List<int> Merge(List<int> list_a, List<int> list_b)
        {
            List<int> list_c = new List<int>();
            if (checkEmpty(list_a) || checkEmpty(list_b))
            {
                if (!checkEmpty(list_a))
                {
                    return checkSort(list_a) ? list_a : null;
                }
                else if (!checkEmpty(list_b))
                {
                    return checkSort(list_b) ? list_b : null;
                }
                else { return null; }
            }
            else    //if both lists are not empty
            {
                if (checkSort(list_a) && checkSort(list_b))     //if both lists are sorted
                {
                    int i = 0, j = 0;
                    while (i < list_a.Count && j < list_b.Count)
                    {
                        if (list_a[i] <= list_b[j])
                        {
                            list_c.Add(list_a[i]);
                            i++;
                        }
                        else
                        {
                            list_c.Add(list_b[j]);
                            j++;
                        }
                    }
                    while (i < list_a.Count)
                    {
                        list_c.Add(list_a[i]);
                        i++;
                    }
                    while (j < list_b.Count)
                    {
                        list_c.Add(list_b[j]);
                        j++;
                    }
                    return list_c;
                }
                else        //if any of the lists are unsorted
                {
                    return null;
                }
            }
        }

    }
}



//TASK(1) Creating an array of doubles and manually input + print values
//==================================================================================
double[] myArray = new double[10];
myArray[0] = 1.0;
myArray[1] = 1.1;
myArray[2] = 1.2;
myArray[3] = 1.3;
myArray[4] = 1.4;
myArray[5] = 1.5;
myArray[6] = 1.6;
myArray[7] = 1.7;
myArray[8] = 1.8;
myArray[9] = 1.9;
Console.WriteLine(myArray[0]);
Console.WriteLine(myArray[1]);
Console.WriteLine(myArray[2]);
Console.WriteLine(myArray[3]);
Console.WriteLine(myArray[4]);
Console.WriteLine(myArray[5]);
Console.WriteLine(myArray[6]);
Console.WriteLine(myArray[7]);
Console.WriteLine(myArray[8]);
Console.WriteLine(myArray[9]);

//TASK (2) Using for loops to assign values to array and to print the values
//==================================================================================
int[] myArray = new int[10];

            for (int i = 0; i < 10; i++)
            {
                myArray[i] = i;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("The element at position " + i + " in the array is " + myArray[i]);
            }

//TASK (3) Using arrays and for loops for calculating average mark
//==================================================================================
int[] studentArray = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };
int total = 0;

for (int i = 0; i < studentArray.Length; i++)
{
    total += studentArray[i];
}

Console.WriteLine("The total marks for the student is: " + total);
Console.WriteLine("This consist of " + studentArray.Length + " marks");
Console.WriteLine("Therefore the average mark is " + (total / studentArray.Length));


//TASK(4) Prompting input from user for student names, then printing out the names
//==================================================================================
 string[] studentNames = new string[6];

            for (int i = 0; i < studentNames.Length; i++)   //Prompts user input for student names
            {
                Console.WriteLine("Enter a student name: ");
                studentNames[i] = Console.ReadLine();
            }

            Console.WriteLine("List of students: ");        //Prints all inputted student names
            for (int j = 0; j < studentNames.Length; j++)
            {
                Console.WriteLine(studentNames[j]);
            }

//TASK(5) Prompting input for an array of doubles, then printing the largest and smallest values
//================================================================================================
            double[] numArray = new double[10];
            int currentSize = 0;

            for (int i = 0; i < numArray.Length; i++)   //Prompts user input for numbers
            {
                Console.WriteLine("Enter a number ({0}): ", i+1);
                numArray[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("List of numbers: ");

            double currentLargest = numArray[0];
            for (int k = 0; k < numArray.Length; k++)
            {
                if (numArray[k] > currentLargest)
                {
                    currentLargest = numArray[k];
                }
                Console.Write(numArray[k] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Largest value in the array is " + currentLargest);

            double currentSmallest = numArray[0];
            for (int j = 0; j < numArray.Length; j++)
            {
                if (numArray[j] < currentSmallest)
                {
                    currentSmallest = numArray[j];
                }
                Console.Write(numArray[j] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Smallest value in the array is " + currentSmallest);


//TASK(6) Creating a multidimensional array and printing it using nested for loops
//==================================================================================
            int[,] myArray = new int[3, 4] { { 1, 2, 3, 4 }, { 1, 1, 1, 1 }, { 2, 2, 2, 2 } };
            int value = myArray[2, 3];

            for (int i = 0; i < myArray.GetLength(0); i++)  //goes through each row
            {
                for (int j = 0; j < myArray.GetLength(1); j++)  //goes through each column
                {
                    Console.Write(myArray[i, j] + "\t");
                }
                Console.WriteLine();
            }

//TASK(7) Creating a List of String values, prompting student names and printing them out
//========================================================================================
            List<String> myStudentList = new List<String>();
            Random randomValue = new Random();          //using Random .NET class
            int randomNumber = randomValue.Next(1, 12); //generating a random number between 1 and 12

            Console.WriteLine("You now need to add " + randomNumber + " students to your class list");
            for (int i = 0; i < randomNumber; i++)
            {
                Console.Write("Please enter the name of Student " + (i + 1) + ": ");
                myStudentList.Add(Console.ReadLine());
                Console.WriteLine();
            }

            Console.WriteLine("List of students in class list: ");
            for (int j = 0; j < myStudentList.Count; j++)
            {
                Console.WriteLine((j + 1) + ": " + myStudentList[j]);
            }

//TASK(8) Creating a static method that returns true if an inputted array is a palindrome
//========================================================================================
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array: ");
            int arraySize = Convert.ToInt32(Console.ReadLine());
            int[] myArray = new int[arraySize];
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine("Enter a number ({0}): ", i+1);
                myArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            if (Palindrome(myArray) == true)
            {
                Console.WriteLine("The array is a palindrome");
            }
            else if (Palindrome(myArray) == false)
            {
                Console.WriteLine("The array is not a palindrome");
            }
        }

        static bool Palindrome(int[] array)
        {
            for (int i = 0; i < array.Length/2; i++)
            {
                if (array[i] == array[(array.Length - i - 1)])
                {
                    return true;
                }
            }
            if (array.Length < 1)
            {
                return false;
            }
            return false;
        }

//TASK (10) Take the odd values from a two-dimensional array and put them into a one-dimensional array
//========================================================================================================

int[,] myArray = new int[4, 6] { { 0, 2, 4, 0, 9, 5 }, { 7, 1, 3, 3, 2, 1 }, { 1, 3, 9, 8, 5, 6 }, { 4, 6, 7, 9, 1, 0 } };
int[] oddArray = ArrayConversion(myArray);
Console.WriteLine("Odd numbers in the array: ");
for (int i = 0; i < oddArray.Length; i++)
{
    Console.Write(oddArray[i] + " ");
}
        }

        static bool isOdd(int value)    //Checks if value is odd
{
    if (value % 2 == 0)
    {
        return false;
    }
    return true;
}

static int[] ArrayConversion(int[,] array)
{
    List<int> oddList = new List<int>();
    for (int i = 0; i < array.GetLength(1); i++)        //Goes through each column
    {
        for (int j = 0; j < array.GetLength(0); j++)    //Goes through each row
        {
            if (isOdd(array[j, i]) == true)
            {
                oddList.Add(array[j, i]);
            }
        }
    }
    int[] oddArray = new int[oddList.Count];
    for (int k = 0; k < oddList.Count; k++)
    {
        oddArray[k] = oddList[k];
    }
    return oddArray;