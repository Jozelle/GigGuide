using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views;

public partial class CustomerPage : ContentPage
{
	public CustomerPage(CustomerViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}