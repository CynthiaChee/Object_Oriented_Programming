using System;
using System.Collections.Generic;

namespace FinalCode
{
    class FinalCode
    {
        //static Task ChooseTask(Folder folder)
        //{
        //    Category cat = ChooseCat(folder);
        //    Console.WriteLine("Choose task: ");
        //    string task = Console.ReadLine();
        //    Task found =  folder.GetTask(task);
        //    if (found == null)
        //    {
        //        Console.WriteLine("Task not found");
        //    }
        //    return found;
        //}

        //static Task ChooseTask(Folder folder)
        //{
        //    Console.WriteLine("Choose task: ");
        //    string task = Console.ReadLine();
        //    Task found = folder.DoFindTask(task);
        //    if (found == null)
        //    {
        //        Console.WriteLine("Task not found");
        //    }
        //    return found;
        //}

        static int ChooseTask(Folder folder)
        {
            Console.WriteLine("Choose task: ");
            string task = Console.ReadLine();
            int found = folder.DoTaskIdx(task);
            if (found == -1)
            {
                Console.WriteLine("Task not found");
            }
            return found;
        }

        static int ChooseCat(Folder folder)
        {
            Console.WriteLine("Choose category: ");
            string cat = Console.ReadLine();
            int found = folder.CatIdx(cat);
            if (found == -1)
            {
                Console.WriteLine("Category not found");
            }
            return found;
        }

        //static Category ChooseCat(Folder folder)
        //{
        //    Console.WriteLine("Choose category: ");
        //    string cat = Console.ReadLine();
        //    Category found = folder.FindCat(cat);
        //    if (found == null)
        //    {
        //        Console.WriteLine("Category not found");
        //    }
        //    return found;
        //}

        //static void AddTask(Folder folder)
        //{
        //    Category cat = ChooseCat(folder);
        //    Console.WriteLine("Enter new task, max 30 symbols: ");
        //    string newTask = Console.ReadLine();
        //    Console.WriteLine("Enter due date (dd-MM-yy): ");
        //    DateTime newDate = Convert.ToDateTime(Console.ReadLine());
        //    Task addTask = new Task(newTask, newDate);
        //    cat.AddTask(addTask);
        //}

        //static void RemoveTask(Folder folder)
        //{
        //    Category cat = ChooseCat(folder);
        //    Task task = ChooseTask(folder);
        //    cat.RemoveTask(cat.TaskIdx(task));
        //}

        //static void MoveTask(Folder folder)
        //{
        //    Category fromCat = ChooseCat(folder);
        //    Task toMove = ChooseTask(folder);
        //    Category toCat = ChooseCat(folder);
        //    toCat.AddTask(toMove);
        //    fromCat.RemoveTask(fromCat.TaskIdx(toMove));
        //}

        static void AddTask(Folder folder)
        {
            Console.WriteLine("Enter new task, max 30 symbols: ");
            string newTask = Console.ReadLine();
            Console.WriteLine("Enter due date (dd-MM-yy): ");
            DateTime newDate = Convert.ToDateTime(Console.ReadLine());
            Task addTask = new Task(newTask, newDate);
            folder.DoAddTask(addTask);
        }

        static void RemoveTask(Folder folder)
        {
            int task = ChooseTask(folder);
            folder.DoRemoveTask(task);
        }

        static void MoveTask(Folder folder)
        {
            int fromCat = ChooseCat(folder);
            int taskMove = ChooseTask(folder);
            int toCat = ChooseCat(folder);
            //folder.MoveTask(fromCat, toCat, toMove);
        }

        //static void PriorityTask(Folder folder)
        //{
        //    Category cat = ChooseCat(folder);
        //    Task task = ChooseTask(folder);
        //    task.Priority = !task.Priority ? task.Priority == true : !task.Priority;
        //}

        static void AddCategory(Folder folder)
        {
            Console.WriteLine("Enter new category: ");
            string catName = Console.ReadLine();
            Category newCat = new Category(catName);
            folder.AddCat(newCat);
        }

