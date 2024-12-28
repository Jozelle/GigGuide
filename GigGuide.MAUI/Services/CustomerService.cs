using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;

namespace GigGuide.MAUI.Services
{
    public class CustomerService : ICustomerService
    {
        IRestService _restService;
        public CustomerService(IRestService restService)
        {
            _restService = restService;

           
        }

        public async Task<Customer?> GetCustomerAsync(int id)
        {
            return await _restService.GetCustomer(id);
        }

        public async Task<Customer?> LoginAsync(string email, string password)
        {
            return await _restService.AuthenticateCustomerAsync2(email, password);
        }
       


    }
}
