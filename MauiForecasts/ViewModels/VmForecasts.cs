namespace MauiForecasts.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using SmhiApiServices.Models;
using SmhiApiServices.Services;

public partial class VmForecasts : ObservableObject
{
    private readonly ISmhiForecastServices smhiServices;

    public Forecast Forecast { get; set; }

    public Values Values => Forecast?.Values;

    public IAsyncRelayCommand GetForecastsCommand { get; set; }

    public VmForecasts(ISmhiForecastServices smhiServices)
    {
        this.smhiServices = smhiServices;
    GetForecastsCommand = new AsyncRelayCommand(GetForecasts);
}

public async Task GetForecasts()
    {
        Forecast = await smhiServices.GetForecasts("pmp3g", "2", "point", "17.160666", "60.716082");
        OnPropertyChanged(nameof(Forecast));
        OnPropertyChanged(nameof(Values));
    }
}
