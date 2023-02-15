using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Rentals
    {
        [Key]
        public int id_rental { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int id_customer { get; set; }
        [Required]
        [ForeignKey("Cars")]
        public int id_car { get; set; }
        [Required]
        [ForeignKey("Payments")]
        public int id_payment { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime date_from { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime date_to { get; set; }
    }
}
