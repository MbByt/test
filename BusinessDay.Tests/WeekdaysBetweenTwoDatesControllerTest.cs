using BusinessDay.Services.Dates;
using BusinessDay.Web.Controllers;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Core;

namespace Tests
{
    public class WeekdaysBetweenTwoDatesControllerTest
    {

        [Test]
        public void WeekdaysBetweenTwoDatesController_ShouldReturnCorrectValues()
        {
            var controller = new WeekdaysBetweenTwoDatesController(new BusinessDayCounter());
            var result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2021-02-28"));
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, 63);
            result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2020-12-1"));
            Assert.AreEqual(result.Value, 0);
            result = controller.Get(DateTime.Parse("2020-12-1"), DateTime.Parse("2020-11-1"));
            Assert.AreEqual(result.Value, 0);
        }

    }
}