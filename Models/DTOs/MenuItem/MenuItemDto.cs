using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models.DTOs.MenuItem
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
        public string ImageUrl { get; set; }
    }
}
