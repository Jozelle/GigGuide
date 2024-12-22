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
            if (_customerService.loggedInCustomer != null )
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
