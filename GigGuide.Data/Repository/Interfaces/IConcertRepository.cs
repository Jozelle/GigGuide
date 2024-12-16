using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IConcertRepository : IRepository<Concert>
    {
        Task<bool> DoesItemExist(string id);
        Task<Concert?> Find(string id);
        void Update(Concert concert);
        void Delete(string id);
    }
}

