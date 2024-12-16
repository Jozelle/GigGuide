using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> DoesItemExist(string id);
        Task<Customer?> Find(string id);
        void Update(Customer customer);
        void Delete(string id);
    }
}

