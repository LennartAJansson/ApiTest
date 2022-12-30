namespace PlainWeatherForecastApiTest;

using System.Text.Json;

using Contracts;

internal class Program
{
    private static async Task Main()
    {
        using HttpClient client = new HttpClient();

        var json = await client.GetStringAsync("https://localhost:7233/WeatherForecast/GetAll");
        if (json is not null)
        {
            IEnumerable<WeatherForecast>? weatherForecasts = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(json);
            //Do something with the data here
        }
    }
}