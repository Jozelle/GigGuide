using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;

namespace GigGuide.MAUI.Services
{
    public class CustomerService : ICustomerService
    {
        IRestService _restService;

        public Customer? loggedInCustomer { get; set; }
        public CustomerService(IRestService restService)
        {
            _restService = restService;

            //kOD FÖR ATT HÄMTA KUND 1 OCH SÄTTA  TILL LOGGEDINCUSTOMER
        }

        //public async Task<List<Customer>?> GetCustomersAsync()
        //{
        //    return await _restService.RefreshCustomerDataAsync();
        //}
    }
}
