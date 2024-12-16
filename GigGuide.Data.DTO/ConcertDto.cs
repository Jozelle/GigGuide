using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.DTO
{
    public class ConcertDto
    {
        public int? Id { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<PerformanceDto> Performances { get; set; } = null!;
    }
}
