using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models
{
    public class Customer
    {
        // CustomerId, Name, PhoneNumber, BookingIdFk
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
