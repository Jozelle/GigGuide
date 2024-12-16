using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IVenueRepository : IRepository<Venue>
    {
        Task<bool> DoesItemExist(string id);
        Task<Venue?> Find(string id);
        void Update(Venue venue);
        void Delete(string id);
    }
}

