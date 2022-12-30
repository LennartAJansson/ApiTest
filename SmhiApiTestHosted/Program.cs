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
        var api = scope.ServiceProvider.GetRequiredService<ISmhiApiClient>();
        SmhiTemperature temperatures = await api.GetLatestMonths();
        if (temperatures is not null && temperatures.Values is not null)
        {
            await Console.Out.WriteLineAsync($"{temperatures?.Station?.Name} {temperatures?.Parameter?.Name}:");
            foreach (Value? value in temperatures!.Values)
            {
                await Console.Out.WriteLineAsync($"{value.Date}\t{value.Measured} {temperatures?.Parameter?.Unit}");
            }
        }
    }

    await host.WaitForShutdownAsync();
}
void AddServices(HostBuilderContext context, IServiceCollection services)
    => _ = services.AddRefitClient<ISmhiApiClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(context.Configuration.GetConnectionString("SmhiApiUrl")));