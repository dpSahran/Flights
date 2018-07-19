using FlightsBooking.Models;
using System;
using System.Collections.Generic;

namespace FlightsBooking.Services
{
    public interface IDatabaseRetrieval
    {
        IEnumerable<dynamic> CheckFlightAvailability(int noOfPassengers, DateTime startDate, DateTime endDate);
    }
}
