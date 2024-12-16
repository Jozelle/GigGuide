using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<bool> DoesItemExist(int id);
        Task<Booking?> Find(int id);
        void Update(Booking booking);
        void Delete(int id);
    }
}

