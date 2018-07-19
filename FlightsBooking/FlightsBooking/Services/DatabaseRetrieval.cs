using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsBooking.Models;

namespace FlightsBooking.Services
{
    public class DatabaseRetrieval : IDatabaseRetrieval
    {
        private FlightDBContext _dbContext;
        public DatabaseRetrieval(FlightDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IEnumerable<dynamic> CheckFlightAvailability(int noOfPassengers, DateTime startDate, DateTime endDate)
        {
            
            // Get all flights details with number of passengers booked for date specified.    
            // Only get passengers number if they are travelling with in date spcified for request.
             var avFlight = from F in _dbContext.Flights
                           join FB in _dbContext.FlightBookings on F.FlightId equals FB.Flight.FlightId into gF
                           from FB in gF.DefaultIfEmpty()
                           select new { F.FlightId, F.FlightNumber, F.DepartTime, F.ArriveTime, F.Departure, F.Arrival, F.SeatCapacity,
                               NumberOfPassengers =(
                               (FB.BookingDate >= startDate && FB.BookingDate <= endDate)?
                               (Convert.ToString(FB.NumberOfPassengers) == null || Convert.ToString(FB.NumberOfPassengers) == string.Empty) ? 0 : FB.NumberOfPassengers
                               :0
                               )
                               
                           };
            //  get seat available for all flights.      
            var availableFlights = from AF in avFlight
                               group AF by new { AF.FlightId } into g
                               select new
                               {
                                   FlightNumber = g.First().FlightNumber,
                                   DepartTime = g.First().DepartTime,
                                   ArriveTime = g.First().ArriveTime,
                                   Departure = g.First().Departure,
                                   Arrival = g.First().Arrival,
                                   SeatAvailable = g.First().SeatCapacity - g.Sum(s => s.NumberOfPassengers)
                               };

            return availableFlights;


                                   }
    }
}
