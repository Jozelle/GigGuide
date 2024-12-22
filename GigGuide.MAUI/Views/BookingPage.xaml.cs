
using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views;

public partial class BookingPage : ContentPage
{

	public BookingPage(BookingViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

}