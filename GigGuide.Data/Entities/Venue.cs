using System.ComponentModel.DataAnnotations;

namespace GigGuide.Data.Entities
{
    public class Venue
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Address { get; set; }

        [Required]
        [MaxLength(30)]
        public required string City { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Country { get; set; }
    }
}
