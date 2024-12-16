using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;
using GigGuide.Data.Repository.Interfaces;

namespace GigGuide.Data.Repository
{
    public class PerformanceRepository : Repository<Performance>, IPerformanceRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
        public PerformanceRepository(ApplicationDbContext context)
        : base(context)
        { }
        public async Task<bool> DoesItemExist(string id)
        {
            return await DbContext.Performances.FindAsync(id) != null;
        }
        public async Task<Performance?> Find(string id)
        {
            return await DbContext.Performances.FindAsync(id);
            //return await DbContext.Performances.FirstOrDefaultAsync(item => item.ID == id);
        }
        public void Update(Performance performance)
        {
            Performance? existingPerformance = DbContext.Performances.Find(performance.Id);
            if (existingPerformance is not null)
            {
                existingPerformance.PerformanceTime = performance.PerformanceTime;
                existingPerformance.TicketPrice = performance.TicketPrice;
                existingPerformance.TicketsAvailable = performance.TicketsAvailable;
                existingPerformance.ConcertId = performance.ConcertId;
                existingPerformance.VenueId = performance.VenueId;

                DbContext.Performances.Update(existingPerformance);
            }
        }
        public void Delete(string id)
        {
            Customer? customer = DbContext.Customers.Find(id);
            if (customer is not null)
                DbContext.Customers.Remove(customer);
        }
    }
}
