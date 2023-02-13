using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Types
    {
        [Key]
        public int id_type { get; set; }
        
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string type { get; set; }      
    }
}
