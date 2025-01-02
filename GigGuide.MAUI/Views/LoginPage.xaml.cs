using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false); // Hides the back arrow
            Shell.SetTabBarIsVisible(this, false); // Hides the bottom navigation bar
        }

        public LoginPage(LoginViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }
        protected override bool OnBackButtonPressed()
        {
            // Prevent the back button from being used
            return true;
        }


    }
}
