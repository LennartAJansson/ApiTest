namespace WeatherForecastApiTest;

using Contracts;
using Refit;

internal class Program
{
    private static async Task Main()
    {
        //https://localhost:7233/WeatherForecast
        IWeatherForecastsApiClient weatherForecastsApi = RestService.For<IWeatherForecastsApiClient>("https://localhost:7233");

        IEnumerable<WeatherForecast> forecasts = await weatherForecastsApi.GetForecasts();
        WeatherForecast forecast = await weatherForecastsApi.GetForecast(1);
        //Do something with the data here
    }
}