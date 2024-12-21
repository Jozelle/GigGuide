using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services.Interfaces
{
    public interface IRestService
    {
        Task<List<Concert>?> RefreshConcertDataAsync();
        Task<List<Performance>?> RefreshPerformanceDataAsync(int? id);
        Task SaveBookingAsync(Booking item, bool isNewItem);
        Task DeleteBookingAsync(string id);
    }
}
