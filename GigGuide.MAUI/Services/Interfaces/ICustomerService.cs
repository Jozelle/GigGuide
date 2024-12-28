using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerAsync(int id);
        Customer? GetCurrentCustomer();
        Task<Customer?> LoginAsync(string email, string password); 
        bool IsLoggedIn();

    }
}
