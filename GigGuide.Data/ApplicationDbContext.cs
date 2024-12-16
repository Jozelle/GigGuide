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

            //Om vi vill lägga till Fluent ska det in här. 

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
            Concert concert2 = new Concert
            {
                Id = 2,
                Artist = "GHOST",
                Title = "World Tour 2025",
                Description = "GHOST is on a world tour and want you to join!"
            };
            Concert concert3 = new Concert
            {
                Id = 3,
                Artist = "Billie Eilish",
                Title = "Hit me hard and soft: the tour",
                Description = ""
            };
            Concert concert4 = new Concert
            {
                Id = 4,
                Artist = "Sabrina Carpenter",
                Title = "Short n´Sweet Tour",
                Description = ""
            };
            Concert concert5 = new Concert
            {
                Id = 5,
                Artist = "The Offspring",
                Title = "Supercharged Worldwide in ´25",
                Description = "Following their eleventh studio album, The Offspring is going on tour! "
            };
            Concert concert6 = new Concert
            {
                Id = 6,
                Artist = "Imagine Dragons",
                Title = "LOOM World Tour",
                Description = "Imagine Dragons are back on tour!"
            };
            Concert concert7 = new Concert
            {
                Id = 7,
                Artist = "Iron Maiden",
                Title = "Run for Your Lives World Tour",
                Description = "Iron Maiden are back on tour!"
            };
            Concert concert8 = new Concert
            {
                Id = 8,
                Artist = "OneRepublic",
                Title = "Escape To Europe 2025",
                Description = "OneRepublic is going on tour!"
            };

            builder.Entity<Concert>().HasData(concert1, concert2, concert3, concert4, concert5, concert6, concert7, concert8);

            Venue venue1 = new Venue
            {
                Id = 1,
                Name = "Avicii Arena",
                Address = "Arenavägen 35",
                City = "Stockholm",
                Country = "Sweden"
            };
            Venue venue2 = new Venue
            {
                Id = 2,
                Name = "Hovet",
                Address = "Arenavägen 35",
                City = "Stockholm",
                Country = "Sweden"
            };
            Venue venue3 = new Venue
            {
                Id = 3,
                Name = "Saab Arena",
                Address = "Gumpekullavägen 1",
                City = "Linköping",
                Country = "Sweden"
            };
            Venue venue4 = new Venue
            {
                Id = 4,
                Name = "Göransson Arena",
                Address = "Arenavägen 4",
                City = "Sandviken",
                Country = "Sweden"
            };
            Venue venue5 = new Venue
            {
                Id = 5,
                Name = "Unity Arena",
                Address = "John Strandrupsvei 16",
                City = "Oslo",
                Country = "Norway"
            };
            Venue venue6 = new Venue
            {
                Id = 6,
                Name = "Helsinki Jäähalli",
                Address = "Nordenskiöldinkatu 11-13",
                City = "Helsinki",
                Country = "Finland"
            };
            Venue venue7 = new Venue
            {
                Id = 7,
                Name = "Royal Arena",
                Address = "Hannemanns Allé 18-20",
                City = "Copenhagen",
                Country = "Denmark"
            };
            Venue venue8 = new Venue
            {
                Id = 8,
                Name = "Tons of Rock",
                Address = "Ekebergsletta",
                City = "Oslo",
                Country = "Norway"
            };
            Venue venue9 = new Venue
            {
                Id = 9,
                Name = "STHLM Fields",
                Address = "Gärdet",
                City = "Stockholm",
                Country = "Sweden"
            };
            Venue venue10 = new Venue
            {
                Id = 10,
                Name = "Tinderbox",
                Address = "Tusindårsskoven",
                City = "Falen, Odense V",
                Country = "Denmark"
            };
            Venue venue11 = new Venue
            {
                Id = 11,
                Name = "Tele2 Arena",
                Address = "Arenaslingan 14",
                City = "Stockholm",
                Country = "Sweden"
            };
            Venue venue12 = new Venue
            {
                Id = 12,
                Name = "Bryggeribyen - EC Dahls Arena",
                Address = "Stiklestadveien 2",
                City = "Trondheim",
                Country = "Norway"
            };

            builder.Entity<Venue>().HasData(venue1, venue2, venue3, venue4, venue5, venue6, venue7, venue8, venue9, venue10, venue11);

            Performance performance1 = new Performance
            {
                Id = 1,
                PerformanceTime = new DateTime(2025, 06, 24, 20, 0, 0),
                TicketPrice = 895,
                TicketsAvailable = 8000,
                ConcertId = 1,
                VenueId = 9
            };
            Performance performance2 = new Performance
            {
                Id = 2,
                PerformanceTime = new DateTime(2025, 06, 26, 20, 0, 0),
                TicketPrice = 1200,
                TicketsAvailable = 10000,
                ConcertId = 1,
                VenueId = 8
            };
            Performance performance3 = new Performance
            {
                Id = 3,
                PerformanceTime = new DateTime(2025, 06, 28, 20, 0, 0),
                TicketPrice = 895,
                TicketsAvailable = 7000,
                ConcertId = 1,
                VenueId = 10
            };
            Performance performance4 = new Performance
            {
                Id = 4,
                PerformanceTime = new DateTime(2025, 05, 22, 20, 0, 0),
                TicketPrice = 895,
                TicketsAvailable = 6000,
                ConcertId = 2,
                VenueId = 3
            };
            Performance performance5 = new Performance
            {
                Id = 5,
                PerformanceTime = new DateTime(2025, 05, 23, 20, 0, 0),
                TicketPrice = 895,
                TicketsAvailable = 8000,
                ConcertId = 2,
                VenueId = 4
            };
            Performance performance6 = new Performance
            {
                Id = 6,
                PerformanceTime = new DateTime(2025, 05, 17, 20, 0, 0),
                TicketPrice = 895,
                TicketsAvailable = 10000,
                ConcertId = 2,
                VenueId = 7
            };
            Performance performance7 = new Performance
            {
                Id = 7,
                PerformanceTime = new DateTime(2025, 04, 23, 20, 0, 0),
                TicketPrice = 1295,
                TicketsAvailable = 60000,
                ConcertId = 3,
                VenueId = 1
            };
            Performance performance8 = new Performance
            {
                Id = 8,
                PerformanceTime = new DateTime(2025, 04, 24, 20, 0, 0),
                TicketPrice = 1295,
                TicketsAvailable = 60000,
                ConcertId = 3,
                VenueId = 1
            };
            Performance performance9 = new Performance
            {
                Id = 9,
                PerformanceTime = new DateTime(2025, 04, 26, 20, 0, 0),
                TicketPrice = 1295,
                TicketsAvailable = 35000,
                ConcertId = 3,
                VenueId = 5
            };
            Performance performance10 = new Performance
            {
                Id = 10,
                PerformanceTime = new DateTime(2025, 04, 28, 20, 0, 0),
                TicketPrice = 1295,
                TicketsAvailable = 35000,
                ConcertId = 3,
                VenueId = 7
            };
            Performance performance11 = new Performance
            {
                Id = 11,
                PerformanceTime = new DateTime(2025, 04, 03, 20, 0, 0),
                TicketPrice = 1095,
                TicketsAvailable = 60000,
                ConcertId = 4,
                VenueId = 1
            }; 
            Performance performance12 = new Performance
            {
                Id = 12,
                PerformanceTime = new DateTime(2025, 04, 04, 20, 0, 0),
                TicketPrice = 1095,
                TicketsAvailable = 60000,
                ConcertId = 4,
                VenueId = 1
            };
            Performance performance13 = new Performance
            {
                Id = 13,
                PerformanceTime = new DateTime(2025, 03, 30, 20, 0, 0),
                TicketPrice = 1095,
                TicketsAvailable = 35000,
                ConcertId = 4,
                VenueId = 5
            };
            Performance performance14 = new Performance
            {
                Id = 14,
                PerformanceTime = new DateTime(2025, 03, 31, 20, 0, 0),
                TicketPrice = 1095,
                TicketsAvailable = 35000,
                ConcertId = 4,
                VenueId = 7
            };
            Performance performance15 = new Performance
            {
                Id = 15,
                PerformanceTime = new DateTime(2025, 04, 01, 20, 0, 0),
                TicketPrice = 1095,
                TicketsAvailable = 35000,
                ConcertId = 4,
                VenueId = 7
            };
            Performance performance16 = new Performance
            {
                Id = 16,
                PerformanceTime = new DateTime(2025, 10, 09, 19, 30, 0),
                TicketPrice = 1095,
                TicketsAvailable = 20000,
                ConcertId = 5,
                VenueId = 2
            };
            Performance performance17 = new Performance
            {
                Id = 17,
                PerformanceTime = new DateTime(2025, 10, 10, 19, 30, 0),
                TicketPrice = 1095,
                TicketsAvailable = 20000,
                ConcertId = 5,
                VenueId = 5
            };
            Performance performance18 = new Performance
            {
                Id = 18,
                PerformanceTime = new DateTime(2025, 06, 05, 19, 30, 0),
                TicketPrice = 1095,
                TicketsAvailable = 40000,
                ConcertId = 6,
                VenueId = 11
            };
            Performance performance19 = new Performance
            {
                Id = 19,
                PerformanceTime = new DateTime(2025, 06, 12, 19, 30, 0),
                TicketPrice = 1495,
                TicketsAvailable = 40000,
                ConcertId = 7,
                VenueId = 11
            };
            Performance performance20 = new Performance
            {
                Id = 20,
                PerformanceTime = new DateTime(2025, 06, 13, 19, 30, 0),
                TicketPrice = 1495,
                TicketsAvailable = 40000,
                ConcertId = 7,
                VenueId = 11
            };
            Performance performance21 = new Performance
            {
                Id = 21,
                PerformanceTime = new DateTime(2025, 06, 5, 19, 30, 0),
                TicketPrice = 1495,
                TicketsAvailable = 40000,
                ConcertId = 7,
                VenueId = 12
            };
            Performance performance22 = new Performance
            {
                Id = 22,
                PerformanceTime = new DateTime(2025, 06, 9, 19, 30, 0),
                TicketPrice = 1495,
                TicketsAvailable = 40000,
                ConcertId = 7,
                VenueId = 7
            };
            Performance performance23 = new Performance
            {
                Id = 23,
                PerformanceTime = new DateTime(2025, 10, 31, 19, 30, 0),
                TicketPrice = 1195,
                TicketsAvailable = 40000,
                ConcertId = 8,
                VenueId = 1
            };
            Performance performance24 = new Performance
            {
                Id = 24,
                PerformanceTime = new DateTime(2025, 10, 30, 19, 30, 0),
                TicketPrice = 1195,
                TicketsAvailable = 40000,
                ConcertId = 8,
                VenueId = 7
            };
            Performance performance25 = new Performance
            {
                Id = 25,
                PerformanceTime = new DateTime(2025, 11, 1, 19, 30, 0),
                TicketPrice = 1195,
                TicketsAvailable = 40000,
                ConcertId = 8,
                VenueId = 5
            };

            builder.Entity<Performance>().HasData(performance1, performance2, performance3, performance4, performance5, performance6, performance7, performance8, performance9, performance10, performance11, performance12, performance13, performance14, performance15, performance16, performance17, performance18, performance19, performance20, performance21, performance22, performance23, performance24, performance25);
        

        }

    }
}
