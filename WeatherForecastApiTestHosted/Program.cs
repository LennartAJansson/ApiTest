using Contracts;

using Refit;

using WeatherForecastApiTestHosted;

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
        IEnumerable<WeatherForecast> forecasts = await worker.GetWeatherForecasts();
        WeatherForecast forecast = await worker.GetWeatherForecast(1);
    }

    //Stay and wait for the shutdown signalling
    await host.WaitForShutdownAsync();
}

static void AddServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddTransient<Worker>();
    _ = services.AddRefitClient<IWeatherForecastsApiClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(context.Configuration.GetConnectionString("WeatherForecastApiUrl")));
}
