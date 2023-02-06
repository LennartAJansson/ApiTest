namespace MauiForecasts;

using MauiForecasts.ViewModels;

public partial class MainPage : ContentPage
{
    public MainPage(VmForecasts vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    //private async void OnCounterClicked(object sender, EventArgs e) => await ((VmForecasts)BindingContext).GetForecasts();
}

