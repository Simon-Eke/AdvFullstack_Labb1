using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
