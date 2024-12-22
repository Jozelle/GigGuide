using GigGuide.MAUI.ViewModels;

namespace GigGuide.MAUI.Views;

public partial class CustomerPage : ContentPage
{
    public CustomerPage()
    {
        InitializeComponent();
        // Optionally, set a default BindingContext or handle initialization
    }

    public CustomerPage(CustomerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
