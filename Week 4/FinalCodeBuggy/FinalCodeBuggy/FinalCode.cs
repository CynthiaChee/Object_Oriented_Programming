//Program.cs
//===========

using System;
using System.Collections.Generic;

namespace BuggySoft
{
    class Program
    {
        enum MenuOption
        {
            ADDTASK,
            REMOVETASK,
            ADDCAT,
            REMOVECAT,
            SWAP,
            HIGHLIGHT,
            MOVE,
            PRINT,
            QUIT
        }

        static MenuOption ReadUserOption()
        {
            int option;
            do
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Remove task");
                Console.WriteLine("3. Add category");
                Console.WriteLine("4. Remove category");
                Console.WriteLine("5. Swap tasks");
                Console.WriteLine("6. Highlight task");
                Console.WriteLine("7. Move task to different category");
                Console.WriteLine("8. Print");
                Console.WriteLine("9. Quit");
                option = Convert.ToInt32(Console.ReadLine());

            } while (option < 1 || option > 9);

            MenuOption optionCast = (MenuOption)(option - 1);
            return optionCast;
        }

        static void ChooseOption(Folder table)
        {
            MenuOption option;
            do
            {
                option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.ADDTASK:
                        AddTask(table); break;
                    case MenuOption.REMOVETASK:
                        RemoveTask(table); break;
                    case MenuOption.ADDCAT:
                        AddCat(table); break;
                    case MenuOption.REMOVECAT:
                        RemoveCat(table); break;
                    case MenuOption.SWAP:
                        Swap(table); break;
                    case MenuOption.HIGHLIGHT:
                        Highlight(table); break;
                    case MenuOption.MOVE:
                        Move(table); break;
                    case MenuOption.PRINT:
                        table.Print(); break;
                    case MenuOption.QUIT:
                        Console.WriteLine("See you soon!"); break;
                }
            } while (option != MenuOption.QUIT);
        }

        static void AddTask(Folder folder)
        {
            int idx = ChooseCategory(folder);
            Console.Write("Enter new task, max 30 characters\n>> ");
            string taskName = Truncate(Console.ReadLine(), 30);
            bool date;
            do
            {
                Console.WriteLine("Enter due date (yyyy/mm/dd)");
                date = DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);
                if (!date)
                {
                    Console.WriteLine("Please enter a due date");
                }
                else
                {
                    folder.GetCategories()[idx].AddItem(taskName, dueDate);
                }
            } while (!date);
        }

        static void RemoveTask(Folder folder)
        {
            int idx = ChooseCategory(folder);
            int task = ChooseTask(folder, idx);
            folder.GetCategories()[idx].RemoveItem(task);
        }

        static void AddCat(Folder folder)
        {
            Console.Write("Enter name for new category, under 20 characters\n>> ");
            folder.AddCategory(Truncate(Console.ReadLine(), 20));
        }

        static void RemoveCat(Folder folder)
        {
            folder.RemoveCategory(ChooseCategory(folder));
        }

        static void Swap(Folder folder)
        {
            int cat = ChooseCategory(folder);
            Console.WriteLine("Choose tasks to swap");
            Console.WriteLine("Task 1");
            int from = ChooseTask(folder, cat);
            Console.WriteLine("Task 2");
            int to = ChooseTask(folder, cat);
            folder.GetCategories()[cat].SwapItems(from, to);
        }

        static void Highlight(Folder folder)
        {
            int cat = ChooseCategory(folder);
            int task = ChooseTask(folder, cat);
            folder.GetCategories()[cat].GetList()[task].ChangePriority();
        }

        static void Move(Folder folder)
        {
            Console.WriteLine("Choose task to move");
            int fromCat = ChooseCategory(folder);
            int idx = ChooseTask(folder, fromCat);
            Console.WriteLine("Choose destination category");
            int toCat = ChooseCategory(folder);
            folder.Move(fromCat, toCat, idx);
        }

        static int CheckIntInput(string input)
        {
            int converted;
            while (!int.TryParse(input, out converted))
            {
                Console.WriteLine("Please enter an integer");
                input = Console.ReadLine();
            }
            return converted;
        }

        static string Truncate(string input, int limit)
        {
            return input.Length <= limit ? input : input.Substring(0, limit);
        }

        static int ChooseTask(Folder folder, int category)
        {
            Console.Write("Choose task: ");
            int taskIdx;
            do
            {
                taskIdx = CheckIntInput(Console.ReadLine());
                if (taskIdx < 1 || taskIdx > folder.GetCategories()[category].GetList().Count + 1)
                {
                    Console.WriteLine("Task not found. Try again");
                }
            } while (taskIdx < 1 || taskIdx >= folder.GetCategories()[category].GetList().Count + 1);
            return taskIdx - 1;
        }

        static int ChooseCategory(Folder folder)
        {
            Console.Write("Choose category: ");
            Console.WriteLine();
            for (int i = 0; i < folder.GetCategories().Count; i++)
            {
                Console.Write($"| {i + 1}. {folder.GetCategories()[i].GetName()} |");
            }
            Console.Write("\n>> ");
            int catIdx;
            do
            {
                catIdx = CheckIntInput(Console.ReadLine());
                if (catIdx < 1 || catIdx > folder.GetCategories().Count + 1)
                {
                    Console.WriteLine("Category not found. Try again");
                }
            } while (catIdx < 1 || catIdx > folder.GetCategories().Count + 1);
            return catIdx - 1;
        }

        static void Main(string[] args)
        {
            Folder folder = new Folder("My Folder");
            folder.AddCategory("Personal");
            folder.AddCategory("Work");
            folder.AddCategory("Family");
            folder.GetCategories()[0].AddItem("Clean room", new DateTime(2021, 02, 20));
            folder.GetCategories()[0].AddItem("Go jogging", new DateTime(2021, 05, 15));
            folder.GetCategories()[0].AddItem("Grocery shopping", new DateTime(2021, 04, 07));
            folder.GetCategories()[1].AddItem("Print documents", new DateTime(2021, 03, 28));
            folder.GetCategories()[1].AddItem("Send email to supervisor", new DateTime(2021, 06, 30));
            folder.GetCategories()[2].AddItem("Repair parents' car", new DateTime(2021, 07, 11));
            Console.Clear();
            folder.Print();
            Console.ResetColor();
            ChooseOption(folder);
        }
    }
}

