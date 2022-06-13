using System;
using System.Collections.Generic;
namespace TestBuggy
{
    class Category
    {
        private string _name;
        private List<Task> _listItem;

        public Category(string name)
        {
            this._name = name;
            this._listItem = new List<Task>();
        }

        //Get the name and list of item
        public string GetName
        {
            get => this._name;
        }

        public List<Task> GetList
        {
            get => this._listItem;
        }

        //Mutator, add/remove item to the list
        public void AddItem(string item, DateTime deadLine)
        {
            this._listItem.Add(new Task(item, deadLine));
        }

        public void AddItem(string item)
        {
            this._listItem.Add(new Task(item));
        }

        public void AddItem(Task task)
        {
            this._listItem.Add(task);
        }

        public void RemoveItem(int order)
        {
            this._listItem.RemoveAt(order);
        }

        public void SwapOrder(int from, int to)
        {
            Task temp = this._listItem[from];

            this._listItem[from] = this._listItem[to];

            this._listItem[to] = temp;
        }

        public void PrintList()
        {
            foreach (var item in this._listItem)
            {
                Console.WriteLine(item);
            }
        }
    }
}
