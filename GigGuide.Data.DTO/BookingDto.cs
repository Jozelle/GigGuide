using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.DTO
{
    public class BookingDto
    {
        public int? Id { get; set; } = null!;
        public int? Quantity { get; set; } = null!;
        public int? PerformanceId { get; set; } = null!;
        public int? CustomerId { get; set; } = null!;
    }
}
