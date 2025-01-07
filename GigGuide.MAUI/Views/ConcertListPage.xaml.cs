using GigGuide.MAUI.ViewModels;
using System.Diagnostics;

namespace GigGuide.MAUI.Views;

public partial class ConcertListPage : ContentPage
{
    
    public ConcertListPage(ConcertListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsEnabled = false });
    }

}
