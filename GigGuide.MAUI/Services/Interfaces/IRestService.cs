using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services.Interfaces
{
    public interface IRestService
    {
        Task<List<Concert>?> RefreshConcertDataAsync();
        Task<List<Performance>?> RefreshPerformanceDataAsync(int? id);
        Task<Customer?> GetCustomer(int customerId);
        Task<Booking?> GetBookingByPerformanceAndCustomerAsync(int performanceId, int customerId);
        Task<List<Booking>?> GetBookingsByCustomerAsync(int customerId);
        Task<Booking> SaveBookingAsync(Booking item, bool isNewItem);
        Task DeleteBookingAsync(int id);
        Task<Customer?> AuthenticateCustomerAsync(string email, string password);
        Task<Customer?> AuthenticateCustomerAsync2(string email, string password);
    }
}
