using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;

namespace GigGuide.Data.Repository.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> DoesItemExist(int id);
        Task<Customer?> Find(int id);
        void Update(Customer customer);
        void Delete(int id);
        Task<Customer?> GetCustomerByCredentialsAsync(string email, string password);
        Task<Customer?> FirstOrDefaultAsync(Func<object, bool> value);
    }
}

