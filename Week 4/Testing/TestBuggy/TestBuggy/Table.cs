using System;
using System.Collections.Generic;
namespace TestBuggy
{
    class Table
    {
        private string _name;
        private List<Category> _tableItems;

        public Table(string name)
        {
            this._name = name;
            this._tableItems = new List<Category>();
            this.BaseTable();
        }

        //Get name and categories
        public string GetName
        {
            get => this._name;
        }

        public List<Category> GetCategories
        {
            get => this._tableItems;
        }

        public void BaseTable()
        {
            this.AddCategory("Personal");
            this.AddCategory("Work");
            this.AddCategory("Family");
        }

        public void AddCategory(string categoryName)
        {
            this._tableItems.Add(new Category(categoryName));
        }

        public void RemoveCategory(int index)
        {
            this._tableItems.RemoveAt(index);
        }

        public void RemoveCategory(string categoryName)
        {
            this._tableItems.Remove(StringToCategory(categoryName));
        }

        public void Transfer(int from, int to, int order)
        {
            //Get the task from one category
            Task taskTransfer = _tableItems[from].GetList[order];

            //Then remove that task
            _tableItems[from].RemoveItem(order);

            //Transfer to another category
            _tableItems[to].AddItem(taskTransfer);
        }

        public void Print()
        {
            int max = this._tableItems[0].GetList.Count;
            foreach (var category in this._tableItems)
            {
                max = max > category.GetList.Count ? max : category.GetList.Count;
            }

            //Default console color
            var defaultConsoleColor = ConsoleColor.Blue;
            Console.ForegroundColor = defaultConsoleColor;

            //Print out the Table
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', (_tableItems.Count * 41 + 1)));
            Console.Write("{0,10}|", "Item #");
            //Print Category with index number
            for (int i = 0; i < this._tableItems.Count; i++)
            {
                Console.Write("{0,40}|", $"[{i}] " + this._tableItems[i].GetName);
            }

            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + new string('-', (_tableItems.Count * 41 + 1)));

            //Print tasks in each category
            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", $"[{i}]");
                foreach (var category in this._tableItems)
                {
                    if (category.GetList.Count > i)
                    {
                        //Highlight if the task is marked as priority
                        if (category.GetList[i].GetPriority)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,40}", category.GetList[i].GetName + new string($" ({category.GetList[i].GetDeadline})"));
                            Console.ForegroundColor = defaultConsoleColor;
                            Console.Write("|");
                        }
                        else Console.Write("{0,40}|", category.GetList[i].GetName + new string($" ({category.GetList[i].GetDeadline})"));
                    }
                    else
                    {
                        Console.Write("{0,40}|", "N/A");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string(' ', 10) + new string('-', (_tableItems.Count * 41 + 1)));
        }

        //Private methods, add more spices because I want to
        private Category StringToCategory(string input)
        {
            foreach (var category in this._tableItems)
                if (category.GetName.ToLower() == input.ToLower())
                    return category;

            return null;
        }

        //Sample table for testing 
        public void TestSample()
        {
            this._tableItems.Clear();
            this.BaseTable();
            this._tableItems[0].AddItem("Drink water");
            this._tableItems[0].AddItem("Birthday", new DateTime(2020, 04, 29));
            this._tableItems[0].AddItem("Onetrack task 3.2", new DateTime(2020, 04, 27));
            this._tableItems[1].AddItem("IT Interview", new DateTime(2020, 04, 30));
            this._tableItems[2].AddItem("Call Dad");

        }
    }
}
