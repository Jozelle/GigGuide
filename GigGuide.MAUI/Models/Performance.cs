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

        public Color AvailabilityColor
        {
            get
            {
                if (PerformanceTicketsAvailable <= 0)
                    return Colors.Red;
                if (PerformanceTicketsAvailable < 100)
                    return Colors.Orange;
                return Colors.Green;
            }
        }

        public string AvailabilityText
        {
            get
            {
                if (PerformanceTicketsAvailable <= 0)
                    return "The tickets for this performance is sold out!";
                if (PerformanceTicketsAvailable < 100)
                    return $"There is only {PerformanceTicketsAvailable} tickets left so hurry before they are sold out!";
                return "There is more than 100 tickets left.";
            }
        }
    }
}
