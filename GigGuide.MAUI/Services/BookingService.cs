using GigGuide.MAUI.Models;
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
            throw new NotImplementedException();
        }

        public Task<List<Booking>?> GetBookingsByPerformanceAsync(int performanceId)
        {
            throw new NotImplementedException();
        }
    }
}
