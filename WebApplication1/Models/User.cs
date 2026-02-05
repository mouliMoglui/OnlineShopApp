using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class User
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }
        
        [Required]
        [Column("password")]
        public string Password { get; set; }
    }
}
