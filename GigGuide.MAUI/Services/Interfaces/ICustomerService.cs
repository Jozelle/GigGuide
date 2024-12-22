using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer? loggedInCustomer { get; set; }
    }
}
