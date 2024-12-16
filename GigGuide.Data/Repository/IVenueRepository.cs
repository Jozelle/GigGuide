using GigGuide.Data.Entities;

namespace GigGuide.Data.Repository
{
    public interface IVenueRepository : IRepository<Venue>
    {
        Task<bool> DoesItemExist(string id);
        Task<Venue?> Find(string id);
        void Update(Venue venue);
        void Delete(string id);
    }
}

