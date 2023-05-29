using Contracts;

using Refit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(AddServices)
    .Build();

host.Run();

static void AddServices(HostBuilderContext context, IServiceCollection services)
{
    _ = services.AddHostedService<Worker>();
    _ = services.AddRefitClient<IWeatherForecastsApiClient>()
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(context.Configuration.GetConnectionString("WeatherForecastApiUrl")
                ?? throw new ArgumentException("No URI in configuration"));
            c.DefaultRequestHeaders.Add("x-api-key", context.Configuration.GetValue<string>("ApiKey")
                ?? throw new ArgumentException("No ApiKey in configuration"));
        });
}
