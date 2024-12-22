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
            loggedInCustomer = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "Johanna",
                CustomerLastName = "Gull",
                CustomerEmail = "johanna@datababes.se",
                CustomerPhone = "070-6093654",
                
            };
        }

        //public async Task<List<Customer>?> GetCustomersAsync()
        //{
        //    return await _restService.RefreshCustomerDataAsync();
        //}
    }
}
