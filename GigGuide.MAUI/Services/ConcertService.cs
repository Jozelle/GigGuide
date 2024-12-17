using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services
{
    public class ConcertService : IConcertService
    {
        IRestService _restService;

        public ConcertService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<List<Concert>?> GetConcertsAsync()
        {
            return await _restService.RefreshConcertDataAsync();
        }
    }
}
