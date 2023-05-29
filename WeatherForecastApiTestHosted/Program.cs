using Contracts;

using Refit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(AddServices)
    .Build();

using (host)
{
    await host.StartAsync();

    using (IServiceScope scope = host.Services.CreateScope())
    {
        IWeatherForecastsApiClient api = scope.ServiceProvider.GetRequiredService<IWeatherForecastsApiClient>();
        IEnumerable<WeatherForecast> forecasts = await api.GetForecasts();
        WeatherForecast forecast = await api.GetForecast(1);
        //Do something with the data here
    }

    await host.WaitForShutdownAsync();
}

static void AddServices(HostBuilderContext context, IServiceCollection services)
    => _ = services.AddRefitClient<IWeatherForecastsApiClient>()
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(context.Configuration.GetConnectionString("WeatherForecastApiUrl")
                ?? throw new ArgumentException("No URI in configuration"));
        }
        );
