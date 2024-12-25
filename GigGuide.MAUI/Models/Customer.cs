namespace GigGuide.MAUI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; } 
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
    }
}
