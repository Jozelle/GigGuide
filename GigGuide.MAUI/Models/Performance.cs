namespace GigGuide.MAUI.Models
{
    public class Performance
    {
        public int? PerformanceId { get; set; } = null!;
        public DateTime? PerformanceTime { get; set; } = null!;
        public int? PerformanceTicketPrice { get; set; } = null!;
        public int? PerformanceTicketsAvailable { get; set; } = null!;
        public int? PerformanceConcertId { get; set; } = null!;
        public int? PerformanceVenueId { get; set; } = null!;
    }
}
