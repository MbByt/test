using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDay.Data.Models;
using BusinessDay.Services.Dates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessDay.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessDaysBetweenTwoDatesController : ControllerBase
    {

        private readonly IBusinessDayCounter _businessDayCounter;

        public BusinessDaysBetweenTwoDatesController(IBusinessDayCounter businessDayCounter)
        {
            _businessDayCounter = businessDayCounter;
        }

        // GET api/firstDate/SecondDate/PublicHolidays
        [HttpGet("{firstDate}/{SecondDate}/{PublicHolidays}")]
        public ActionResult<int> Get(DateTime firstDate, DateTime SecondDate, IList<DateTime> PublicHolidays)
        {
            return _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, SecondDate, PublicHolidays);
        }

        // GET api/BusinessDaysBetweenTwoDatespublicHolidayRules/firstDate/SecondDate/publicHolidayRules
        [Route("api/BusinessDaysBetweenTwoDatespublicHolidayRules")]
        [HttpGet("{firstDate}/{SecondDate}/{PubHolidayRules}")]
        public ActionResult<int> BusinessDaysBetweenTwoDatespublicHolidayRules(DateTime firstDate, DateTime secondDate, PubHolidayRules publicHolidayRules)
        {
            return _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidayRules);
        }
    }
}