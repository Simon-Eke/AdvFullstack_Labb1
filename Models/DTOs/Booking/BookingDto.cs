using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models.DTOs.Booking
{
    public class BookingDto
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int CustomerAmount { get; set; }
        public DateTime StartTime { get; set; }
    }
}
