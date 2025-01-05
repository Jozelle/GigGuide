using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System.Collections.ObjectModel;

namespace GigGuide.MAUI.ViewModels
{
    [ObservableObject]
    public partial class CustomerViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;

        [ObservableProperty]
        private Customer currentCustomer;

        [ObservableProperty]
        private Booking selectedBooking;

        [ObservableProperty]
        private string welcomeMessage = "Welcome to your account!"; // Default welcome message

        [ObservableProperty]
        private ObservableCollection<Booking> myBookings = new ObservableCollection<Booking>();

        //public ICommand ChangePasswordCommand { get; }
        //public ICommand UpdateEmailCommand { get; }

        public CustomerViewModel(ICustomerService customerService, IBookingService bookingService)
        {
            _customerService = customerService;
            _bookingService = bookingService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            CurrentCustomer = _customerService.GetCurrentCustomer();

            if (CurrentCustomer != null)
            {
                MyBookings = new(await _bookingService.GetBookingsByCustomerAsync(CurrentCustomer.CustomerId) ?? []);
            }

            WelcomeMessage = $"Welcome {CurrentCustomer.CustomerFirstName}!";
        }

        [RelayCommand]
        public async Task NavigateToBooking()
        {
            if (SelectedBooking == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Performance), SelectedBooking.Performance }
            };
            await Shell.Current.GoToAsync("BookingPage", navigationParameter);
        }
    }
}
