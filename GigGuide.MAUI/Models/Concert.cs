using GigGuide.Data.Entities;

namespace GigGuide.MAUI.Models
{
    public class Concert
    {
        public int? ConcertId { get; set; } = null!;
        public string ConcertArtist { get; set; } = null!;
        public string ConcertTitle { get; set; } = null!;
        public string ConcertDescription { get; set; } = null!;
        //public ICollection<Performance> ConcertPerformances { get; set; } = null!;
    }
}
