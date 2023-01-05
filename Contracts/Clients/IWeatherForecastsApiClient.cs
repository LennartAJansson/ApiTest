namespace Contracts;

using Refit;

public interface IWeatherForecastsApiClient
{
    [Get("/WeatherForecast/GetAll")]
    Task<IEnumerable<WeatherForecast>> GetForecasts();
    [Get("/WeatherForecast/GetById/{id}")]
    Task<WeatherForecast> GetForecast(int id);
}
