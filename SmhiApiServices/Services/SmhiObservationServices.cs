namespace SmhiApiServices.Services;

using System.Threading.Tasks;

using SmhiApiServices.Contracts;

using SmhiApiServices.Clients;

public class SmhiObservationServices : ISmhiObservationServices
{
    private readonly ISmhiObservationApiClient client;

    public SmhiObservationServices(ISmhiObservationApiClient client)
    {
        this.client = client;
    }

    public async Task<VersionsForApi> GetVersionsForApi()
    {
        return await client.GetVersionsForApi();

    }

    public async Task<ParametersForVersion> GetParametersForVersion(string version)
    {
        return await client.GetParametersForVersion(version);
    }

    public async Task<StationsForParameter> GetStationsForParameter(string version, string parameter)
    {
        return await client.GetStationsForParameter(version, parameter);
    }

    public async Task<PeriodsForStation> GetPeriodsForStation(string version, string parameter, string station)
    {
        return await client.GetPeriodsForStation(version, parameter, station);
    }

    public async Task<ObservationsForPeriod> GetObservationsForPeriod(string version, string parameter, string station, string period)
    {
        return await client.GetObservationsForPeriod(version, parameter, station, period);
    }
}
