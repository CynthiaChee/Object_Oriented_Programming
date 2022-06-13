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
