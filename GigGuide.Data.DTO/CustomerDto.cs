using GigGuide.Data.Entities;

namespace GigGuide.Data.DTO
{
    public class CustomerDto
    {
        public int? Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        //public ICollection<Booking> Bookings { get; set; } = null!;
    }
}
