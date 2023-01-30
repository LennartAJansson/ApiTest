namespace SmhiApiServices.Services;

using System.Text.Json;
using System.Threading.Tasks;

using SmhiApiServices.Clients;
using SmhiApiServices.Contracts;
using SmhiApiServices.Converters;

public class ManualSmhiForecastServices : ISmhiForecastServices
{
    private readonly ISmhiForecastApiClient client;

    public ManualSmhiForecastServices(ISmhiForecastApiClient client)
    {
        this.client = client;
    }

    public async Task<SmhiForecast> GetForecasts(string category, string version, string geotype, string longitude, string latitude)
    {
        return await client.GetForecasts(category, version, geotype, longitude, latitude);
    }
}
