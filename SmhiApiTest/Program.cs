namespace SmhiApiTest;

using System.Threading.Tasks;

using Contracts;
using Refit;

internal class Program
{
    private static async Task Main()
    {
        ISmhiApiClient smhiApi = RestService.For<ISmhiApiClient>("https://opendata-download-metobs.smhi.se/api/version/1.0/");

        SmhiTemperature? temperatures = await smhiApi.GetLatestMonths();
        if (temperatures is not null && temperatures.Values is not null)
        {
            await Console.Out.WriteLineAsync($"{temperatures?.Station?.Name} {temperatures?.Parameter?.Name}:");
            foreach (Value? value in temperatures!.Values)
            {
                await Console.Out.WriteLineAsync($"{value.Date}\t{value.Measured} {temperatures?.Parameter?.Unit}");
            }
        }
    }
}