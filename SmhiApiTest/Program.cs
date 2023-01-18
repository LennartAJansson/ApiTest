namespace SmhiApiTest;

using System.Threading.Tasks;

using Contracts;

using Refit;

using SmhiApiServices.Clients;
using SmhiApiServices.Contracts;

internal class Program
{
    private static async Task Main()
    {
        //If you need support for decompression:
        //var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
        //var client = new HttpClient(handler)
        //{
        //    BaseAddress = new Uri("https://opendata-download-metobs.smhi.se")
        //};
        //ISmhiApiClient smhiApi = RestService.For<ISmhiApiClient>(client);

        ISmhiObservationApiClient smhiApi = RestService.For<ISmhiObservationApiClient>("https://opendata-download-metobs.smhi.se");

        ObservationsForPeriod? temperatures = await smhiApi.GetObservationsForPeriod("1.0", "1", "107420", "latest-months");
        if (temperatures is not null && temperatures.Values is not null)
        {
            Console.WriteLine($"{temperatures?.Station?.Name} {temperatures?.Parameter?.Name}:");
            foreach (Observation? value in temperatures!.Values)
            {
                Console.WriteLine($"{value.Date}\t{value.Measured} {temperatures?.Parameter?.Unit}");
            }
        }
    }
}