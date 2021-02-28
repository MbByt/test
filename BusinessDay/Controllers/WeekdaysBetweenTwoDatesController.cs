using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDay.Services.Dates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessDay.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekdaysBetweenTwoDatesController : ControllerBase
    {
        private readonly IBusinessDayCounter _businessDayCounter;
        public WeekdaysBetweenTwoDatesController(IBusinessDayCounter businessDayCounter)
        {
            _businessDayCounter = businessDayCounter;
        }

        // GET api/firstDate/SecondDate
        [HttpGet("{firstDate}/{SecondDate}")]
        public ActionResult<int> Get( DateTime firstDate, DateTime SecondDate)
        {
             
            return _businessDayCounter.WeekdaysBetweenTwoDates(firstDate, SecondDate);
        }

       
    }
}