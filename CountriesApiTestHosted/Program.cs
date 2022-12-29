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
        var api = scope.ServiceProvider.GetRequiredService<ICountryApiClient>();
        IEnumerable<Country> countries = await api.GetCountries();
    }

    //Stay and wait for the shutdown signalling
    await host.WaitForShutdownAsync();
}

void AddServices(HostBuilderContext context, IServiceCollection services) 
    => _ = services.AddRefitClient<ICountryApiClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(context.Configuration.GetConnectionString("CountryApiUrl")));