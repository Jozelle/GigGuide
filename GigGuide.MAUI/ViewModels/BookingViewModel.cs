using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System.Collections.ObjectModel;

namespace GigGuide.MAUI.ViewModels
{
    [ObservableObject]
    [QueryProperty("Performance", nameof(Performance))]
    public partial class BookingViewModel
    {
        private IBookingService _bookingService;

        private Performance performance;

        [ObservableProperty]
        private int quantity = 1;

        public BookingViewModel(IBookingService bookingService)
        {
            _bookingService = bookingService;

        }

        [RelayCommand]
        public async Task Appearing()
        {
            //Vet inte om vi behöver något här? 
        }
    }
}
