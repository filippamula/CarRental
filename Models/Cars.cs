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
        public int id_type { get; set; }
        [Required]
        [ForeignKey("Localisations")]
        public int id_localisation { get; set; }
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
