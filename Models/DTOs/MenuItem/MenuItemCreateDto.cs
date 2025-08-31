namespace AdvFullstack_Labb1.Models.DTOs.MenuItem
{
    public class MenuItemCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
        public string ImageUrl { get; set; }
    }
}
