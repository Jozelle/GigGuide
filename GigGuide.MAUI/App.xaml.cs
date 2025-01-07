using GigGuide.MAUI.Views;

namespace GigGuide.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

    }
}
