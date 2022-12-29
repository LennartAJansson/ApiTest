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
        var api = scope.ServiceProvider.GetRequiredService<ISmhiApiClient>();
        SmhiTemperature reports = await api.GetLatestMonths();
    }

    //Stay and wait for the shutdown signalling
    await host.WaitForShutdownAsync();
}
void AddServices(HostBuilderContext context, IServiceCollection services)
{
    _ = services.AddRefitClient<ISmhiApiClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(context.Configuration.GetConnectionString("SmhiApiUrl")));
}