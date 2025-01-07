using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            //Shell.SetNavBarIsVisible(this, false); // Hides the back arrow
            //Shell.SetTabBarIsVisible(this, false); // Hides the bottom navigation bar
        }
    }
}
