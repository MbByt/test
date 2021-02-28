using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDay.Data.Models
{
    public class SpecialPubHoliday
    {

        public DayOfWeek WeekDay { get; set; }

        public int Month { get; set; }

        public int Occurrence { get; set; }
    }
}
