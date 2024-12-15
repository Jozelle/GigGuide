using System.ComponentModel.DataAnnotations;

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
        public required int TicketsAvailable { get; set; }

        public int ConcertId { get; set; }
        public Concert? Concert { get; set; }

        public int VenueId { get; set; }
        public Venue? Venue { get; set; }
    }
}
