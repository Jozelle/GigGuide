using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services.Interfaces
{
    public interface IPerformanceService
    {
        Task<List<Performance>?> GetPerformancesByConcertAsync(int? id);
    }
}
