using System;
using System.Collections.Generic;
using BusinessDay.Data.Models;
using BusinessDay.Common.Helpers;
using BusinessDay.Common.Extensions;
using System.Linq;

namespace BusinessDay.Services.Dates
{
    public class BusinessDayCounter :IBusinessDayCounter
    {

        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
           if (secondDate <= firstDate)
            {
                return 0;
            }
            else
            {
                return Weekdays(firstDate, secondDate);
            }
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            if (secondDate <= firstDate)
            {
                return 0;
            }
            else
            {
                publicHolidays = RemoveDuplicateDates(publicHolidays);
                return Weekdays(firstDate, secondDate) - publicHolidays.Count(IsWeekdayBetweenTwoDates(firstDate, secondDate));
            }
        }

        public int BusinessDaysBetweenTwoDates( DateTime firstDate,DateTime secondDate,PubHolidayRules publicHolidayRules)
        {
            if (secondDate <= firstDate)
            {
                return 0;
            }
            else
            {
                List<DateTime> dateTimeList = new List<DateTime>();
                dateTimeList.AddRange(PubHolidayHlpr.GetSpecialPubHolidays(publicHolidayRules.SpecialDayOfMonthPubHolidays, firstDate.Year, secondDate.Year));
                dateTimeList.AddRange(PubHolidayHlpr.GetMondayUnchangingPubHolidays(publicHolidayRules.MondayPubHolidays, firstDate.Year, secondDate.Year));
                dateTimeList.AddRange(PubHolidayHlpr.GetUnchangingPubHolidays(publicHolidayRules.StaticPublicHolidays, firstDate.Year, secondDate.Year));
                return BusinessDaysBetweenTwoDates(firstDate, secondDate, dateTimeList);
            }
        }

        private static int Weekdays( DateTime firstDate, DateTime secondDate)
        {
            int c = 0;
            DateTime dateTime = firstDate.AddDays(1);
            while (dateTime < secondDate)
            {
                if (dateTime.IsWeekday())
                    c++;
                dateTime += TimeSpan.FromDays(1);
            }
            return c;
        }


        private static Func<DateTime, bool> IsWeekdayBetweenTwoDates( DateTime firstDate,DateTime secondDate)
        {
            return dateTime => dateTime.IsBetweenTwoDates(firstDate, secondDate) && dateTime.IsWeekday();
        }

        private static List<DateTime> RemoveDuplicateDates(IEnumerable<DateTime> dateTimes) => dateTimes.Distinct().ToList();
    }

}
