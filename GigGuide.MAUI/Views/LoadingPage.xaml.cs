using GigGuide.MAUI.Services.Interfaces;

namespace GigGuide.MAUI.Views;

public partial class LoadingPage : ContentPage
{

	private readonly ICustomerService _customerService;
    public LoadingPage(ICustomerService customerService)
	{
		InitializeComponent();
        _customerService = customerService;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (_customerService.IsLoggedIn())
        {
            //Customer is logged in
            await Shell.Current.GoToAsync($"//{nameof(ConcertListPage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}