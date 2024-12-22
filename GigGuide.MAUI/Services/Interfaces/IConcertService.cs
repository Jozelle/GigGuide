using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Services.Interfaces
{
    public interface IConcertService
    {
        Task<List<Concert>?> GetConcertsAsync();
    }
}
