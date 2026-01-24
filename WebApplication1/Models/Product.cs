using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("price")]
        public int Price { get; set; }
        [Required]
        [Column("category")]
        public string Category { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("brand")]
        public string? Brand { get; set; }
    }
}
