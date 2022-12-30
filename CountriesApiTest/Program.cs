namespace CountriesApiTest;

using Contracts;
using Refit;

internal class Program
{
    private static async Task Main()
    {
        ICountryApiClient countriesApi = RestService.For<ICountryApiClient>("https://restcountries.com/");

        IEnumerable<Country> countries = await countriesApi.GetCountries();
        //Do something with the data here
    }
}