using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvFullstack_Labb1.Models
{
    // Composite key structure
    public class TableBooking
    {
        // TableIdFk, BookingIdFk
        public int TableId { get; set; }
        public int BookingId { get; set; }
        public virtual Table Table { get; set; } = null!;
        public virtual Booking Booking { get; set; } = null!;
    }
}
