using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models.Entities
{
    public class Admin
    {
        // AdminId, Username, PasswordHash
        [Key]
        public int AdminId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }
    }
}
