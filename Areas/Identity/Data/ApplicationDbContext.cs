using CarRental.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.Data;

public class ApplicationDbContext : IdentityDbContext<Customer>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Types> types { get; set; }
    public DbSet<Payments> payments { get; set; }
    public DbSet<Localisations> localisations { get; set; }
    public DbSet<Cars> cars { get; set; }
    public DbSet<Rentals> rentals { get; set; }
    public DbSet<Customer> customers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Seed Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                Name = "User",
                NormalizedName = "USER"
            }
        );
        //Seed Admin and User
        var hasher = new PasswordHasher<Customer>();
        builder.Entity<Customer>().HasData(
            new Customer
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                UserName = "admin@admin.admin",
                NormalizedUserName = "ADMIN@ADMIN.ADMIN",
                PasswordHash = hasher.HashPassword(null, "admin"),
                Email = "admin@admin.admin",
                NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                PhoneNumber = "123456789",
                first_name = "Admin",
                last_name = "Admin"
            },
            new Customer
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                UserName = "user@user.user",
                NormalizedUserName = "USER@USER.USER",
                PasswordHash = hasher.HashPassword(null, "user"),
                Email = "user@user.user",
                NormalizedEmail = "USER@USER.USER",
                PhoneNumber = "987654321",
                first_name = "User",
                last_name = "User"
            }
         );
        //Add roles for Admin and User
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb8"
            }
        );

        //Seed Types
        builder.Entity<Types>().HasData(
            new Types
            {
                id_type = 1,
                type = "Sedan"
            },
            new Types
            {
                id_type = 2,
                type = "Sports"
            },
            new Types
            {
                id_type = 3,
                type = "Suv"
            },
            new Types
            {
                id_type = 4,
                type = "Cupe"
            }
            );

        //Seed Localisations
        builder.Entity<Localisations>().HasData(
            new Localisations
            {
                id_localisation = 1,
                city = "Kraków",
                street = "Filipa",
                number = 1
            },
            new Localisations
            {
                id_localisation = 2,
                city = "Warszawa",
                street = "Długa",
                number = 23
            }
            );

        //Seed Cars
        builder.Entity<Cars>().HasData(
            new
            {
                id_car = 1,
                make = "Mercedes",
                model = "S500",
                power = 300,
                vin = "4T1BF12B3VU142754",
                price_per_day = (decimal)500,
                Types = 1,
                Localisations = 1
            },
            new
            {
                id_car = 2,
                make = "Tesla",
                model = "Roadster",
                power = 700,
                vin = "JH4KA8270RC000976",
                price_per_day = (decimal)700,
                Types = 2,
                Localisations = 1
            },
            new
            {
                id_car = 3,
                make = "Mercedes",
                model = "190",
                power = 120,
                vin = "1FTRW14W84KC76110",
                price_per_day = (decimal)200,
                Types = 1,
                Localisations = 1
            },
            new
            {
                id_car = 4,
                make = "BMW",
                model = "X3",
                power = 200,
                vin = "1FTJW36F2TEA03179",
                price_per_day = (decimal)300,
                Types = 3,
                Localisations = 2
            },
            new
            {
                id_car = 5,
                make = "Ford",
                model = "Mustang",
                power = 400,
                vin = "JH4DC4450RS002529",
                price_per_day = (decimal)450,
                Types = 4,
                Localisations = 2
            }
            );
    }


}
