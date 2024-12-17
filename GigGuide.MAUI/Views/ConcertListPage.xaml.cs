using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views;

public partial class ConcertListPage : ContentPage
{
	public ConcertListPage(ConcertListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}