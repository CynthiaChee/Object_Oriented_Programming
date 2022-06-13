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
                Console.Write("{0,45}|", $"[{i+1}] " + _categories[i].GetName());
            }

            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + new string('-', (_categories.Count * 48)));

            //Print tasks
            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", $"[{i+1}]");
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
