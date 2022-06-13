using System;
using System.Collections.Generic;

namespace RevisedCode
{
    class RevisedCode
    {
        public static void Print(List<List<string>> tasks)
        {
            int max = tasks[0].Count;
            foreach(var item in tasks)
            {
                max = max > item.Count ? max : item.Count;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));
            Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", "Personal", "Work", "Family");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));
            for(int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", i+1);
                foreach (List<string> list in tasks)
                {
                    if(list.Count > i)
                    {
                        Console.Write("{0,30}|", list[i]);
                    }
                    else { Console.Write("{0,30}|", "N/A"); }
                }
            }
        }

        static void Main(string[] args)
        {
            List<string> personal = new List<string>();
            List<string> work = new List<string>();
            List<string> family = new List<string>();
            List<List<string>> tasks = new List<List<string>> { personal, work, family };
            string category, newTask;

            while (true)
            {
                Console.Clear();
                Print(tasks);
                Console.ResetColor(); Console.WriteLine("\nWhich category do you want to place a new task? Type \'Personal\', \'Work\', or \'Family\' >> ");
                category = Console.ReadLine().ToLower();
                Console.WriteLine("Describe your task below (max. 30 symbols). >> ");
                newTask = Console.ReadLine();
                if(newTask.Length > 30)
                {
                    newTask.Substring(0, 30);
                }

                switch (category)
                {
                    case "personal":
                        tasks[0].Add(newTask); break;
                    case "work":
                        tasks[1].Add(newTask); break;
                    case "family":
                        tasks[2].Add(newTask); break;
                    default:
                        break;
                }
            }
        }
    }
}
