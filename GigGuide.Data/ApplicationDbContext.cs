using Microsoft.EntityFrameworkCore;
using GigGuide.Data.Entities;

namespace GigGuide.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Concert> Concerts { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        // EF Core Fluent API: https://www.learnentityframeworkcore.com/configuration/fluent-api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Om vi vill lägga till fluent ska det in här. 

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder builder)
        {
            Customer customer1 = new Customer
            {
                Id = 1,
                FirstName = "Johanna",
                LastName = "Gull",
                Email = "johanna@datababes.se",
                Phone = "070-6093654",
                Password = "Datababesftw123"
            };
            Customer customer2 = new Customer
            {
                Id = 2,
                FirstName = "Caroline",
                LastName = "Swanpalmer",
                Email = "caroline@datababes.se",
                Phone = "070-1234567",
                Password = "Bosslady123"
            };

            builder.Entity<Customer>().HasData(customer1, customer2);

            Concert concert1 = new Concert
            {
                Id = 1,
                Artist = "Green Day",
                Title = "The Saviors Tour",
                Description = "The american rock band is going on tour for their new album!"
            };

        }

    }
}
