namespace BICT.Payetakht.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class PersianDateTime
    {
        private readonly static PersianCalendar persianCalendar = new PersianCalendar();

        private readonly static string[] dayNames = new string[]
        {
            "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه"
        };

        private readonly static string[] monthNames = new string[]
        {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

        public static string AM = "ق.ظ";
        public static string PM = "ب.ظ";

        /// <summary>
        /// Specifies the Persian date and time mode to determining the PersianDateTime.Now.
        /// </summary>
        public static PersianDateTimeMode Mode = PersianDateTimeMode.UtcOffset;

        public static TimeSpan DaylightSavingTimeStart = TimeSpan.FromDays(1);
        public static TimeSpan DaylightSavingTimeEnd = TimeSpan.FromDays(185);
        public static TimeSpan DaylightSavingTime = TimeSpan.FromHours(1);
        public static TimeSpan OffsetFromUtc = new TimeSpan(3, 30, 0);

        /// <summary>
        /// A System.TimeZoneInfo object that represents the Persian time zone.
        /// </summary>
        public static TimeZoneInfo PersianTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");

        /// <summary>
        /// Subtracts a specified date and time from another specified date and time and returns a time interval.
        /// </summary>
        /// <param name="d1">The date and time value to subtract from (the minuend).</param>
        /// <param name="d2">The date and time value to subtract (the subtrahend).</param>
        /// <returns>The time interval between d1 and d2; that is, d1 minus d2.</returns>
        public static TimeSpan operator -(PersianDateTime d1, PersianDateTime d2) => d1.ToDateTime() - d2.ToDateTime();

        /// <summary>
        /// Determines whether one specified PersianDateTime is greater than another specified PersianDateTime.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>true if d1 is greater than d2; otherwise, false.</returns>
        public static bool operator >(PersianDateTime d1, PersianDateTime d2) => d1.ToDateTime() > d2.ToDateTime();

        /// <summary>
        /// Determines whether one specified PersianDateTime is greater than or equal to another specified PersianDateTime.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>true if d1 is greater than or equal to d2; otherwise, false.</returns>
        public static bool operator >=(PersianDateTime d1, PersianDateTime d2) => d1.ToDateTime() >= d2.ToDateTime();

        /// <summary>
        /// Determines whether one specified PersianDateTime is less than or equal to another specified PersianDateTime.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>true if d1 is less than or equal to d2; otherwise, false.</returns>
        public static bool operator <=(PersianDateTime d1, PersianDateTime d2) => d1.ToDateTime() <= d2.ToDateTime();

        /// <summary>
        /// Subtracts a specified time interval from a specified date and time and returns a new date and time.
        /// </summary>
        /// <param name="d">The date and time value to subtract from.</param>
        /// <param name="t">The time interval to subtract.</param>
        /// <returns>An object whose value is the value of d minus the value of t.</returns>
        public static PersianDateTime operator -(PersianDateTime d, TimeSpan t) => new PersianDateTime(d.ToDateTime() - t);

        /// <summary>
        /// Adds a specified time interval to a specified date and time, yielding a new date and time.
        /// </summary>
        /// <param name="d">The date and time value to add.</param>
        /// <param name="t">The time interval to add.</param>
        /// <returns>An object that is the sum of the values of d and t.</returns>
        public static PersianDateTime operator +(PersianDateTime d, TimeSpan t) => new PersianDateTime(d.ToDateTime() + t);

        /// <summary>
        /// Determines whether one specified PersianDateTime is less than another specified PersianDateTime.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>true if d1 is less than d2; otherwise, false.</returns>
        public static bool operator <(PersianDateTime d1, PersianDateTime d2) => d1.ToDateTime() < d2.ToDateTime();

        /// <summary>
        /// Determines whether two specified instances of PersianDateTime are equal.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>true if d1 and d2 represent the same date and time; otherwise, false.</returns>
        public static bool operator ==(PersianDateTime d1, PersianDateTime d2)
        {
            if (d1 is null)
            {
                return d2 is null;
            }
            if (d2 is null)
            {
                return false;
            }
            return d1.ToDateTime() == d2.ToDateTime();
        }

        /// <summary>
        /// Determines whether two specified instances of PersianDateTime are not equal.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>true if d1 and d2 do not represent the same date and time; otherwise, false.</returns>
        public static bool operator !=(PersianDateTime d1, PersianDateTime d2) => !(d1 == d2);

        /// <summary>
        /// Returns the name of the specified month.
        /// </summary>
        /// <param name="month">An integer that represents the month, and ranges from 1 through 12.</param>
        /// <returns>The name of the specified month.</returns>
        public static string GetMonthName(int month)
        {
            return monthNames[month + 1];
        }

        /// <summary>
        /// Returns the name of the specified day.
        /// </summary>
        /// <param name="day">An integer that represents the day, and ranges from 0 through 6.</param>
        /// <returns>The name of the specified day.</returns>
        public static string GetDayName(int day)
        {
            return dayNames[day];
        }

        /// <summary>
        /// Determines whether the specified year is a leap year. The number of days is 366 in a leap year.
        /// </summary>
        /// <param name="year">An integer from 1 through 9378 that represents the year.</param>
        /// <returns>true if the specified year is a leap year; otherwise, false.</returns>
        public static bool IsLeapYear(int year)
        {
            return persianCalendar.IsLeapYear(year);
        }

        /// <summary>
        /// Returns the number of days in the specified year.
        /// </summary>
        /// <param name="year">An integer from 1 through 9378 that represents the year.</param>
        /// <returns>The number of days in the specified year. The number of days is 365 in a common year or 366 in a leap year.</returns>
        public static int GetDaysInYear(int year)
        {
            return persianCalendar.GetDaysInYear(year);
        }

        /// <summary>
        /// Returns the number of days in the specified month of the specified year.
        /// </summary>
        /// <param name="year">An integer from 1 through 9378 that represents the year.</param>
        /// <param name="month">An integer that represents the month, and ranges from 1 through 12.</param>
        /// <returns>The number of days in the specified month of the specified year.</returns>
        public static int GetDaysInMonth(int year, int month)
        {
            return persianCalendar.GetDaysInMonth(year, month);
        }

        /// <summary>
        /// Gets a PersianDateTime object that is set to the current date and time in the Persian calendar on this computer.
        /// </summary>
        public static PersianDateTime Now
        {
            get
            {
                switch (Mode)
                {
                    case PersianDateTimeMode.System:
                        return new PersianDateTime(DateTime.Now);

                    case PersianDateTimeMode.PersianTimeZoneInfo:
                        return new PersianDateTime(TimeZoneInfo.ConvertTime(DateTime.Now, PersianTimeZoneInfo));

                    case PersianDateTimeMode.UtcOffset:
                        var now = new PersianDateTime(DateTime.UtcNow.Add(OffsetFromUtc));
                        return now.IsInDaylightSavingTime ? now.Add(DaylightSavingTime) : now;

                    default:
                        throw new NotSupportedException(Mode.ToString());
                }
            }
        }

        /// <summary>
        /// Converts the specified string representation of a date to its PersianDateTime equivalent.
        /// </summary>
        /// <param name="persianDate">A string containing a date to convert.</param>
        public static PersianDateTime Parse(string persianDate)
        {
            return Parse(persianDate, "0");
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its PersianDateTime equivalent.
        /// </summary>
        /// <param name="persianDate">A string containing a date to convert.</param>
        /// <param name="time">A string containing a time to convert.</param>
        public static PersianDateTime Parse(string persianDate, string time)
        {
            return new PersianDateTime(int.Parse(persianDate.Replace("/", "")), int.Parse(time.Replace(":", "")));
        }

        private readonly DateTime dateTime;

        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        public int Year => persianCalendar.GetYear(dateTime);

        /// <summary>
        /// Gets the month component of the date represented by this instance.
        /// </summary>
        public int Month => persianCalendar.GetMonth(dateTime);

        /// <summary>
        /// Gets the day of the month represented by this instance.
        /// </summary>
        public int Day => persianCalendar.GetDayOfMonth(dateTime);

        /// <summary>
        /// Gets the hour component of the date represented by this instance.
        /// </summary>
        public int Hour => dateTime.Hour;

        /// <summary>
        /// Gets the minute component of the date represented by this instance.
        /// </summary>
        public int Minute => dateTime.Minute;

        /// <summary>
        /// Gets the seconds component of the date represented by this instance.
        /// </summary>
        public int Second => dateTime.Second;

        /// <summary>
        /// Gets the milliseconds component of the date represented by this instance.
        /// </summary>
        public int Millisecond => dateTime.Millisecond;

        /// <summary>
        /// Gets the number of ticks that represent the date and time of this instance.
        /// </summary>
        public long Ticks => dateTime.Ticks;

        private bool IsInDaylightSavingTime
        {
            get
            {
                var timeOfYear = TimeOfYear;
                return timeOfYear > DaylightSavingTimeStart && timeOfYear < DaylightSavingTimeEnd;
            }
        }

        /// <summary>
        /// Gets the time of day for this instance.
        /// </summary>
        public TimeSpan TimeOfDay => dateTime.TimeOfDay;

        /// <summary>
        /// Gets the time of year for this instance.
        /// </summary>
        public TimeSpan TimeOfYear => this - FirstDayOfYear;

        /// <summary>
        /// Gets the time of month for this instance.
        /// </summary>
        public TimeSpan TimeOfMonth => this - FirstDayOfMonth;

        /// <summary>
        /// Gets the time of week for this instance.
        /// </summary>
        public TimeSpan TimeOfWeek => this - FirstDayOfWeek;

        /// <summary>
        /// Initializes a new instance of the PersianDateTime class to a specified dateTime.
        /// </summary>
        /// <param name="dateTime">A date and time in the Gregorian calendar.</param>
        public PersianDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        /// <summary>
        /// Initializes a new instance of the PersianDateTime class to the specified Persian date.
        /// </summary>
        /// <param name="persianDate">The Persian date</param>
        public PersianDateTime(int persianDate)
            : this(persianDate, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PersianDateTime class to the specified Persian date and time.
        /// </summary>
        /// <param name="persianDate">The Persian date.</param>
        /// <param name="time">The time.</param>
        public PersianDateTime(int persianDate, short time)
            : this(persianDate, time * 100)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PersianDateTime class to the specified Persian date and time.
        /// </summary>
        /// <param name="persianDate">The Persian date.</param>
        /// <param name="time">The time.</param>
        public PersianDateTime(int persianDate, int time)
        {
            var year = persianDate / 10000;
            var month = (persianDate / 100) % 100;
            var day = persianDate % 100;

            var hour = time / 10000;
            var minute = (time / 100) % 100;
            var second = time % 100;

            dateTime = persianCalendar.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        /// <summary>
        /// Initializes a new instance of the PersianDateTime class to the specified year, month, and day.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        public PersianDateTime(int year, int month, int day)
            : this(year, month, day, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PersianDateTime class to the specified year, month, day, hour, minute, and second.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        /// <param name="second">The seconds (0 through 59).</param>
        public PersianDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            dateTime = persianCalendar.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        /// <summary>
        /// Determines whether the year represented by this instance is a leap year. The number of days is 366 in a leap year.
        /// </summary>
        /// <returns>true if the year represented by this instance is a leap year; otherwise, false.</returns>
        public bool IsLeapYear()
        {
            return persianCalendar.IsLeapYear(Year);
        }

        /// <summary>
        /// Returns the number of days in the year represented by this instance.
        /// </summary>
        public int DaysInYear => persianCalendar.GetDaysInYear(Year);

        /// <summary>
        /// Returns the number of days in the month represented by this instance.
        /// </summary>
        public int DaysInMonth => persianCalendar.GetDaysInMonth(Year, Month);

        /// <summary>
        /// Returns the week of the year that includes the date represented by this instance.
        /// </summary>
        /// <param name="rule">An enumeration value that defines a calendar week.</param>
        /// <returns>A positive integer that represents the week of the year that includes the date represented by this instance.</returns>
        public int GetWeekOfYear(CalendarWeekRule rule)
        {
            return persianCalendar.GetWeekOfYear(dateTime, rule, System.DayOfWeek.Saturday);
        }

        /// <summary>
        /// Gets the day of the year represented by this instance.
        /// </summary>
        public int DayOfYear => persianCalendar.GetDayOfYear(dateTime);

        /// <summary>
        /// Gets the day of the week represented by this instance.
        /// </summary>
        public int DayOfWeek => ((int)dateTime.DayOfWeek + 1) % 7;

        /// <summary>
        /// Gets the name of the day of the week represented by this instance.
        /// </summary>
        public string DayName => dayNames[DayOfWeek];

        /// <summary>
        /// Gets the name of the month represented by this instance.
        /// </summary>
        public string MonthName => monthNames[Month - 1];

        /// <summary>
        /// Gets the date component of this instance.
        /// </summary>
        public PersianDateTime Date => new PersianDateTime(dateTime.Date);

        /// <summary>
        /// Gets the first day of the year represented by this instance.
        /// </summary>
        public PersianDateTime FirstDayOfYear => AddDays(-DayOfYear + 1).Date;

        /// <summary>
        /// Gets the last day of the year represented by this instance.
        /// </summary>
        public PersianDateTime LastDayOfYear => AddDays(DaysInYear - DayOfYear).Date;

        /// <summary>
        /// Gets the first day of the month represented by this instance.
        /// </summary>
        public PersianDateTime FirstDayOfMonth => AddDays(-Day + 1).Date;

        /// <summary>
        /// Gets the last day of the month represented by this instance.
        /// </summary>
        public PersianDateTime LastDayOfMonth => AddDays(DaysInMonth - Day).Date;

        /// <summary>
        /// Gets the first day of the week represented by this instance.
        /// </summary>
        public PersianDateTime FirstDayOfWeek => AddDays(-DayOfWeek).Date;

        /// <summary>
        /// Gets the last day of the week represented by this instance.
        /// </summary>
        public PersianDateTime LastDayOfWeek => AddDays(6 - DayOfWeek).Date;

        /// <summary>
        /// Returns a new PersianDateTime that adds the specified number of seconds to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional seconds. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of seconds represented by value.</returns>
        public PersianDateTime AddSeconds(double value)
        {
            return new PersianDateTime(dateTime.AddSeconds(value));
        }

        /// <summary>
        /// Returns a new PersianDateTime that adds the specified number of minutes to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of minutes represented by value.</returns>
        public PersianDateTime AddMinutes(double value)
        {
            return new PersianDateTime(dateTime.AddMinutes(value));
        }

        /// <summary>
        /// Returns a new PersianDateTime that adds the specified number of hours to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of hours represented by value.</returns>
        public PersianDateTime AddHours(double value)
        {
            return new PersianDateTime(dateTime.AddHours(value));
        }

        /// <summary>
        /// Returns a new PersianDateTime that adds the specified number of years to the value of this instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of years represented by value.</returns>
        public PersianDateTime AddYears(int value)
        {
            return new PersianDateTime(dateTime.AddYears(value));
        }

        /// <summary>
        /// Returns a new PersianDateTime that adds the specified number of months to the value of this instance.
        /// </summary>
        /// <param name="months">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and months.</returns>
        public PersianDateTime AddMonths(int months)
        {
            return new PersianDateTime(dateTime.AddMonths(months));
        }

        /// <summary>
        /// Returns a new PersianDateTime that adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by value.</returns>
        public PersianDateTime AddDays(double value)
        {
            return new PersianDateTime(dateTime.AddDays(value));
        }

        /// <summary>
        /// Returns a new PersianDateTime that adds the value of the specified System.TimeSpan to the value of this instance.
        /// </summary>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time interval represented by value.</returns>
        public PersianDateTime Add(TimeSpan value)
        {
            return new PersianDateTime(dateTime.Add(value));
        }

        /// <summary>
        /// Returns a System.DateTime object that is set to the date and time represented by this instance.
        /// </summary>
        /// <returns>A System.DateTime object that is set to the date and time represented by this instance</returns>
        public DateTime ToDateTime()
        {
            return dateTime;
        }

        /// <summary>
        /// Converts the date represented by this instance to an equivalent 32-bit signed integer.
        /// </summary>
        /// <returns>n 32-bit signed integer equivalent to the date represented by this instance.</returns>
        public int ToInt()
        {
            return int.Parse(Year.ToString() + Month.ToString().PadLeft(2, '0') + Day.ToString().PadLeft(2, '0'));
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the value of the current PersianDateTime object.</returns>
        public override string ToString()
        {
            return ToString(PersianDateTimeFormat.DateTime);
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A custom date and time format string.</param>
        /// <returns>A string representation of value of the current PersianDateTime object as specified by format.</returns>
        public string ToString(string format)
        {
            var towDigitYear = (Year % 100).ToString();
            var month = Month.ToString();
            var day = Day.ToString();
            var fullHour = Hour.ToString();
            var hour = (Hour % 12 == 0 ? 12 : Hour % 12).ToString();
            var minute = Minute.ToString();
            var second = Second.ToString();
            var dayPart = Hour >= 12 ? PM : AM;

            return format.Replace("yyyy", Year.ToString())
                         .Replace("yy", towDigitYear.PadLeft(2, '0'))
                         .Replace("y", towDigitYear)
                         .Replace("MMMM", MonthName)
                         .Replace("MM", month.PadLeft(2, '0'))
                         .Replace("M", month)
                         .Replace("dddd", DayName)
                         .Replace("ddd", DayName[0].ToString())
                         .Replace("dd", day.PadLeft(2, '0'))
                         .Replace("d", day)
                         .Replace("HH", fullHour.PadLeft(2, '0'))
                         .Replace("H", fullHour.ToString())
                         .Replace("hh", hour.PadLeft(2, '0'))
                         .Replace("h", hour.ToString())
                         .Replace("mm", minute.PadLeft(2, '0'))
                         .Replace("m", minute.ToString())
                         .Replace("ss", second.PadLeft(2, '0'))
                         .Replace("s", second)
                         .Replace("tt", dayPart)
                         .Replace('t', dayPart[0]);
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A Persian date and time format string.</param>
        /// <returns>A string representation of value of the current PersianDateTime object as specified by format.</returns>
        public string ToString(PersianDateTimeFormat format)
        {
            switch (format)
            {
                case PersianDateTimeFormat.Date:
                    return Year.ToString() + "/" + Month.ToString().PadLeft(2, '0') + "/" + Day.ToString().PadLeft(2, '0');

                case PersianDateTimeFormat.DateTime:
                    return ToString(PersianDateTimeFormat.Date) + " " + TimeOfDay.ToString("hh\\:mm\\:ss");

                case PersianDateTimeFormat.DateShortTime:
                    return ToString(PersianDateTimeFormat.Date) + " " + TimeOfDay.ToString("hh\\:mm");

                case PersianDateTimeFormat.LongDate:
                    return DayName + " " + Day + " " + MonthName;

                case PersianDateTimeFormat.LongDateFullTime:
                    return DayName + " " + Day + " " + MonthName + " ساعت " + TimeOfDay.ToString("hh\\:mm\\:ss");

                case PersianDateTimeFormat.LongDateLongTime:
                    return DayName + " " + Day + " " + MonthName + " ساعت " + TimeOfDay.ToString("hh\\:mm");

                case PersianDateTimeFormat.ShortDateShortTime:
                    return Day.ToString() + " " + MonthName + " " + TimeOfDay.ToString("hh\\:mm");

                case PersianDateTimeFormat.FullDate:
                    return DayName + " " + Day + " " + MonthName + " " + Year;

                case PersianDateTimeFormat.FullDateLongTime:
                    return DayName + " " + Day + " " + MonthName + " " + Year + " ساعت " + TimeOfDay.ToString("hh\\:mm");

                case PersianDateTimeFormat.FullDateFullTime:
                    return DayName + " " + Day + " " + MonthName + " " + Year + " ساعت " + TimeOfDay.ToString("hh\\:mm\\:ss");

                default:
                    throw new NotImplementedException(format.ToString());
            }
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return dateTime.GetHashCode();
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns>true if value is an instance of PersianDateTime and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object value)
        {
            return Equals(value as PersianDateTime);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified PersianDateTime instance.
        /// </summary>
        /// <param name="value">A PersianDateTime instance to compare to this instance.</param>
        /// <returns>true if the value parameter equals the value of this instance; otherwise, false.</returns>
        public bool Equals(PersianDateTime value)
        {
            if (value is null)
            {
                return false;
            }
            return dateTime.Equals(value.dateTime);
        }

        public static List<string> ReturnDaysWeekString(string gDate)
        {
            var afret = 0;
            var befor = 0;
            var l = new List<string>();
            var pDate = PersianDateTime.Parse(gDate);
            var date = pDate.ToDateTime();
            var day = date.DayOfWeek;
            switch (day)
            {
                case System.DayOfWeek.Friday:
                    {
                        afret = 0;
                        befor = 6;
                        break;
                    }
                case System.DayOfWeek.Monday:
                    {
                        afret = 4;
                        befor = 2;
                        break;
                    }
                case System.DayOfWeek.Saturday:
                    {
                        afret = 6;
                        befor = 0;
                        break;
                    }
                case System.DayOfWeek.Sunday:
                    {
                        afret = 5;
                        befor = 1;
                        break;
                    }
                case System.DayOfWeek.Thursday:
                    {
                        afret = 1;
                        befor = 5;
                        break;
                    }
                case System.DayOfWeek.Tuesday:
                    {
                        afret = 3;
                        befor = 3;
                        break;
                    }
                case System.DayOfWeek.Wednesday:
                    {
                        afret = 2;
                        befor = 4;
                        break;
                    }
            }
            for (var i = befor; i >= 1; i--)
            {
                l.Add(pDate.AddDays(-i).ToString(PersianDateTimeFormat.Date));
            }
            l.Add(pDate.ToString(PersianDateTimeFormat.Date));
            for (var i = 1; i <= afret; i++)
            {
                l.Add(pDate.AddDays(i).ToString(PersianDateTimeFormat.Date));
            }
            return l;
        }

        public static List<PersianDateTime> ReturnDaysWeekPersianDate(string gDate)
        {
            var afret = 0;
            var befor = 0;
            var list = new List<PersianDateTime>();
            var pDate = PersianDateTime.Parse(gDate);
            var date = pDate.ToDateTime();
            var day = date.DayOfWeek;
            switch (day)
            {
                case System.DayOfWeek.Friday:
                    {
                        afret = 0;
                        befor = 6;
                        break;
                    }
                case System.DayOfWeek.Monday:
                    {
                        afret = 4;
                        befor = 2;
                        break;
                    }
                case System.DayOfWeek.Saturday:
                    {
                        afret = 6;
                        befor = 0;
                        break;
                    }
                case System.DayOfWeek.Sunday:
                    {
                        afret = 5;
                        befor = 1;
                        break;
                    }
                case System.DayOfWeek.Thursday:
                    {
                        afret = 1;
                        befor = 5;
                        break;
                    }
                case System.DayOfWeek.Tuesday:
                    {
                        afret = 3;
                        befor = 3;
                        break;
                    }
                case System.DayOfWeek.Wednesday:
                    {
                        afret = 2;
                        befor = 4;
                        break;
                    }
            }
            for (var i = befor; i >= 1; i--)
            {
                list.Add(pDate.AddDays(-i));
            }
            list.Add(pDate);
            for (var i = 1; i <= afret; i++)
            {
                list.Add(pDate.AddDays(i));
            }
            return list;
        }

        public static bool TryParse(string dateString, out PersianDateTime pdate)
        {
            try
            {
                pdate = Parse(dateString);
                return true;
            }
            catch
            {
                pdate = null;
                return false;
            }
        }

        public static string GetTime5Digit(DateTime curDateTime)
        {
            var hour = curDateTime.Hour.ToString(CultureInfo.InvariantCulture);
            var minute = curDateTime.Minute.ToString(CultureInfo.InvariantCulture);
            hour = hour.PadLeft(2, '0');
            minute = minute.PadLeft(2, '0');
            return hour + ":" + minute;
        }

        public static string GetDate8Digit(DateTime dt)
        {
            var pcal = new PersianCalendar();
            var curDT = dt;
            var year = pcal.GetYear(curDT).ToString();
            var month = pcal.GetMonth(curDT).ToString();
            var day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + month + day;
        }

        public static string GetDate10Digit(DateTime dt)
        {
            var pcal = new PersianCalendar();
            var curDT = dt;
            var year = pcal.GetYear(curDT).ToString();
            var month = pcal.GetMonth(curDT).ToString();
            var day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + "/" + month + "/" + day;
        }
    }

    /// <summary>
    /// Specifies the date and time format
    /// </summary>
    public enum PersianDateTimeFormat
    {
        Date = 0,
        DateTime = 1,
        LongDate = 2,
        LongDateLongTime = 3,
        FullDate = 4,
        FullDateLongTime = 5,
        FullDateFullTime = 6,
        DateShortTime = 7,
        ShortDateShortTime = 8,
        LongDateFullTime = 9
    }

    /// <summary>
    /// Specifies the Persian date and time mode to determining the PersianDateTime.Now.
    /// </summary>
    public enum PersianDateTimeMode
    {
        /// <summary>
        /// Using the current time zone.
        /// </summary>
        System,

        /// <summary>
        /// Using the Persian time zone.
        /// </summary>
        PersianTimeZoneInfo,

        /// <summary>
        /// Using the UTC date and time with custom daylight saving time.
        /// </summary>
        UtcOffset
    }
}
