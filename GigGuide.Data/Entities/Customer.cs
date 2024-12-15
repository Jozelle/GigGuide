using System.ComponentModel.DataAnnotations;

namespace GigGuide.Data.Entities
{
    public class Customer
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Password { get; set; }

        public ICollection<Booking> Bookings { get; set; } = [];
    }
}
