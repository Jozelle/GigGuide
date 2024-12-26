namespace GigGuide.MAUI.Models
{
    public class Performance
    {
        public int PerformanceId { get; set; }
        public DateTime? PerformanceTime { get; set; } = null!;
        public int PerformanceTicketPrice { get; set; }
        public int PerformanceTotalTickets { get; set; }
        public int PerformanceTicketsBooked { get; set; }
        public int PerformanceConcertId { get; set; }
        public Concert? PerformanceConcert { get; set; } = null!;
        public int PerformanceVenueId { get; set; }
        public Venue? PerformanceVenue { get; set; } = null!;

        public string PerformanceLocation => $"{PerformanceVenue?.VenueName}, {PerformanceVenue?.VenueCity}, {PerformanceVenue?.VenueCountry}";

        public int PerformanceTicketsAvailable => PerformanceTotalTickets - PerformanceTicketsBooked;
    }
}
