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
        public void SetYear(int year)
        {
            int oldYear = _year;
            try
            {
                if (year >= 1 && year <= 9999)
                {
                    _year = year;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid year!");
                _year = oldYear;
            }
        }

        public void SetMonth(int month)
        {
            int oldMonth = _month;
            try
            {
                if (month >= 1 && month <= 12)
                {
                    _month = month;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid month!");
                _month = oldMonth;
            }
        }

        public void SetDay(int day)
        {
            int oldDay = _day;
            try
            {
                int dayMax = DAYS_IN_MONTHS[_month - 1];
                if (day >= 1 && day <= dayMax)
                {
                    _day = day;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid day!");
                _day = oldDay;
            }
        }

        public void SetDate(int day, int month, int year)
        {
            int oldDay = _day, oldMonth = _month, oldYear = _year;
            try
            {
                _day = day;
                _month = month;
                _year = year;

                if (isValidDate(day, month, year) == false)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid year, month, or day!");
                _day = oldDay;
                _month = oldMonth;
                _year = oldYear;
            }
        }

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
            //If not last day of the month and month != Feb
            if (_day != DAYS_IN_MONTHS[_month - 1] && _month != 2) 
            {
                _day++;
            }
            //If last day of the month
            else if (_day == DAYS_IN_MONTHS[_month - 1])      
            {
                //If month other than Dec or Feb
                if (_month != 12 && _month != 2)                
                {
                    _day = 1;
                    _month++;
                }

                //If month = Dec
                if (_month == 12)                               
                {
                    _day = 1;
                    _month = 1;
                    try
                    {
                        _year++;
                        if (_year > 9999)
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Invalid year!");
                        _year = 9999;
                        _month = 12;
                        _day = 31;
                    }
                }
            }
            //If month = Feb
            if (_month == 2)                                    
            {
                //Feb 29 on a leap year
                if (IsLeapYear(_year) && _day == 29)           
                {
                    _month++;
                    _day = 1;
                }
                //Feb 28 on a leap year
                else if (IsLeapYear(_year) && _day == 28)      
                {
                    _day = 29;
                }
                //Feb 28 on a non-leap year
                else if (!IsLeapYear(_year) && _day == 28)     
                {
                    _month++;
                    _day = 1;
                }
                //Any other day in Feb
                else if (_day != 28 && _day != 29)             
                {
                    _day++;
                }
            }
            return this;
        }

        public MyDate NextMonth()
        {
            //If month = Dec
            if (_month == 12)
            {
                if (_day == 31)
                {
                    _day = DAYS_IN_MONTHS[0];
                }
                try
                {
                    _month = 1;
                    _year++;
                    if (_year > 9999)
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid year!");
                    _year = 9999;
                    _month = 12;
                }
            }

            else if (_month != 12)
            {
                //If last day of any month other than Dec or on Feb 29 on a leap year
                if (_day == DAYS_IN_MONTHS[_month - 1] && _month != 2 || (!IsLeapYear(_year) && _month == 2 && _day == 28) || (IsLeapYear(_year) && _month == 2 && _day == 29))
                {
                    _month++;
                    _day = DAYS_IN_MONTHS[_month - 1];

                    //If next month is Feb in a leap year
                    if (IsLeapYear(_year) && _month == 2 && _day == 28)
                    {
                        _day = 29;
                    }
                }
                //If not last day of the month
                else if (_day != DAYS_IN_MONTHS[_month - 1])
                {
                    _month++;
                }
            }
            return this;
        }

        public MyDate NextYear()
        {
            //If last day of the month or Feb 29 on a leap year
            if (_day == DAYS_IN_MONTHS[_month - 1] || (_month == 2 && _day == 29))
            {
                //If next year is a leap year
                if (IsLeapYear(_year + 1) && _month == 2)
                {
                    _day = 29;
                }
                //If next year is not a leap year
                else if (!IsLeapYear(_year + 1) && _month == 2)
                {
                    _day = 28;
                }
            }
            try
            {
                _year++;
                if (_year > 9999)
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid year!");
                _year = 9999;
            }
            return this;
        }

        public MyDate PreviousDay()
        {
            //If beginning of the month
            if (_day == 1)                      
            {
                //If beginning of the year
                if (_month == 1)                  
                {
                    _month = 12;
                    _day = DAYS_IN_MONTHS[_month - 1];
                    try
                    {
                        _year--;
                        if (_year < 1)
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Invalid year!");
                        _year = 1;
                        _month = 1;
                        _day = 1;
                    }

                }
                //If month = Mar
                else if (_month == 3)
                {
                    //If leap year on 1st Mar
                    if (IsLeapYear(_year) && _month == 3 && _day == 1)
                    {
                        _month--;
                        _day = 29;
                    }
                    //If not leap year on 1st Mar
                    else if (!IsLeapYear(_year) && _month == 3 && _day == 1)
                    {
                        _month--;
                        _day = 28;
                    }
                    //If any other day in Mar
                    else if (_day != 1)
                    {
                        _day--;
                    }
                }
                //If beginning of any other month
                else if (_month != 1 && _month != 3)
                {
                    _month--;
                    _day = DAYS_IN_MONTHS[_month - 1];
                }
            }
            //If any other day
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
                try
                {
                    _month = 12;
                    _year--;
                    if (_year < 1)
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid year!");
                    _year = 1;
                    _month = 1;
                }
            }
            else if (_month != 1)
            {
                //If last day of any month other than Jan or on Feb 29 on a leap year
                if (_day == DAYS_IN_MONTHS[_month - 1] && _month != 2 || (!IsLeapYear(_year) && _month == 2 && _day == 28) || (IsLeapYear(_year) && _month == 2 && _day == 29))
                {
                    _month--;
                    _day = DAYS_IN_MONTHS[_month - 1];

                    //If previous month is Feb in a leap year
                    if (IsLeapYear(_year) && _month == 2 && _day == 28)
                    {
                        _day = 29;
                    }
                }
                //If not last day of the month
                else if (_day != DAYS_IN_MONTHS[_month - 1])
                {
                    _month--;
                }
            }
            return this;
        }

        public MyDate PreviousYear()
        {
            //If last day of the month of Feb 29 on a leap year
            if (_day == DAYS_IN_MONTHS[_month - 1] || (_month == 2 && _day == 29))
            {
                //If previous year is a leap year
                if (IsLeapYear(_year - 1) && _month == 2)
                {
                    _day = 29;
                }
                //If previous year is not a leap year
                else if (!IsLeapYear(_year - 1) && _month == 2)
                {
                    _day = 28;
                }
            }
            try
            {
                _year--;
                if (_year < 1)
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid year!");
                _year = 1;
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
            try
            {
                if ((year >= 1 && year <= 9999) && (month >= 1 && month <= 12) && (day >= 1 && day <= DAYS_IN_MONTHS[month - 1]))
                {
                    return true;
                }
                if (IsLeapYear(year) == true && month == 2 && day == 29)
                {
                    return true;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch
            {
                return false;
            }
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