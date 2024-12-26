using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigGuide.Data.Entities
{
    public class Performance
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        public required DateTime PerformanceTime { get; set; }

        [Required]
        public required int TicketPrice { get; set; }

        [Required]
        public required int TicketsAvailable { get; set; }      // Total amount of tickets available

        public ICollection<Booking>? Bookings { get; set; }

        [NotMapped]
        public int TicketsBooked => Bookings?.Sum(b => b.Quantity) ?? 0;

        public int ConcertId { get; set; }
        public Concert? Concert { get; set; }

        public int VenueId { get; set; }
        public Venue? Venue { get; set; }
    }
}
