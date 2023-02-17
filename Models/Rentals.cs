using CarRental.Areas.Identity.Data;
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
        public Customer customer { get; set; }
        [Required]
        [ForeignKey("Cars")]
        public Cars car { get; set; }
        [Required]
        [ForeignKey("Payments")]
        public Payments payment { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime date_from { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime date_to { get; set; }
    }
}
