using Contracts;

using Refit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => AddServices(context, services))
    .Build();

using (host)
{
    await host.StartAsync();

    using (var scope = host.Services.CreateScope())
    {
        var api = scope.ServiceProvider.GetRequiredService<ICountryApiClient>();
        IEnumerable<Country> countries = await api.GetCountries();
        //Do something with the data here
    }

    await host.WaitForShutdownAsync();
}

void AddServices(HostBuilderContext context, IServiceCollection services) 
    => _ = services.AddRefitClient<ICountryApiClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(context.Configuration.GetConnectionString("CountryApiUrl")));