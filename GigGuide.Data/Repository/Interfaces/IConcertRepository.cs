using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IConcertRepository : IRepository<Concert>
    {
        Task<bool> DoesItemExist(int id);
        Task<Concert?> Find(int id);
        void Update(Concert concert);
        void Delete(int id);
    }
}

