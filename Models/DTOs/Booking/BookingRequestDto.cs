using AdvFullstack_Labb1.Models.DTOs.Customer;
using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models.DTOs.Booking
{
    public class BookingRequestDto
    {
        public int TableId { get; set; }

        public DateTime StartTime { get; set; }
        [Range(1, 20)]
        public int CustomerAmount { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(20), Phone]
        public string PhoneNumber { get; set; }
    }
}
