using System.ComponentModel.DataAnnotations;

namespace GigGuide.Data.Entities
{
    public class Venue
    {
        [Key]
        public required int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public required string Address { get; set; }

        [MaxLength(30)]
        public required string City { get; set; }
    }
}
