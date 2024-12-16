using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;
using GigGuide.Data.Repository.Interfaces;

namespace GigGuide.Data.Repository
{
    public class ConcertRepository : Repository<Concert>, IConcertRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
        public ConcertRepository(ApplicationDbContext context)
        : base(context)
        { }
        public async Task<bool> DoesItemExist(int id)
        {
            return await DbContext.Concerts.FindAsync(id) != null;
        }
        public async Task<Concert?> Find(int id)
        {
            return await DbContext.Concerts.FindAsync(id);
            //return await DbContext.Concerts.FirstOrDefaultAsync(item => item.ID == id);
        }
        public void Update(Concert concert)
        {

            Concert? existingConcert = DbContext.Concerts.Find(concert.Id);
            if (existingConcert is not null)
            {
                existingConcert.Artist = concert.Artist;
                existingConcert.Title = concert.Title;
                existingConcert.Description = concert.Description;
                existingConcert.Performances = concert.Performances;

                DbContext.Concerts.Update(existingConcert);
            }
        }
        public void Delete(int id)
        {
            Concert? concert = DbContext.Concerts.Find(id);
            if (concert is not null)
                DbContext.Concerts.Remove(concert);
        }
    }
}
