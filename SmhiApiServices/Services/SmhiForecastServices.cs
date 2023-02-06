namespace SmhiApiServices.Services;

using SmhiApiServices.Clients;
using SmhiApiServices.Contracts;
using SmhiApiServices.Models;

using System.Threading.Tasks;

public class SmhiForecastServices : ISmhiForecastServices
{
    private readonly ISmhiForecastApiClient client;

    public SmhiForecastServices(ISmhiForecastApiClient client) => this.client = client;

    public async Task<Forecast> GetForecasts(string category, string version, string geotype, string longitude, string latitude)
    {
        SmhiForecast forecast = await client.GetForecasts(category, version, geotype, longitude, latitude);
        //TODO Check availability of different valuse to return...
        return new()
        {
            Created = forecast.ApprovedTime,
            Values = new Values(forecast.TimeSeries
            .Select(t => new Value
            {
                At = t.ValidTime,
                PressureText = t.Parameters?.SingleOrDefault(p => p.Name == "msl")?.Unit ?? "",
                Pressure = (float)(t.Parameters?.SingleOrDefault(p => p.Name == "msl")?.Values?.FirstOrDefault()),
                TemperatureText = t.Parameters?.SingleOrDefault(p => p.Name == "t")?.Unit ?? "",
                Temperature = (float)(t.Parameters?.SingleOrDefault(p => p.Name == "t")?.Values?.FirstOrDefault()),
            }))
        };

    }
}
