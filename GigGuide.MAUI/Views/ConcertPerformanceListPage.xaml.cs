using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views;

public partial class ConcertPerformanceListPage : ContentPage
{
	public ConcertPerformanceListPage(ConcertPerformanceListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}