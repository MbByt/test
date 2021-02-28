using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDay.Data.Models
{
    public class PubHolidayRules
    {
        public List<SpecialPubHoliday> SpecialDayOfMonthPubHolidays { get; set; }

        public List<MondayPubHoliday> MondayPubHolidays { get; set; }

        public List<StaticPubHoliday> StaticPublicHolidays { get; set; }

    }
}
