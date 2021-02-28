using System;
using System.Collections.Generic;
using BusinessDay.Data.Models;
using BusinessDay.Common.Extensions;

namespace BusinessDay.Common.Helpers
{
    public static class PubHolidayHlpr
    {
        //Gets  Dates Of Unchanging Public Holidays 
        public static IEnumerable<DateTime> GetUnchangingPubHolidays(IReadOnlyCollection<StaticPubHoliday> staticPubHoliday, int firstYear, int secondYear)
        {
            List<DateTime> dateTimeList = new List<DateTime>();
            if (staticPubHoliday == null)
                return dateTimeList;
            foreach (StaticPubHoliday unchangingPublicHoliday in staticPubHoliday)
            {
                for (int currentYear = firstYear; currentYear <= secondYear; ++currentYear)
                    dateTimeList.Add(new DateTime(currentYear, unchangingPublicHoliday.Month, unchangingPublicHoliday.Day));
            }
            return dateTimeList;
        }
        // Dates Of Unchanging Public Holidays conidering Mondays 
        public static IEnumerable<DateTime> GetMondayUnchangingPubHolidays(IReadOnlyCollection<MondayPubHoliday> mondayPubHoliday, int firstYear, int secondYear)
        {
            List<DateTime> dateTimeList = new List<DateTime>();
            if (mondayPubHoliday == null)
                return dateTimeList;
            foreach (MondayPubHoliday mondayisedPublicHoliday in mondayPubHoliday)
            {
                for (int currentYear = firstYear; currentYear <= secondYear; ++currentYear)
                {
                    dateTimeList.Add(new DateTime(currentYear, mondayisedPublicHoliday.Month, mondayisedPublicHoliday.Day).GetNextMondayIfOnWeekend());
                }
            }
            return dateTimeList;
        }
        // Dates Of Unchanging Public Holidays conidering Special days as Holidays 
        public static IEnumerable<DateTime> GetSpecialPubHolidays(IReadOnlyCollection<SpecialPubHoliday> specialPubHoliday, int firstYear, int secondYear)
        {
            List<DateTime> dateTimeList = new List<DateTime>();
            if (specialPubHoliday == null)
                return dateTimeList;
            foreach (SpecialPubHoliday monthPublicHoliday in specialPubHoliday)
            {
                for (int currentYear = firstYear; currentYear <= secondYear; ++currentYear)
                    dateTimeList.Add(DateOfSpecialPubHolidays(monthPublicHoliday, currentYear));
            }
            return dateTimeList;
        }


        private static DateTime DateOfSpecialPubHolidays(SpecialPubHoliday specialPubHoliday, int currentYear)
        {
            DateTime monthPublicHoliday = new DateTime(currentYear, specialPubHoliday.Month, 1);
            int num = monthPublicHoliday.CountDaysToWeekday(specialPubHoliday.WeekDay) + ((specialPubHoliday.Occurrence - 1)*7);
            return monthPublicHoliday.AddDays(num);
        }

   

    }

}
