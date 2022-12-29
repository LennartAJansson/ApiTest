namespace WeatherForecastApiTestHosted;

using Contracts;

public class Worker
{
    private readonly IWeatherForecastsApiClient api;

    public Worker(IWeatherForecastsApiClient api)
    {
        this.api = api;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
    {
        return await api.GetForecasts();
    }

    public async Task<WeatherForecast> GetWeatherForecast(int id)
    {
        return await api.GetForecast(id);
    }
}
