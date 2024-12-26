using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GigGuide.MAUI.Services.Interfaces;
using GigGuide.MAUI.Views;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace GigGuide.MAUI.ViewModels
{
    
    public partial class LoginViewModel : ObservableValidator
    {
        private readonly ICustomerService _customerService;

        [ObservableProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        private string email;

        [ObservableProperty]
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        public LoginViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            // Validate properties
            ValidateAllProperties();
            if (HasErrors)
            {
                ErrorMessage = "Please fix the errors and try again.";
                return;
            }

         
                var customer = await _customerService.LoginAsync(Email, Password);
                if (customer != null)
                {
                    // Login successful
                    AppShell.CurrentCustomer = customer;
                    await Shell.Current.GoToAsync($"//{nameof(ConcertListPage)}");
                }
                else
                {
                    ErrorMessage = "Invalid email or password.";
                }
        }





    }
}
