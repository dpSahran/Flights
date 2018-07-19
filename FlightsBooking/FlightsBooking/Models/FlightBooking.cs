using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightsBooking.Models
{
    public class FlightBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightBookingId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string ArrivalCity { get; set; }
        [Required]
        [MaxLength(50)]
        public string DeparterCity { get; set; }
        [Required]
        [Range(1, 1000)]
        public Int32? NumberOfPassengers { get; set; }

        [Required]
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        [Required]
        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }

    }
}