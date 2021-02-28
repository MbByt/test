using BusinessDay.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDay.Services.Dates
{
    public interface IBusinessDayCounter
    {

         int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);

         int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);

        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, PubHolidayRules publicHolidayRules);
   }
}
