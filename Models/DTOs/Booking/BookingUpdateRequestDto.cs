namespace AdvFullstack_Labb1.Models.DTOs.Booking
{
    public class BookingUpdateRequestDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime StartTime { get; set; }
        public int CustomerAmount { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
