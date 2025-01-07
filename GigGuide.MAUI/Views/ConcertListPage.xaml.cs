using GigGuide.MAUI.ViewModels;
using System.Diagnostics;

namespace GigGuide.MAUI.Views;

public partial class ConcertListPage : ContentPage
{
    
    public ConcertListPage(ConcertListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        //Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsEnabled = false });
        Shell.SetNavBarIsVisible(this, false); // Hides the back arrow
    }

    //private  void OnSwiped(object sender, SwipedEventArgs e)
    //{
    //    Debug.WriteLine($"Swipe detected: {e.Direction}");
    //    if (e.Direction == SwipeDirection.Left)
    //    {
    //         DisplayAlert("Swipe Detected", "Back navigation is disabled.", "OK");
    //    }
    //}
}
