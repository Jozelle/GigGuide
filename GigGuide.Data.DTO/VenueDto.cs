namespace GigGuide.Data.DTO
{
    public class VenueDto
    {
        public int? Id { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public string? City { get; set; } = null!;
        public string? Country { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
