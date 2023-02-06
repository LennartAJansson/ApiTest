namespace SmhiApiServices.Services;

using SmhiApiServices.Contracts;
using SmhiApiServices.Models;

public interface ISmhiForecastServices
{
    Task<Forecast> GetForecasts(string category, string version, string geotype, string longitude, string latitude);
}
