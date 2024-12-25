using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerAsync(int id);
    }
}
