using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models.DTOs.Table
{
    public class TableCreateDto
    {
        public int Seatings { get; set; }
        public int TableNumber { get; set; }
    }
}
