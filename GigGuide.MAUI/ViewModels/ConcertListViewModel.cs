using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services;
using System.Collections.ObjectModel;

namespace GigGuide.MAUI.ViewModels
{
    [ObservableObject]
    public partial class ConcertListViewModel
    {
        private readonly IConcertService _concertService;

        [ObservableProperty]
        private ObservableCollection<Concert> concerts = new ObservableCollection<Concert>();

        [ObservableProperty]
        private Concert? selectedConcert;

        public ConcertListViewModel(IConcertService concertService)
        {
            _concertService = concertService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            Concerts = new(await _concertService.GetConcertsAsync() ?? []);
        }

        //[RelayCommand]
        //public async Task NavigateToConcert(Concert concert)
        //{
        //    if (concert != null)
        //    {
        //        try
        //        {
        //            await Shell.Current.GoToAsync($"concertperformance?Concert={concert.ConcertId}");
        //        }
        //        catch (Exception ex)
        //        {
        //            await Shell.Current.DisplayAlert("Error", "Failed to navigate to concert", "OK");
        //        }
        //    }    
        //}

        [RelayCommand]
        public async Task NavigateToConcert()
        {
            if (SelectedConcert == null) return;
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Concert), SelectedConcert }
            };
            await Shell.Current.GoToAsync("ConcertPerformanceListPage", navigationParameter);
        }
    }
}
