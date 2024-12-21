using CommunityToolkit.Mvvm.ComponentModel;
using GigGuide.MAUI.Services.Interfaces;

namespace GigGuide.MAUI.ViewModels
{
    [ObservableObject]
    public partial class CustomerViewModel
    {
        private readonly ICustomerService _customerService;

        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string phone = string.Empty;

        CustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    }
}
