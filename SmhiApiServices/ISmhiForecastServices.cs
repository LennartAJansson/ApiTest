namespace SmhiApiServices;

using Contracts.Model;

public interface ISmhiForecastServices
{
    Task<SmhiForecast> GetForecasts(string category, string version, string geotype, string longitude, string latitude);
}
