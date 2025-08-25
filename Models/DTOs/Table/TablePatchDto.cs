using System.ComponentModel.DataAnnotations;

namespace AdvFullstack_Labb1.Models.DTOs.Table
{
    public class TablePatchDto
    {
        [Range(1, int.MaxValue)]
        public int? Seatings { get; set; }
        [Range(1, int.MaxValue)]
        public int? TableNumber { get; set; }
    }
}
