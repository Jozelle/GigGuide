using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IVenueRepository : IRepository<Venue>
    {
        Task<bool> DoesItemExist(int id);
        Task<Venue?> Find(int id);
        void Update(Venue venue);
        void Delete(int id);
    }
}

