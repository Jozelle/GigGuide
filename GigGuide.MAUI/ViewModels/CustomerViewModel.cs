using CommunityToolkit.Mvvm.ComponentModel;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        [ObservableProperty]
        private string welcomeMessage = "Welcome to your account!"; // Default welcome message

        [ObservableProperty]
        private ObservableCollection<Booking> myBookings = new ObservableCollection<Booking>();

        public ICommand ChangePasswordCommand { get; }
        public ICommand UpdateEmailCommand { get; }

        CustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    }
}
