using CommunityToolkit.Mvvm.ComponentModel;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services;

namespace GigGuide.MAUI.ViewModels
{
    [ObservableObject]
    [QueryProperty("Concert", nameof(Concert))]
    public partial class ConcertPerformanceListViewModel
    {
        private IConcertService _concertService;

        [ObservableProperty]
        private Concert concert = null!;

        public ConcertPerformanceListViewModel(IConcertService concertService)
        {
            _concertService = concertService;
        }
    }
}
