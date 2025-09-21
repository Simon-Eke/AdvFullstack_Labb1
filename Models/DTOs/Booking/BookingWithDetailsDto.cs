using AdvFullstack_Labb1.Models.DTOs.Customer;
using AdvFullstack_Labb1.Models.DTOs.Table;

namespace AdvFullstack_Labb1.Models.DTOs.Booking
{
    public class BookingWithDetailsDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; } 
        public TableDto Table { get; set; }
        public int CustomerAmount { get; set; }
        public DateTime StartTime { get; set; }
    }
}