        static void RemoveCategory(Folder folder)
        {
            int idx = ChooseCat(folder);
            folder.RemoveCat(idx);
        }

        static void Print(Folder folder)
        {
            folder.PrintFolder();
        }

        enum MenuOption
        {
            ADDCAT,
            REMOVECAT,
            EDITCAT,
            PRINT,
            QUIT
        }

        enum CatOption
        {
            ADDTASK,
            REMOVETASK,
            MOVETASK,
            PRIORITYTASK,
            BACK
        }

        static MenuOption ReadUserOption()
        {
            int option;
            do
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add category");
                Console.WriteLine("2. Remove category");
                Console.WriteLine("3. Edit category");
                Console.WriteLine("4. Print");
                Console.WriteLine("5. Quit");
                option = Convert.ToInt32(Console.ReadLine());

            } while (option < 1 || option > 5);

            MenuOption optionCast = (MenuOption)(option - 1);
            return optionCast;
        }

        static CatOption ReadCatOption()
        {
            int option;
            do
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Remove task");
                Console.WriteLine("3. Move task");
                Console.WriteLine("4. Change task priority");
                Console.WriteLine("5. Back to main menu");
                option = Convert.ToInt32(Console.ReadLine());
            } while (option < 1 || option > 5);

            CatOption optionCast = (CatOption)(option - 1);
            return optionCast;
        }

        static void UpdateCat(Folder folder)
        {
            CatOption option;
            int catIdx = ChooseCat(folder);

            do
            {
                Console.WriteLine("Choose an option: ");
                option = ReadCatOption();

                switch (option)
                {
                    case CatOption.ADDTASK:
                        AddTask(folder); break;
                    case CatOption.REMOVETASK:
                        RemoveTask(folder); break;
                    case CatOption.MOVETASK:
                        MoveTask(folder); break;
                    case CatOption.PRIORITYTASK:
                        break;
                    case CatOption.BACK:
                        break;
                }
            } while (option != CatOption.BACK);
        }

        static void Main(string[] args)
        {
            //Task one = new Task("Read chapter 6", new DateTime(2021, 8, 21));
            //Task two = new Task("Water plants", new DateTime(2021, 9, 26));
            //Task three = new Task("Feed the fishes", new DateTime(2021, 8, 15));
            //Task four = new Task("Print the documents", new DateTime(2021, 10, 5));
            //Task five = new Task("Pay rent", new DateTime(2021, 11, 8));
            //Category work = new Category("Work");
            //Category family = new Category("Family");
            //Category study = new Category("Study");

            Folder folder = new Folder();
            //folder.AddCat(work);
            //folder.AddCat(study);
            //folder.AddCat(family);
            //work.AddTask(one);
            //study.AddTask(two);
            //family.AddTask(three);
            //work.AddTask(four);
            //study.AddTask(five);
            //work.SetPriority(four);

            //work.PrintTasks();
            //folder.PrintCats();

            //folder.PrintFolder();
            //folder.PrintCats();

            MenuOption option;

            do
            {
                option = ReadUserOption();

                switch (option)
                {
                    //case MenuOption.ADDTASK:
                    //    AddTask(folder);
                    //    break;
                    //case MenuOption.REMOVETASK:
                    //    RemoveTask(folder);
                    //    break;
                    //case MenuOption.MOVETASK:
                    //    MoveTask(folder);
                    //    break;
                    //case MenuOption.PRIORITYTASK:
                    //    PriorityTask(folder);
                    //    break;
                    case MenuOption.ADDCAT:
                        AddCategory(folder);
                        break;
                    case MenuOption.REMOVECAT:
                        RemoveCategory(folder);
                        break;
                    case MenuOption.EDITCAT:
                        UpdateCat(folder);
                        break;
                    case MenuOption.PRINT:
                        Print(folder);
                        break;
                    case MenuOption.QUIT:
                        break;
                }
            } while (option != MenuOption.QUIT);

        }

    }
}
