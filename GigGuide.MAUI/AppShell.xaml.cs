using GigGuide.MAUI.Views;

namespace GigGuide.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ConcertPerformanceListPage), typeof(ConcertPerformanceListPage));
        }
    }
}
