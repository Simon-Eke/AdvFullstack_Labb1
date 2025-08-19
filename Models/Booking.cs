using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models
{
    public class Booking
    {
        // BookingId, Date, Time, CustomerAmount
        public int BookingId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime => StartTime.AddHours(2);
        public int CustomerAmount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<TableBooking> TableBookings { get; set; } = new List<TableBooking>();
    }
}
