using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IConcertRepository Concerts { get; }
        IVenueRepository Venues { get; }
        IPerformanceRepository Performances { get; }
        IBookingRepository Bookings { get; }

        Task<int> Complete();
    }
}
