namespace AdvFullstack_Labb1.Models
{
    public class Table
    {
        // TableId, Seatings, TableNumber
        public int TableId { get; set; }
        public int Seatings { get; set; }
        public int TableNumber { get; set; }
        public virtual ICollection<TableBooking> TableBookings { get; set; } = new List<TableBooking>();
    }
}
