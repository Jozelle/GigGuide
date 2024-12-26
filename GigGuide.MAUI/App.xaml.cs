using GigGuide.MAUI.Views;

namespace GigGuide.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            GoToLoginPageIfNotLoggedIn();
        }

        private async void GoToLoginPageIfNotLoggedIn()
        {
            if (AppShell.CurrentCustomer == null) 
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
        }
    }
}
