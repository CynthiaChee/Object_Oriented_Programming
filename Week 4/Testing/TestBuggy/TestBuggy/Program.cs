using System;
using System.Collections.Generic;

namespace TestBuggy
{
    class Program
    {
        public enum MenuOptions
        {
            AddTask = 1,
            RemoveTask = 2,
            AddCategory = 3,
            DeleteCategory = 4,
            SwapPriority = 5,
            Transfer = 6,
            Highligh = 7,
        }

        private static void UI(Table table)
        {
            switch (ReadUserInput())
            {
                case MenuOptions.AddTask:
                    {
                        AddTask(table);
                        break;
                    }
                case MenuOptions.RemoveTask:
                    {
                        RemoveTask(table);
                        break;
                    }
                case MenuOptions.AddCategory:
                    {
                        AddCat(table);
                        break;
                    }
                case MenuOptions.DeleteCategory:
                    {
                        DelCat(table);
                        break;
                    }
                case MenuOptions.SwapPriority:
                    {
                        Swap(table);
                        break;
                    }
                case MenuOptions.Transfer:
                    {
                        Move(table);
                        break;
                    }
                case MenuOptions.Highligh:
                    {
                        Highlight(table);
                        break;
                    }
            }
        }

        //Table Functions
        private static void AddTask(Table table)
        {
            int index = ChooseCategory(table);

            Console.Write("Enter your task, max 30 symbols\n>> ");
            string taskName = CheckString(Console.ReadLine(), 30);

            Console.WriteLine("Enter the deadline (dd/mm/yy), enter anything else if you don't have deadline");

            //User can ignore deadline
            if (DateTime.TryParse(Console.ReadLine(), out DateTime deadlineDate))
            {
                table.GetCategories[index].AddItem(taskName, deadlineDate);
            }
            else
            {
                table.GetCategories[index].AddItem(taskName);
            }
        }

        private static void RemoveTask(Table table)
        {
            int index = ChooseCategory(table);
            int taskOrder = ChooseTask(table, index);
            table.GetCategories[index].RemoveItem(taskOrder);
        }

        private static void AddCat(Table table)
        {
            Console.Write("Enter name for new category, under 20 characters\n>> ");
            //Limit category to 20 characters
            table.AddCategory(CheckString(Console.ReadLine(), 20));
        }

        private static void DelCat(Table table)
        {
            table.RemoveCategory(ChooseCategory(table));
        }

        private static void Swap(Table table)
        {
            int category = ChooseCategory(table);
            Console.Write("From ");
            int from = ChooseTask(table, category);
            Console.Write("To ");
            int to = ChooseTask(table, category);

            table.GetCategories[category].SwapOrder(from, to);
        }

        private static void Move(Table table)
        {
            Console.WriteLine("From ");
            int fromCat = ChooseCategory(table);
            int index = ChooseTask(table, fromCat);
            Console.WriteLine("To ");
            int toCat = ChooseCategory(table);

            table.Transfer(fromCat, toCat, index);
        }

        private static void Highlight(Table table)
        {
            int cat = ChooseCategory(table);
            int task = ChooseTask(table, cat);
            //Mark as priority, unmark if the task is already marked
            if (table.GetCategories[cat].GetList[task].GetPriority)
            {
                table.GetCategories[cat].GetList[task].NotPriority();
            }
            else table.GetCategories[cat].GetList[task].Priority();
        }

        //Methods
        //Return MenuOption datatype based on user input
        private static MenuOptions ReadUserInput()
        {
            int userInput;

            //Print out the menu options
            Console.WriteLine("Which action?");
            foreach (MenuOptions choices in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.Write($"| {(int)choices}. {choices.ToString()} |");
            }
            Console.WriteLine();
            //limit user input
            do
            {
                Console.Write(">> ");
                userInput = InputToInt(Console.ReadLine());
                if (userInput <= 0 || userInput > Enum.GetValues(typeof(MenuOptions)).Length)
                {
                    Console.WriteLine("Unknown option, try again!");
                }
            } while (userInput <= 0 || userInput > Enum.GetValues(typeof(MenuOptions)).Length);

            return (MenuOptions)userInput;
        }

        //Check user input, and set a limit
        private static string CheckString(string input, int limit)
        {
            int count = 0;
            do
            {
                //Count the length of input
                count = 0;
                foreach (char character in input)
                    if (character == '/')
                        count++;
                if (count > limit)
                {
                    Console.WriteLine("Input should not over 30, try again");
                    input = Console.ReadLine();
                }
            } while (count > limit);
            return input;
        }

        //convert input to string
        private static int InputToInt(string inputNumberAsString)
        {
            int inputNumber;
            while (!int.TryParse(inputNumberAsString, out inputNumber))
            {
                Console.WriteLine("This is not quite an integer");
                inputNumberAsString = Console.ReadLine();
            }
            return inputNumber;
        }

        private static DateTime InputToDatetime(string input)
        {
            DateTime time;
            while (!DateTime.TryParse(input, out time))
            {
                Console.WriteLine("Invalid date, try again");
                input = Console.ReadLine();
            }
            return time;
        }

        private static int ChooseCategory(Table table)
        {
            //Print Category and index
            Console.Write("Which category?");
            Console.WriteLine();
            for (int i = 0; i < table.GetCategories.Count; i++)
            {
                Console.Write($"| {i}. {table.GetCategories[i].GetName} |");
            }
            Console.Write("\n>> ");

            int index = 0;
            do
            {
                index = InputToInt(Console.ReadLine());
                if (index < 0 || index >= table.GetCategories.Count)
                {
                    Console.WriteLine("Unknown Category! Please ty again");
                }
            } while (index < 0 || index > table.GetCategories.Count);
            //Return the index of chosen category in the table
            return index;
        }

        private static int ChooseTask(Table table, int category)
        {
            Console.Write("Which task?\n>> ");
            int taskOrder = 0;
            do
            {
                taskOrder = InputToInt(Console.ReadLine());
                if (taskOrder < 0 || taskOrder >= table.GetCategories[category].GetList.Count)
                {
                    Console.WriteLine("Unknown task! Please try again");
                }
            } while (taskOrder < 0 || taskOrder >= table.GetCategories[category].GetList.Count);
            return taskOrder;
        }

        static void Main(string[] args)
        {
            Table testTable = new Table("testTable");
            testTable.TestSample();
            while (true)
            {
                Console.Clear();
                testTable.Print();
                Console.ResetColor();
                UI(testTable);
            }
        }
    }
}
