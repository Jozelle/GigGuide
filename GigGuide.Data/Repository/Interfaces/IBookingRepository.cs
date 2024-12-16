using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<bool> DoesItemExist(string id);
        Task<Booking?> Find(string id);
        void Update(Booking booking);
        void Delete(string id);
    }
}

