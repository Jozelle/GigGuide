using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GigGuide.MAUI.Models;
using GigGuide.MAUI.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace GigGuide.MAUI.ViewModels
{
    [ObservableObject]
    public partial class CustomerViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;

        [ObservableProperty]
        private Customer currentCustomer;

        [ObservableProperty]
        private Booking selectedBooking;

        [ObservableProperty]
        private string welcomeMessage = "Welcome to your account!"; // Default welcome message

        [ObservableProperty]
        private ObservableCollection<Booking> myBookings = new ObservableCollection<Booking>();

        [ObservableProperty]
        private bool isEmailEditVisible;

        [ObservableProperty]
        private bool isPhoneEditVisible;

        [ObservableProperty]
        private bool isPasswordEditVisible;

        [ObservableProperty]
        private string newEmail;

        [ObservableProperty]
        private string newPhone;

        [ObservableProperty]
        private string newPassword;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private string emailError;

        [ObservableProperty]
        private string phoneError;

        [ObservableProperty]
        private string passwordError;

        [ObservableProperty]
        private bool isEmailErrorVisible;

        [ObservableProperty]
        private bool isPhoneErrorVisible;

        [ObservableProperty]
        private bool isPasswordErrorVisible;

        public ICommand ChangePasswordCommand { get; }
        public ICommand UpdateEmailCommand { get; }
        public ICommand UpdatePhoneCommand { get; }

        public ICommand ShowEmailEditCommand => new RelayCommand(() =>
        {
            IsEmailEditVisible = true; // Show the email edit section
        });

        public ICommand ShowPhoneEditCommand => new RelayCommand(() =>
        {
            IsPhoneEditVisible = true; // Show the email edit section
        });

        public ICommand ShowPasswordEditCommand => new RelayCommand(() =>
        {
            IsPasswordEditVisible = true; // Show the password edit section
        });

        public CustomerViewModel(ICustomerService customerService, IBookingService bookingService)
        {
            _customerService = customerService;
            _bookingService = bookingService;

            ChangePasswordCommand = new RelayCommand(OnChangePassword);
            UpdateEmailCommand = new RelayCommand(OnUpdateEmail);
            UpdatePhoneCommand = new RelayCommand(OnUpdatePhone);
            IsEmailEditVisible = false; // Initially hidden
            IsPhoneEditVisible = false; // Initially hidden
            IsPasswordEditVisible = false; // Initially hidden
            IsEmailErrorVisible = false; // Initially hidden
            IsPhoneErrorVisible = false; // Initially hidden
            IsPasswordErrorVisible = false; // Initially hidden
        }

        private void OnUpdateEmail()
        {
            if (string.IsNullOrWhiteSpace(NewEmail) || !IsValidEmail(NewEmail))
            {
                EmailError = "Please enter a valid email.";
                IsEmailErrorVisible = true;
            }
            else
            {
                // Add logic to update the email in the database or service
                IsEmailEditVisible = false; // Hide after update
                IsEmailErrorVisible = false; // Reset error visibility
            }
        }

        private void OnUpdatePhone()
        {
            if (string.IsNullOrWhiteSpace(NewPhone) || !IsValidPhone(NewPhone))
            {
                PhoneError = "Please enter a valid phone number.";
                IsPhoneErrorVisible = true;
            }
            else
            {
                // Add logic to update the email in the database or service
                IsPhoneEditVisible = false; // Hide after update
                IsPhoneErrorVisible = false; // Reset error visibility
            }
        }

        private void OnChangePassword()
        {
            if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword != ConfirmPassword)
            {
                PasswordError = "Passwords do not match.";
                IsPasswordErrorVisible = true;
            }
            else
            {
                // Add logic to change the password in the database or service
                IsPasswordEditVisible = false; // Hide after change
                IsPasswordErrorVisible = false; // Reset error visibility
            }
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhone(string phone)
        {
            var phonePattern = @"^(([+]467)|00467|07)[02369]*(\d{7})$";
            return Regex.IsMatch(phone, phonePattern);
        }

        public ICommand CancelEmailEditCommand => new RelayCommand(() =>
        {
            IsEmailEditVisible = false;
        });

        public ICommand CancelPhoneEditCommand => new RelayCommand(() =>
        {
            IsPhoneEditVisible = false;
        });

        public ICommand CancelPasswordEditCommand => new RelayCommand(() =>
        {
            IsPasswordEditVisible = false;
        });

        [RelayCommand]
        public async Task Appearing()
        {
            CurrentCustomer = _customerService.GetCurrentCustomer();

            if (CurrentCustomer != null)
            {
                MyBookings = new(await _bookingService.GetBookingsByCustomerAsync(CurrentCustomer.CustomerId) ?? []);
            }

            WelcomeMessage = $"Welcome {CurrentCustomer.CustomerFirstName}!";
        }

        [RelayCommand]
        public async Task NavigateToBooking()
        {
            if (SelectedBooking == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Performance), SelectedBooking.Performance }
            };
            await Shell.Current.GoToAsync("BookingPage", navigationParameter);
        }
    }
}