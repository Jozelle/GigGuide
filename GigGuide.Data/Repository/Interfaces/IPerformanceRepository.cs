using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IPerformanceRepository : IRepository<Performance>
    {
        Task<bool> DoesItemExist(string id);
        Task<Performance?> Find(string id);
        void Update(Performance performance);
        void Delete(string id);
    }
}

