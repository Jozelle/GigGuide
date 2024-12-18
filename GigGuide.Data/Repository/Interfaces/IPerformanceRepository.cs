using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface IPerformanceRepository : IRepository<Performance>
    {
        Task<bool> DoesItemExist(int id);
        Task<Performance?> Find(int id);
        Task<IEnumerable<Performance>> GetPerformancesByConcert(int id);
        void Update(Performance performance);
        void Delete(int id);
    }
}

