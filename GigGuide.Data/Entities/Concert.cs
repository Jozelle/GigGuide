using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigGuide.Data.Entities
{
    public class Concert
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Description { get; set; }

        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required int Capacity { get; set; }

        public ICollection<Performance> Performances { get; set; } = [];
    }
}
