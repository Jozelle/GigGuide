using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.MAUI.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int BookingQuantity { get; set; }
        public int BookingPerformanceId { get; set; }
        public int BookingCustomerId { get; set; }

        public Customer Customer { get; set; } = null!;
        public Performance Performance { get; set; } = null!;
    }
}
