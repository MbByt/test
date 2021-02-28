using BusinessDay.Services.Dates;
using BusinessDay.Web.Controllers;
using BusinessDay.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDay.Tests
{
    public class BusinessDaysBetweenTwoDatesControllerTest
    {

        [Test]
        public void BusinessDaysBetweenTwoDatesControllerTest_ShouldReturnCorrectValues()
        {
            var controller = new BusinessDaysBetweenTwoDatesController(new BusinessDayCounter());
            var result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2021-05-28"), GetSamplePubHolidays());
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, 124);
            result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2020-12-1"), GetSamplePubHolidays());
            Assert.AreEqual(result.Value, 0);
            result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2020-11-1"), GetSamplePubHolidays());
            Assert.AreEqual(result.Value, 0);
        }

        [Test]
        public void BusinessDaysBetweenTwoDatesControllerTest_ShouldReturnCorrectValuesWithRules()
        {
            var controller = new BusinessDaysBetweenTwoDatesController(new BusinessDayCounter());
            var result = controller.BusinessDaysBetweenTwoDatespublicHolidayRules(DateTime.Parse("2020-12-1"), DateTime.Parse("2021-05-28"), GetSampleRules());
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, 127);
            result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2020-12-1"), GetSamplePubHolidays());
            Assert.AreEqual(result.Value, 0);
            result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2020-11-1"), GetSamplePubHolidays());
            Assert.AreEqual(result.Value, 0);
        }


        private IList<DateTime> GetSamplePubHolidays()
        {
            List<DateTime> PubHolidays = new List<DateTime>();
            PubHolidays.Add(DateTime.Parse("2021-05-28"));
            PubHolidays.Add(DateTime.Parse("2021-04-16"));
            PubHolidays.Add(DateTime.Parse("2021-02-05"));
            PubHolidays.Add(DateTime.Parse("2021-01-24"));
            PubHolidays.Add(DateTime.Parse("2021-05-07"));
            return PubHolidays;

        }

        private PubHolidayRules GetSampleRules()
        {
            PubHolidayRules PubHolidayRules = new PubHolidayRules();

            List<SpecialPubHoliday> specialPubHolidays = new List<SpecialPubHoliday>();

            List<MondayPubHoliday> mondayPubHolidays = new List<MondayPubHoliday>();

            List<StaticPubHoliday> staticPubHolidays = new List<StaticPubHoliday>();

            specialPubHolidays.Add(new SpecialPubHoliday { Month = 1, Occurrence = 4, WeekDay = DayOfWeek.Sunday });

            mondayPubHolidays.Add(new MondayPubHoliday { Day = 4, Month = 8 });

            staticPubHolidays.Add(new StaticPubHoliday { Day = 1, Month= 9 });

            PubHolidayRules= new PubHolidayRules
            {
                MondayPubHolidays = mondayPubHolidays,
                SpecialDayOfMonthPubHolidays = specialPubHolidays,
                StaticPublicHolidays = staticPubHolidays
            };

            return PubHolidayRules;

        }
    }
}
