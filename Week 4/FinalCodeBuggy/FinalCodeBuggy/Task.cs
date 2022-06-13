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
