using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDay.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CountDaysToWeekday(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            DateTime _dateTime = dateTime;
            int c = 0;
            while (_dateTime.DayOfWeek != dayOfWeek)
            {
                c++;
                _dateTime += TimeSpan.FromDays(1);
            }
            return c;
        }

        public static DateTime GetNextMondayIfOnWeekend(this DateTime dateTime)
        {
            if (dateTime.IsSaturday())
                return dateTime.AddDays(2.0);
            return dateTime.IsSunday() ? dateTime.AddDays(1) : dateTime;
        }

        public static bool IsWeekday(this DateTime dateTime) => !IsWeekend(dateTime);

        public static bool IsBetweenTwoDates(this DateTime dateTime,DateTime firstDate, DateTime secondDate)
        {
            return dateTime > firstDate && dateTime < secondDate;
        }

        private static bool IsWeekend(DateTime dateTime) => dateTime.IsSaturday() || dateTime.IsSunday();

        private static bool IsSaturday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Saturday;

        private static bool IsSunday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Sunday;
    }
}

