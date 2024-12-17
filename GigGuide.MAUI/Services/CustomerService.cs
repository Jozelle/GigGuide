namespace GigGuide.MAUI.Services
{
    public class CustomerService : ICustomerService
    {
        IRestService _restService;
        public CustomerService(IRestService restService)
        {
            _restService = restService;
        }
        //public async Task<List<Customer>?> GetCustomersAsync()
        //{
        //    return await _restService.RefreshCustomerDataAsync();
        //}
    }
}
