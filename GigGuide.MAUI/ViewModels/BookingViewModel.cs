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
        private int quantity = 0;

        [ObservableProperty]
        private Booking? booking;

        [ObservableProperty]
        private string? bookingStatus;

        public BookingViewModel(IBookingService bookingService, ICustomerService customerService)
        {
            _bookingService = bookingService;
            _customerService = customerService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            //Hämta ev inloggad kund
            customer = _customerService.GetCurrentCustomer();

            // Hämta bokning för performance och "current customer"
            if (customer != null)
            {
                Booking = await _bookingService.GetBookingByPerformanceAndCustomerAsync(Performance.PerformanceId, customer.CustomerId);
                if (Booking != null)
                {
                    BookingStatus = "You have currently booked " + Booking.BookingQuantity + " tickets for this performance.";
                }
                else
                {
                    BookingStatus = "You have not yet booked any tickets for this performance.";
                    Booking = new Booking { 
                        BookingId = 0, 
                        BookingCustomerId = customer.CustomerId, 
                        BookingPerformanceId = Performance.PerformanceId, 
                        BookingQuantity = 0 };
                }

                Quantity = Booking.BookingQuantity;
            }
            else
            {
                BookingStatus = "Please log in to book tickets.";
            }
        }

        [RelayCommand]
        public async Task StepperValueChanged()
        {
            if (Quantity < 1)
            {
                //Delete booking
                if (Booking.BookingId != 0)
                {
                    await _bookingService.DeleteBookingAsync(Booking.BookingId);
                    BookingStatus = "Your booking has been deleted.";
                    Booking = new Booking
                    {
                        BookingId = 0,
                        BookingCustomerId = customer.CustomerId,
                        BookingPerformanceId = Performance.PerformanceId,
                        BookingQuantity = 0
                    };
                }
            }
            else
            {
                //Update booking
                if (Booking.BookingId != 0)
                {
                    Booking.BookingQuantity = Quantity;
                    Booking = await _bookingService.SaveBookingAsync(Booking, false);
                }
                else
                {
                    //Create booking
                    Booking.BookingQuantity = Quantity;
                    Booking = await _bookingService.SaveBookingAsync(Booking, true);
                }

                BookingStatus = "You have currently booked " + Booking.BookingQuantity + " tickets for this performance.";
            }
        }

        [RelayCommand]
        public async Task SaveBooking()
        {
            if (customer != null)
            {
                //Booking.BookingQuantity = Quantity;
                //Booking.BookingCustomerId = customer.CustomerId;
                //Booking.BookingPerformanceId = Performance.PerformanceId;

                //bool isNewItem = Booking.BookingId == default;

                //await _bookingService.SaveBookingAsync(Booking, isNewItem);

                // Optionally, navigate away or show a confirmation message
            }
            else
            {
                // Prompt the user to log in if no customer is logged in
            }
        }
    }
}