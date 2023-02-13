using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Localisations
    {
        [Key]
        public int id_localisation { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string city { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string street { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int number { get; set; }
    }
}
