using System;
using System.Collections.Generic;
namespace FinalCode
{
    class Folder
    {
        //private string _name;
        private List<Category> _categories = new List<Category>();
        private Category _cat;
        private Task _task;

        public Folder()
        {
        }

        //public string name { get; set; }
        public List<Category> Categories { get; set; }
        public Category Cat { get; }

        public void AddCat(Category cat)
        {
            _categories.Add(cat);
        }

        //working
        public void RemoveCat(int idx)
        {
            _categories.RemoveAt(idx);
        }

        public int CatIndex(Category cat)
        {
            for (int i = 0; i < _categories.Count; i++)
            {
                if (cat.getName().ToLower() == _categories[i].getName().ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        public int CatIdx(string search)
        {
            for (int i = 0; i < _categories.Count; i++)
            {
                if (search.ToLower() == _categories[i].getName().ToLower())
                {
                    return i;
                }
            }
            return -1;
        }


        //working
        public Category FindCat(string search)
        {
            for (int i = 0; i < _categories.Count; i++)
            {
                if (search.ToLower() == _categories[i].getName().ToLower())
                {
                    return _categories[i];
                }
            }
            return null;
        }

        public void DoAddTask(Task task)
        {
            _cat.AddTask(task);
        }

        public void DoRemoveTask(int idx)
        {
            _cat.RemoveTask(idx);
        }

        //public void MoveTask(int from, int to, int taskIdx)
        //{
        //    int moveIdx = _categories[from].TaskIndex(search);
        //    Task toMove = _categories[from].getTasks()[moveIdx];
        //    _categories[to].AddTask(toMove);
        //    _categories[from].RemoveTask(moveIdx);
        //}

        public Task DoFindTask(string search)
        {
            return _cat.FindTask(search);
        }

        public int DoTaskIdx(string search)
        {
            return _cat.TaskIndex(search);
        }


        public void PrintFolder()
        {
            int max = _categories[0].Max();
            foreach (Category cat in _categories)
            {
                max = max > cat.Max() ? max : cat.Max();
            }
            Console.WriteLine("{0,35}","CATEGORIES");
            Console.WriteLine("=============================================================");
            foreach (Category cat in _categories)
            {
                cat.PrintTasks();
            }
            Console.WriteLine();

        }

    }
}
