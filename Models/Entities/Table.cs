namespace AdvFullstack_Labb1.Models.Entities
{
    public class Table : BaseEntity
    {
        public int Seatings { get; set; }
        public int TableNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
