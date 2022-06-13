using System;
namespace MyDateTask
{
    class MyDate
    {
        private int _year, _month, _day;

        private static String[] MONTHS = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };
        private static String[] DAYS = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private static int[] DAYS_IN_MONTHS = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        //Constructor
        public MyDate(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
        }

        //Mutator methods
        public void SetYear(int year) =>
            _ = isValidDate(_day, _month, year) ? _year = year : throw new ArgumentOutOfRangeException("Invalid year!");

        public void SetMonth(int month) =>
            _ = isValidDate(_day, month, _year) ? _month = month : throw new ArgumentOutOfRangeException("Invalid month!");

        public void SetDay(int day) =>
            _ = isValidDate(day, _month, _year) ? _day = day : throw new ArgumentOutOfRangeException("Invalid day!");

        public void SetDate(int day, int month, int year) =>
            _ = isValidDate(day, month, year) ? (_day, _month, _year) = (day, month, year) : throw new ArgumentOutOfRangeException("Invalid year, month, or day!");

        //Accessor methods
        public int GetYear()
        {
            return _year;
        }

        public int GetMonth()
        {
            return _month;
        }

        public int GetDay()
        {
            return _day;
        }

        //Methods
        public MyDate NextDay()
        {
            if (_month == 2)
            {
                if (IsLeapYear(_year) && _day == 29 || !IsLeapYear(_year) && _day == 28)
                {
                    NextMonth();
                    _day = 1;
                }
                else if (IsLeapYear(_year) && _day == 28)
                {
                    _day = 29;
                }
                else if (_day != 28 && _day != 29)
                {
                    _day++;
                }
            }
            else if (_day == DAYS_IN_MONTHS[_month - 1] && _month != 2)       //last day of the month
            {
                _day = 1;
                if (_month == 12)
                {
                    _month = 1;
                    NextYear();
                }
                else
                {
                    NextMonth();
                }
            }
            else if (_day != DAYS_IN_MONTHS[_month - 1] && _month != 2) //not last day of the month
            {
                _day++;
            }
            return this;
        }

        public MyDate NextMonth()
        {
            if (_month == 12)
            {
                if (_day == 31)
                {
                    _day = DAYS_IN_MONTHS[0];
                }
                _month = 1;
                NextYear();
            }
            else if (_month != 12)
            {
                _month++;
                if (_day == DAYS_IN_MONTHS[_month - 2] || (_month - 1 == 2 && _day == 29) || _day >= 30)
                {
                    if (_month == 2)
                    {
                        _ = IsLeapYear(_year) ? _day = 29 : _day = 28;
                    }
                    else
                    {
                        _day = DAYS_IN_MONTHS[_month - 1];
                    }
                }
            }
            return this;
        }

        public MyDate NextYear()
        {
            _year++;
            if (_year > 9999)
            {
                throw new InvalidOperationException("Year out of range!");
            }

            if (_day == DAYS_IN_MONTHS[_month - 1] || (_month == 2 && _day == 29))  //last day of a month
            {
                if (_month == 2)
                {
                    _ = IsLeapYear(_year) ? _day = 29 : _day = 28;
                }
                else
                {
                    _day = DAYS_IN_MONTHS[_month - 1];
                }
            }
            return this;
        }

        public MyDate PreviousDay()
        {
            if (_day == 1)                      //first day of the month
            {
                if (_month == 1)                  
                {
                    _month = 12;
                    _day = DAYS_IN_MONTHS[_month - 1];
                    PreviousYear();
                }
                else if (_month == 3)
                {
                    PreviousMonth();
                    _ = (IsLeapYear(_year) ? _day = 29 : _day = 28);
                }
                else if (_month != 1 && _month != 3)
                {
                    PreviousMonth();
                    _day = DAYS_IN_MONTHS[_month - 1];
                }
            }
            else if (_day != 1)
            {
                _day--;
            }
            return this;
        }

        public MyDate PreviousMonth()
        {
            if (_month == 1)
            {
                if (_day == 31)
                {
                    _day = DAYS_IN_MONTHS[11];
                }
                _month = 12;
                PreviousYear();
            }
            else if (_month != 1)
            {
                _month--;
                if(_day == DAYS_IN_MONTHS[_month] || _month + 1 == 2 && _day == 29 || _day >= 30)
                {
                    if(_month == 2)
                    {
                        _ = IsLeapYear(_year) ? _day = 29 : _day = 28;
                    }
                    else
                    {
                        _day = DAYS_IN_MONTHS[_month - 1];
                    }
                }
            }
            return this;
        }

        public MyDate PreviousYear()
        {
            _year--;
            if (_year < 1)
            {
                throw new InvalidOperationException("Year out of range!");
            }

            if (_day == DAYS_IN_MONTHS[_month - 1] || (_month == 2 && _day == 29))  //last day of a month
            {
                if (_month == 2)
                {
                    _ = IsLeapYear(_year) ? _day = 29 : _day = 28;
                }
                else
                {
                    _day = DAYS_IN_MONTHS[_month - 1];
                }
            }
            return this;
        }

        public override string ToString()
        {
            int whatDay = GetDayofWeek(_day, _month, _year);
            return string.Format("{0} {1} {2} {3}", DAYS[whatDay], _day, MONTHS[_month - 1], _year);
        }

        public static bool IsLeapYear(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            return false;
        }

        public static bool isValidDate(int day, int month, int year)
        {
            if ((year >= 1 && year <= 9999) && (month >= 1 && month <= 12) && (day >= 1 && day <= DAYS_IN_MONTHS[month - 1])
                || IsLeapYear(year) == true && month == 2 && day == 29)
            {
                return true;
            }
            return false;
        }

            public static int GetDayofWeek(int day, int month, int year)        //Using Tomohiko Sakamoto's algorithm
        {
            int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };

            if (month < 3)
            {
                year -= 1;
            }
            return (year + year / 4 - year / 100 + year / 400 + t[month - 1] + day) % 7;
        }
    }
}