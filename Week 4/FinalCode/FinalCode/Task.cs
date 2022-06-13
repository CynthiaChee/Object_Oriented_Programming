using System;
using System.Collections.Generic;
namespace FinalCode
{
    class Task
    {
        private string _name;
        private DateTime _date;
        private bool _priority;

        public Task(string name, DateTime date)
        {
            _name = name;
            _date = date;
        }

        //public string Name { get; set; }
        //public DateTime Date { get; set; }
        public bool Priority { get; set; }

        public string getName() { return _name; }
        public DateTime getDate() { return _date; }
        //public bool getPriority() { return _priority; }
        //public void setPriority(bool priority) { _priority = priority; }
        public void PriorityPrint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0,30}, Due {1,-30:dd-MM-yy}", _name, _date, Console.ForegroundColor);
        }

        public void NormalPrint()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0,30}, Due {1,-30:dd-MM-yy}", _name, _date, Console.ForegroundColor);
        }
    }
}