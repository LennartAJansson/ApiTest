namespace MauiForecasts.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MauiForecasts.Models;

using SmhiApiServices.Contracts;
using SmhiApiServices.Services;

public partial class MainViewModel : ObservableObject
{
    private readonly ISmhiForecastServices smhiServices;

    public Forecast Forecast { get; set; }

    //public Values Values => Forecast?.Values;

    public IAsyncRelayCommand GetForecastsCommand { get; set; }

    public MainViewModel(ISmhiForecastServices smhiServices)
    {
        this.smhiServices = smhiServices;
        GetForecastsCommand = new AsyncRelayCommand(GetForecasts);
        _ = GetForecasts().GetAwaiter();
    }

    public async Task GetForecasts()
    {
        SmhiForecast forecast = await smhiServices.GetForecasts("pmp3g", "2", "point", "17.160666", "60.716082");
        Forecast = new()
        {
            Created = forecast.ApprovedTime,
            Values = new Values(forecast.TimeSeries
            .Select(t => new Value
            {
                At = t.ValidTime,
                PressureText = t.Parameters?.SingleOrDefault(p => p.Name == "msl")?.Unit ?? "",
                Pressure = (float)(t.Parameters?.SingleOrDefault(p => p.Name == "msl")?.Values?.FirstOrDefault()),
                TemperatureText = t.Parameters?.SingleOrDefault(p => p.Name == "t")?.Unit ?? "",
                Temperature = (float)(t.Parameters?.SingleOrDefault(p => p.Name == "t")?.Values?.FirstOrDefault()),
            }))
        };

        OnPropertyChanged(nameof(Forecast));
    }
}
