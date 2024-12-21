using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System.Collections.ObjectModel;

namespace GigGuide.MAUI.ViewModels
{
    [ObservableObject]
    [QueryProperty("Concert", nameof(Concert))]
    public partial class ConcertPerformanceListViewModel
    {
        private IPerformanceService _performanceService;

        [ObservableProperty]
        private Concert concert = null!;

        [ObservableProperty]
        private ObservableCollection<Performance> performances = new ObservableCollection<Performance>();

        [ObservableProperty]
        private Performance? selectedPerformance;

        public ConcertPerformanceListViewModel(IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            Performances = new(await _performanceService.GetPerformancesByConcertAsync(Concert.ConcertId) ?? []);
        }

        [RelayCommand]
        public async Task NavigateToBooking()
        {
            if (SelectedPerformance == null) return;
            SelectedPerformance.PerformanceConcert = Concert;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Performance), SelectedPerformance }
            };
            await Shell.Current.GoToAsync("BookingPage", navigationParameter);
        }
    }
}
