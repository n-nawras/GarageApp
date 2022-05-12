using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GarageApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>().HasData(new List<Car>()
            {
                new Car(){LicensePlate = "57NVF9", Brand = "BMW", Odometer = 170000, SalesPrice = 7000 },
                new Car(){LicensePlate = "15NXNS", Brand = "FIAT", Odometer = 180000, SalesPrice = 1500 },

            });
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            });
            base.OnModelCreating(builder);
        }
    }
    public class Car
    {
        [Key]
        public string LicensePlate { get; set; }
        public string Brand { get; set; }

        public decimal Odometer { get; set; }

        public decimal SalesPrice { get; set; }

        public string? ImageFileName { get; set; }

    }
}