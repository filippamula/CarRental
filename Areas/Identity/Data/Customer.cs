using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Customer class
public class Customer : IdentityUser
{
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string first_name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string last_name { get; set; }
}

