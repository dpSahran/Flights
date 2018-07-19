using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsBooking.Models
{
    public static class FlightDBInitializer
    {
        public static void SeedDataforDBContext(this FlightDBContext DBContext)
        {
            if (!DBContext.Flights.Any())
            {
                DBContext.Flights.AddRange(                       
                        new Flight
                        {
                            FlightNumber = "F100",
                            DepartTime = new TimeSpan(5, 0, 0),
                            ArriveTime = new TimeSpan(7, 0, 0),
                            Departure = "Melbourne",
                            Arrival = "Sydney",
                            SeatCapacity = 30
                        },
                        new Flight
                        {
                            FlightNumber = "F105",
                            DepartTime = new TimeSpan(8, 0, 0),
                            ArriveTime = new TimeSpan(10, 0, 0),
                            Departure = "Melbourne",
                            Arrival = "Adelaide",
                            SeatCapacity = 50
                        }                       
                        
                        );
                DBContext.SaveChanges();
            }
            if (!DBContext.Passengers.Any())
            {
                DBContext.Passengers.AddRange(
                        new Passenger
                        {
                            Name = "Jason",
                            ContactNo = "0402 321 231",
                            Email = "js@outlook.com"
                        },
                        new Passenger
                        {
                            Name = "Ashleigh",
                            ContactNo = "0456 235 456",
                            Email = "as@outlook.com"
                        },
                        new Passenger
                        {
                            Name = "Kim",
                            ContactNo = "0437 235 234",
                            Email = "ks@outlook.com"
                        },
                        new Passenger
                        {
                            Name = "Robert",
                            ContactNo = "0456 123 456",
                            Email = "rb@outlook.com"
                        }

                        );
                DBContext.SaveChanges();
            }

            if (!DBContext.FlightBookings.Any())
            {
                var _flightId = DBContext.Flights.Where(f => f.FlightNumber == "F100").FirstOrDefault<Flight>().FlightId;
                var _PassengerId = DBContext.Passengers.Where(P => P.Name == "Kim").FirstOrDefault<Passenger>().PassengerId;

                DBContext.FlightBookings.AddRange(
                    new FlightBooking
                    {
                        Flight = new Flight() {FlightId= _flightId },
                        Passenger = new Passenger() { PassengerId = _PassengerId },
                        ArrivalCity = "Melbourne",
                        DeparterCity = "Sydney",
                        BookingDate = new DateTime(2018, 2, 06),                                              
                        NumberOfPassengers = 3

                    }
                    );
                DBContext.SaveChanges();
            }
        }


    }
}
