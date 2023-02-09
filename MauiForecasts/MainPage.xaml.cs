namespace MauiForecasts;

using MauiForecasts.ViewModels;

public partial class MainPage : ContentPage
{
    public MainPage(VmForecasts vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

