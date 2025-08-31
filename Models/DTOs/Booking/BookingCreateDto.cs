namespace AdvFullstack_Labb1.Models.DTOs.Booking
{
    public class BookingCreateDto
    {
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public int CustomerAmount { get; set; }
        public DateTime StartTime { get; set; }
    }
}
