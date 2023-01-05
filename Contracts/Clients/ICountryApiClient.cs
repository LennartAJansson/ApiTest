namespace Contracts;

using Refit;

public interface ICountryApiClient
{
    [Get("/v3.1/all")]
    Task<IEnumerable<Country>> GetCountries();
}
