using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;

namespace GigGuide.MAUI.Services
{
    public class ConcertService : IConcertService
    {
        IRestService _restService;

        public ConcertService(IRestService restService)
        {
            _restService = restService;
        }

        public Task<List<Concert>?> GetConcertsAsync()
        {
            return _restService.RefreshConcertDataAsync();
        }
    }
}
