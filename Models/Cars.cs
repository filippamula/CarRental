using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Cars
    {
        [Key]
        public int id_car { get; set; }
        [Required]
        [ForeignKey("Types")]
        public Types type { get; set; }
        [Required]
        [ForeignKey("Localisations")]
        public Localisations localisation { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string make { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string model { get; set; }
        [Required]
        [Column(TypeName = "char(17)")]
        public string vin { get; set; }

        public int power { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal price_per_day { get; set; }
    }
}
