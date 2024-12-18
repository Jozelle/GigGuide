using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services
{
    public interface IPerformanceService
    {
        Task<List<Performance>?> GetPerformancesByConcertAsync(int? id);
    }
}
