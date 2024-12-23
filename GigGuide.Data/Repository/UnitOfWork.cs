using GigGuide.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
      
        public ICustomerRepository Customers { get; private set; }
        public IVenueRepository Venues { get; private set; }
        public IConcertRepository Concerts { get; private set; }
        public IPerformanceRepository Performances { get; private set; }
        public IBookingRepository Bookings { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            Venues = new VenueRepository(context);
            Customers = new CustomerRepository(context);
            Concerts = new ConcertRepository(context);
            Performances = new PerformanceRepository(context);
            Bookings = new BookingRepository(context);
        }
        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
