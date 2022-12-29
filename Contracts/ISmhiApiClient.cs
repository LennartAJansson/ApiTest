namespace Contracts;

using Refit;

public interface ISmhiApiClient
{
    //parameter/1/station/107420/period/latest-months/data.json

    [Get("/parameter/1/station/107420/period/latest-months/data.json")]
    Task<SmhiTemperature> GetLatestMonths();
}