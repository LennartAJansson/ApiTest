namespace PlainSmhiApiTest;

using System.Text.Json;
using System.Threading.Tasks;

using Contracts;
using Contracts.Converters;

internal class Program
{
    private static async Task Main()
    {
        using HttpClient client = new HttpClient();

        var json = await client.GetStringAsync("https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station/107420/period/latest-months/data.json");
        if (json is not null)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new UnixDateConverter());

            ObservationsForPeriod? temperatures = JsonSerializer.Deserialize<ObservationsForPeriod>(json, options);
            if (temperatures is not null && temperatures.Values is not null)
            {
                await Console.Out.WriteLineAsync($"{temperatures?.Station?.Name} {temperatures?.Parameter?.Name}:");
                foreach (Observation? value in temperatures!.Values)
                {
                    await Console.Out.WriteLineAsync($"{value.Date}\t{value.Measured} {temperatures?.Parameter?.Unit}");
                }
            }
        }
    }
}

