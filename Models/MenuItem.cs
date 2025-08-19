using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models
{
    public class MenuItem
    {
        // MenuItemId, Name, Price, IsPopular, ImageUrl
        [Key]
        public int MenuItemId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Precision(10, 2)]
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
        [MaxLength(2048)]
        public string ImageUrl { get; set; }
    }
}
