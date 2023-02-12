namespace SmhiApiServices.Services;
using System.Threading.Tasks;

using SmhiApiServices.Clients;
using SmhiApiServices.Contracts;

public class ManualSmhiForecastServices : ISmhiForecastServices
{
    private readonly ISmhiForecastApiClient client;

    public ManualSmhiForecastServices(ISmhiForecastApiClient client) => this.client = client;

    public async Task<SmhiForecast> GetForecasts(string category, string version, string geotype, string longitude, string latitude)
    {
        SmhiForecast forecast = await client.GetForecasts(category, version, geotype, longitude, latitude);
        return forecast;
    }
}
