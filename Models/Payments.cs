using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Payments
    {
        [Key]
        public int id_payment { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public double amount { get; set; }

        [Column(TypeName ="date")]
        public DateTime? payment_date { get; set; }
    }
}
