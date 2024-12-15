using System.ComponentModel.DataAnnotations;

namespace GigGuide.Data.Entities
{
    public class Booking
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        public required int Quantity { get; set; }

        public int PerformanceId { get; set; }
        public Performance? Performance { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