//(class) Task.cs
//=================

using System;
using System.Collections.Generic;

namespace BuggySoft
{
    class Task
    {
        private string _name;
        private DateTime _duedate;
        private bool _priority;

        public Task(string name, DateTime duedate)
        {
            _name = name;
            _duedate = duedate;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetPriority()
        {
            return _priority;
        }

        public string GetDate()
        {
            return _duedate.ToString("dd/MM/yyyy");
        }

        public void ChangePriority()
        {
            _priority = _priority == false ? _priority = true : _priority = false;
        }
    }
}

//(class) Category.cs
//====================

using System;
using System.Collections.Generic;
namespace BuggySoft
{
    class Category
    {
        private string _name;
        private List<Task> _taskList;

        public Category(string name)
        {
            _name = name;
            _taskList = new List<Task>();
        }

        public string GetName()
        {
            return _name;
        }

        public List<Task> GetList()
        {
            return _taskList;
        }

        public void AddItem(string item, DateTime dueDate)
        {
            _taskList.Add(new Task(item, dueDate));
        }

        public void AddItem(Task task)
        {
            _taskList.Add(task);
        }

        public void RemoveItem(int order)
        {
            _taskList.RemoveAt(order);
        }

        public void SwapItems(int from, int to)
        {
            Task temp = _taskList[from];
            _taskList[from] = _taskList[to];
            _taskList[to] = temp;
        }
    }
}

//(class) Folder.cs
//===================

using System;
using System.Collections.Generic;
namespace BuggySoft
{
    class Folder
    {
        private string _name;
        private List<Category> _categories;

        public Folder(string name)
        {
            _name = name;
            _categories = new List<Category>();
        }

        public string GetName()
        {
            return _name;
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }

        public void AddCategory(string catName)
        {
            _categories.Add(new Category(catName));
        }

        public void RemoveCategory(int catIdx)
        {
            _categories.RemoveAt(catIdx);
        }

        public void Move(int from, int to, int idx)
        {
            Task toMove = _categories[from].GetList()[idx];
            _categories[to].AddItem(toMove);
            _categories[from].RemoveItem(idx);
        }

        public void Print()
        {
            int max = _categories[0].GetList().Count;
            foreach (Category category in _categories)
            {
                max = max > category.GetList().Count ? max : category.GetList().Count;
            }

            ConsoleColor defaultColor = ConsoleColor.Blue;
            Console.ForegroundColor = defaultColor;

            //Print table
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', (_categories.Count * 48)));
            Console.Write("{0,10}|", "Item #");

            //Print categories
            for (int i = 0; i < _categories.Count; i++)
            {
                Console.Write("{0,45}|", $"[{i + 1}] " + _categories[i].GetName());
            }

            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + new string('-', (_categories.Count * 48)));

            //Print tasks
            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", $"[{i + 1}]");
                foreach (Category category in _categories)
                {
                    if (category.GetList().Count > i)
                    {
                        //Highlight if priority
                        if (category.GetList()[i].GetPriority())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,45}", category.GetList()[i].GetName() + new string($" ({category.GetList()[i].GetDate()})"));
                            Console.ForegroundColor = defaultColor;
                            Console.Write("|");
                        }
                        else Console.Write("{0,45}|", category.GetList()[i].GetName() + new string($" ({category.GetList()[i].GetDate()})"));
                    }
                    else
                    {
                        Console.Write("{0,45}|", "N/A");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string(' ', 10) + new string('-', (_categories.Count * 48)));
        }
    }
}
