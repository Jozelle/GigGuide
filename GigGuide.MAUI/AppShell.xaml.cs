using GigGuide.MAUI.Models;
using GigGuide.MAUI.Views;

namespace GigGuide.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ConcertListPage), typeof(ConcertListPage));
            Routing.RegisterRoute(nameof(ConcertPerformanceListPage), typeof(ConcertPerformanceListPage));
            Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
            Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));

            
        }

    }
}
