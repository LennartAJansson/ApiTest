namespace ApiTest1;

using Contracts;

using Refit;

internal class Program
{
    private static readonly string ApiKey = "c23a43f966c3b218c2a172600c7c56b1";
    private static async Task Main(string[] args)
    {
        //https://localhost:7233/WeatherForecast
        IWeatherForecastsApi weatherForecastsApi = RestService.For<IWeatherForecastsApi>("https://localhost:7233");

        IEnumerable<WeatherForecast> forecasts = await weatherForecastsApi.GetForecasts();
        WeatherForecast forecast = await weatherForecastsApi.GetForecast(1);
    }
}
