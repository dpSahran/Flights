using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FlightsBooking.Models
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string ContactNo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public ICollection<FlightBooking> FlightBookings { get; set; }
    }
}