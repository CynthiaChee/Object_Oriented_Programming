using System;
using System.Collections.Generic;

namespace TestBuggy
{
    class Task
    {
        private string _name;
        private DateTime _deadline;
        private bool _priority;

        public Task(string name)
        {
            this._name = name;
        }

        public Task(string name, DateTime deadline)
        {
            this._name = name;
            this._deadline = deadline;
        }

        public string GetName
        {
            get => _name;
        }

        public bool GetPriority
        {
            get => _priority;
        }

        public string GetDeadline
        {
            get
            {
                if (_deadline == DateTime.MinValue)
                    return "Undated";
                return this._deadline.ToString("dd/MM/yy");
            }
        }

        public void Priority()
        {
            this._priority = true;
        }

        public void NotPriority()
        {
            this._priority = false;
        }
    }
}
