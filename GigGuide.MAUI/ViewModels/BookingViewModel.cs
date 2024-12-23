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
        private ICustomerService _customerService;

        private Customer? customer;

        [ObservableProperty]
        private Performance performance;

        [ObservableProperty]
        private int? quantity = 0;

        [ObservableProperty]
        private Booking? booking;

        public BookingViewModel(IBookingService bookingService, ICustomerService customerService)
        {
            _bookingService = bookingService;
            _customerService = customerService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            //Hämta ev inloggad kund
            customer = await _customerService.GetCustomerAsync(1);
            
            // Hämta bokning för performance och "current customer"
            if (customer != null)
            {
                Booking = await _bookingService.GetBookingByPerformanceAndCustomerAsync(Performance.PerformanceId, customer.CustomerId);
                if (Booking != null)
                {
                    Quantity = Booking.BookingQuantity;
                }
            }
            else
            {
                //Be användaren att logga in
            }
        }

        [RelayCommand]
        public async Task StepperValueChanged()
        {
            if (Quantity < 1)
            {
                //Delete booking
            }
            else
            {
                //Update booking
            }
        }

        [RelayCommand]
        public async Task SaveBooking()
        {
            if (customer != null)
            {
                Booking.BookingQuantity = Quantity;
                Booking.BookingCustomerId = customer.CustomerId;
                Booking.BookingPerformanceId = Performance.PerformanceId;

                bool isNewItem = Booking.BookingId == default;

                await _bookingService.SaveBookingAsync(Booking, isNewItem);

                // Optionally, navigate away or show a confirmation message
            }
            else
            {
                // Prompt the user to log in if no customer is logged in
            }
        }
    }
}