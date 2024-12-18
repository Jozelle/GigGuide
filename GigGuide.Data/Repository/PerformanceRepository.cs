using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;
using GigGuide.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GigGuide.Data.Repository
{
    public class PerformanceRepository : Repository<Performance>, IPerformanceRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
        public PerformanceRepository(ApplicationDbContext context)
        : base(context)
        { }
        public async Task<bool> DoesItemExist(int id)
        {
            return await DbContext.Performances.FindAsync(id) != null;
        }
        public async Task<Performance?> Find(int id)
        {
            return await DbContext.Performances.FindAsync(id);
            //return await DbContext.Performances.FirstOrDefaultAsync(item => item.ID == id);
        }
        public async Task<IEnumerable<Performance>> GetPerformancesByConcert(int id)
        {
            return await DbContext.Performances.Where(p => p.ConcertId == id).ToListAsync<Performance>();
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
        public void Delete(int id)
        {
            Customer? customer = DbContext.Customers.Find(id);
            if (customer is not null)
                DbContext.Customers.Remove(customer);
        }
    }
}
