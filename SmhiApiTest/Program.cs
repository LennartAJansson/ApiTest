namespace SmhiApiTest;

using System.Threading.Tasks;

using Contracts;
using Refit;

internal class Program
{
    private static async Task Main(string[] args)
    {
        ISmhiApiClient smhiApi = RestService.For<ISmhiApiClient>("https://opendata-download-metobs.smhi.se/api/version/1.0/");

        SmhiTemperature reports = await smhiApi.GetLatestMonths();
    }
}