using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvFullstack_Labb1.Models.Entities
{
    public class Booking : BaseEntity
    {
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerAmount { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
