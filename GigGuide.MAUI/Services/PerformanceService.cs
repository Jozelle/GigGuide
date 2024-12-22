using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;

namespace GigGuide.MAUI.Services
{
    public class PerformanceService : IPerformanceService
    {
        IRestService _restService;
        public PerformanceService(IRestService restService)
        {
            _restService = restService;
        }
        public Task<List<Performance>?> GetPerformancesByConcertAsync(int? id)
        {
            return _restService.RefreshPerformanceDataAsync(id);
        }
    }
}
