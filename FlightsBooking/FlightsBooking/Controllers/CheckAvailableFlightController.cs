using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsBooking.Models;
using FlightsBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightsBooking.Controllers
{
    [Route("api/availableflight")]
    public class CheckAvailableFlightController : ControllerBase
    {
        private IDatabaseRetrieval _dbRetrieval;

        public CheckAvailableFlightController(IDatabaseRetrieval DatabaseRetrieval)
        {
            _dbRetrieval = DatabaseRetrieval;
        }

        [HttpGet("{noOfPax}")]        
        public IActionResult CheckFlightAvailability(int noOfPax, DateTime startDate, DateTime endDate)
        {
            IEnumerable<dynamic> flights = _dbRetrieval.CheckFlightAvailability(noOfPax, startDate, endDate);

            if (flights == null)
            {
                return NotFound();
            }
                        
            return Ok(flights);
        }



    }
}
