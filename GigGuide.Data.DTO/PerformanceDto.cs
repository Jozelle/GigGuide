using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.DTO
{
    public class PerformanceDto
    {
        public int? Id { get; set; } = null!;
        public DateTime? PerformanceTime { get; set; } = null!;
        public int? TicketPrice { get; set; } = null!;
        public int? TicketsAvailable { get; set; } = null!;
        public int? ConcertId { get; set; } = null!;
        public int? VenueId { get; set; } = null!;
    }
}
