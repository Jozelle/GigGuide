using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System.Collections.ObjectModel;


namespace GigGuide.MAUI.ViewModels
{
    [QueryProperty("Performance", nameof(Performance))]
    public partial class BookingViewModel : ObservableObject
    {
        private IBookingService _bookingService;
        private ICustomerService _customerService;

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
            // Hämta bokning för performance och "current customer"
            if (_customerService.loggedInCustomer != null)
            {
                Booking = await _bookingService.GetBookingByPerformanceAndCustomerAsync(Performance.PerformanceId, (int)_customerService.loggedInCustomer.CustomerId);
                if (Booking == null)
                {
                    Booking = new Booking
                    {
                        BookingId = default,
                        BookingQuantity = 0,
                        BookingCustomerId = (int)_customerService.loggedInCustomer.CustomerId,
                        BookingPerformanceId = Performance.PerformanceId
                    };
                }

                Quantity = Booking.BookingQuantity;
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
            if (_customerService.loggedInCustomer != null)
            {
                // Create or update the booking object with the current details
                Booking.BookingQuantity = (int)Quantity; // Update the quantity
                Booking.BookingCustomerId = (int)_customerService.loggedInCustomer.CustomerId; // Ensure customer ID is set
                Booking.BookingPerformanceId = Performance.PerformanceId; // Set performance ID

                bool isNewItem = Booking.BookingId == default; // Adjust based on how you identify new vs existing

                // Save the booking using the booking service
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