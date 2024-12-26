using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(LoginViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }
    }
}
