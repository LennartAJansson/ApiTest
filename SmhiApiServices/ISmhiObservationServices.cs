namespace SmhiApiServices;

using Contracts;

public interface ISmhiObservationServices
{
    Task<VersionsForApi> GetVersionsForApi();
    Task<ParametersForVersion> GetParametersForVersion(string version);
    Task<StationsForParameter> GetStationsForParameter(string version, string parameter);
    Task<PeriodsForStation> GetPeriodsForStation(string version, string parameter, string station);
    Task<ObservationsForPeriod> GetObservationsForPeriod(string version, string parameter, string station, string period);
}
