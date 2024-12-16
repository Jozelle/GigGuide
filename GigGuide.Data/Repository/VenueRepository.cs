using GigGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.Repository
{
    public class VenueRepository : Repository<Venue>, IVenueRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
        public VenueRepository(ApplicationDbContext context)
        : base(context)
        { }
        public async Task<bool> DoesItemExist(string id)
        {
            return await DbContext.Venues.FindAsync(id) != null;
        }
        public async Task<Venue?> Find(string id)
        {
            return await DbContext.Venues.FindAsync(id);
            //return await DbContext.Venues.FirstOrDefaultAsync(item => item.ID == id);
        }
        public void Update(Venue venue)
        {
            //Venue? existingItem = DbContext.Venues.Find(venue.Id);
            //if (existingItem is not null)
            //    DbContext.Venues.Remove(existingItem);
            //DbContext.Venues.Add(venue);
            Venue? existingVenue = DbContext.Venues.Find(venue.Id);
            if (existingVenue is not null)
            {
                existingVenue.Name = venue.Name;
                existingVenue.Address = venue.Address;
                existingVenue.City = venue.City;
                existingVenue.Country = venue.Country;

                DbContext.Venues.Update(existingVenue);
            }
        }
        public void Delete(string id)
        {
            Venue? venue = DbContext.Venues.Find(id);
            if (venue is not null)
                DbContext.Venues.Remove(venue);
        }
    }
}
