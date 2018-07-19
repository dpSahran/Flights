using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightsBooking.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }
        [Required]
        [MaxLength(10)]
        public string FlightNumber { get; set; }
        [Required]
        public TimeSpan DepartTime { get; set; }
        [Required]
        public TimeSpan ArriveTime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Departure { get; set; }
        [Required]
        [MaxLength(50)]
        public string Arrival { get; set; }
        [Required]
        [Range(1, 1000)]
        public Int16 SeatCapacity { get; set; }


        public ICollection<FlightBooking> FlightBookings { get; set; }

    }
}
