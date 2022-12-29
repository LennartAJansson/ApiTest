namespace WeatherForecastApiTest;

using Contracts;
using Refit;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //https://localhost:7233/WeatherForecast
        IWeatherForecastsApiClient weatherForecastsApi = RestService.For<IWeatherForecastsApiClient>("https://localhost:7233");

        IEnumerable<WeatherForecast> forecasts = await weatherForecastsApi.GetForecasts();
        WeatherForecast forecast = await weatherForecastsApi.GetForecast(1);
    }
}