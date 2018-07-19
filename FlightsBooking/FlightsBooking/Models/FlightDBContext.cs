using Microsoft.EntityFrameworkCore;

namespace FlightsBooking.Models
{
    public class FlightDBContext: DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }

        public FlightDBContext(DbContextOptions<FlightDBContext> options)
            : base(options)
        {           
            Database.EnsureCreated();
        }
    }
}
