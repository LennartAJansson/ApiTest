namespace SmhiApiServices;

using System.Threading.Tasks;

using Contracts;
using Contracts.Model;

public class SmhiForecastServices: ISmhiForecastServices
{
    private readonly ISmhiForecastApiClient client;

    public SmhiForecastServices(ISmhiForecastApiClient client)
    {
        this.client = client;
    }

    public async Task<SmhiForecast> GetForecasts(string category, string version, string geotype, string longitude, string latitude)
    {
        return await client.GetForecasts(category, version, geotype, longitude, latitude);
    }
}
