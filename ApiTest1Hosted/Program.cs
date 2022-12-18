using Contracts;

using Refit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => AddServices(context, services))
    .Build();

using (host)
{
    await host.StartAsync();

    //Trigger any threads/objects that should be executed
    using (var scope = host.Services.CreateScope())
    {
        var worker = scope.ServiceProvider.GetRequiredService<Worker>();
        //IEnumerable<WeatherForecast> forecasts = await api.GetForecasts();
        WeatherForecast forecast = await worker.GetWeatherForecast(1);
    }

    //Stay and wait for the shutdown signalling
    await host.WaitForShutdownAsync();
}

void AddServices(HostBuilderContext context, IServiceCollection services)
{
    //Adds services to the container.
    services.AddTransient<Worker>();
    _ = services.AddRefitClient<IWeatherForecastsApi>()
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://localhost:7233");
        });
}


public class Worker
{
    private readonly IWeatherForecastsApi api;

    public Worker(IWeatherForecastsApi api)
    {
        this.api = api;
    }

    public async Task<WeatherForecast> GetWeatherForecast(int id)
    {
        return await api.GetForecast(id);
    }
}