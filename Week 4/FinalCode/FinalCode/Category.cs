using System;
using System.Collections.Generic;
namespace FinalCode
{
    class Category
    {
        private string _name;
        private List<Task> _tasks;

        public Category(string name)
        {
            _name = name;
            _tasks = new List<Task>();
        }

        public string getName() { return _name; }
        public List<Task> getTasks() { return _tasks; }

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(int idx)
        {
            _tasks.RemoveAt(idx);
        }

        public int TaskIndex(string search)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                if (_tasks[i].getName().ToLower() == search.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        public Task FindTask(string search)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                if (search.ToLower() == _tasks[i].getName().ToLower())
                {
                    return _tasks[i];
                }
            }
            return null;
        }

        //public void SwapTasks(int source, int dest)
        //{
        //    Task temp = _tasks[source];
        //    _tasks[source] = _tasks[dest];
        //    _tasks[dest] = temp;
        //}

        public bool SetPriority(Task task)
        {
            return !task.Priority ? task.Priority == true : !task.Priority;
        }

        public List<Task> Rearrange()
        {
            List<Task> arranged = new List<Task>();
            foreach(Task item in _tasks)
            {
                if (item.Priority) { arranged.Add(item); }
            }
            foreach(Task item in _tasks)
            {
                if (!item.Priority) { arranged.Add(item); }
            }
            return arranged;
        }

        public void PrintTasks()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("{0,30}", _name.ToUpper(), Console.ForegroundColor);
            List<Task> latestTasks = Rearrange();
            for (int i = 0; i < latestTasks.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0}", i+1, Console.ForegroundColor);
                if (latestTasks[i].Priority)
                {
                    latestTasks[i].PriorityPrint();
                }
                else
                {
                    latestTasks[i].NormalPrint();
                }
            }
            Console.WriteLine("=============================================================");
        }

        public int Max()
        {
            return _tasks.Count;  
        }



    }
}
