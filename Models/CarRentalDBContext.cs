using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.Models
{
    public class CarRentalDBContext : DbContext
    {
        public CarRentalDBContext(DbContextOptions<CarRentalDBContext>options) : base(options)
        {

        }
        public DbSet<Types> types { get; set; }
        public DbSet<Payments> payments { get; set; }
        public DbSet<Localisations> localisations { get; set; }
    }
}
