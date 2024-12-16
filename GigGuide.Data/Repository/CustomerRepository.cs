using GigGuide.Data.Entities;
using GigGuide.Data.Repository.Base;
using GigGuide.Data.Repository.Interfaces;

namespace GigGuide.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
        public CustomerRepository(ApplicationDbContext context)
        : base(context)
        { }
        public async Task<bool> DoesItemExist(string id)
        {
            return await DbContext.Customers.FindAsync(id) != null;
        }
        public async Task<Customer?> Find(string id)
        {
            return await DbContext.Customers.FindAsync(id);
            //return await DbContext.Customers.FirstOrDefaultAsync(item => item.ID == id);
        }
        public void Update(Customer customer)
        {
            Customer? existingCustomer = DbContext.Customers.Find(customer.Id);
            if (existingCustomer is not null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Password = customer.Password;

                DbContext.Customers.Update(existingCustomer);
            }
        }
        public void Delete(string id)
        {
            Customer? customer = DbContext.Customers.Find(id);
            if (customer is not null)
                DbContext.Customers.Remove(customer);
        }
    }
}
