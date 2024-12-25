using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.MAUI.Services
{
    public class BookingService : IBookingService
    {
        IRestService _restService;

        public BookingService(IRestService restService)
        {
            _restService = restService;
        }
        public Task<Booking?> GetBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>?> GetBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>?> GetBookingsByCustomerAsync(int customerId)
        {
            return _restService.GetBookingsByCustomerAsync(customerId);
        }

        public Task<List<Booking>?> GetBookingsByPerformanceAsync(int performanceId)
        {
            throw new NotImplementedException();
        }

        public Task<Booking?> GetBookingByPerformanceAndCustomerAsync(int performanceId, int customerId)
        {
            return _restService.GetBookingByPerformanceAndCustomerAsync(performanceId, customerId);
        }

        public async Task<Booking> SaveBookingAsync(Booking booking, bool isNewItem = false)
        {
            return await _restService.SaveBookingAsync(booking, isNewItem);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _restService.DeleteBookingAsync(id);
        }
    }
}
