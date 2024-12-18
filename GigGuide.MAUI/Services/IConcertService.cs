using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services
{
    public interface IConcertService
    {
        Task<List<Concert>?> GetConcertsAsync();
    }
}
