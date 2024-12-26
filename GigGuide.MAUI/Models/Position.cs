using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.MAUI.Models
{
    public class Position
    {
        public string Address { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Location Location { get; set; } = null!;
    }
}
