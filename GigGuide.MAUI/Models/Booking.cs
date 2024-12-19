using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.MAUI.Models
{
    public class Booking
    {
        public int? BookingId { get; set; } = null!;
        public int? BookingQuantity { get; set; } = null!;
        public int? BookingPerformanceId { get; set; } = null!;
        public int? BookingCustomerId { get; set; } = null!;
    }
}
