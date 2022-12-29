namespace PlainSmhiApiTest;

using Contracts;
using System.Text.Json;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

        var json = await client.GetStringAsync("https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station/107420/period/latest-months/data.json");
        if (json is not null)
        {
            SmhiTemperature temperatures = JsonSerializer.Deserialize<SmhiTemperature>(json);
        }
    }
}