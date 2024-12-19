using GigGuide.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.MAUI.Services
{
    public interface IBookingService
    {
        Task<List<Booking>?> GetBookingsAsync();
        Task<List<Booking>?> GetBookingsByCustomerAsync(int customerId);
        Task<List<Booking>?> GetBookingsByPerformanceAsync(int performanceId);
        Task<Booking?> GetBookingAsync(int bookingId);
    }
}
