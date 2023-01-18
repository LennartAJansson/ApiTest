using SmhiApiServices;
using SmhiApiServices.Contracts;
using SmhiApiServices.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => AddServices(context, services))
    .Build();

using (host)
{
    await host.StartAsync();

    using (IServiceScope scope = host.Services.CreateScope())
    {
        ISmhiObservationServices service = scope.ServiceProvider.GetRequiredService<ISmhiObservationServices>();
        ObservationsForPeriod temperatures = await service.GetObservationsForPeriod("1.0", "1", "107420", "latest-months");
        if (temperatures is not null && temperatures.Values is not null)
        {
            Console.WriteLine($"{temperatures?.Station?.Name} {temperatures?.Parameter?.Name}:");
            foreach (Observation? value in temperatures!.Values)
            {
                Console.WriteLine($"{value.Date}\t{value.Measured} {temperatures?.Parameter?.Unit}");
            }
        }

        var forecastService = scope.ServiceProvider.GetRequiredService<ISmhiForecastServices>();
        SmhiForecast forecast = await forecastService.GetForecasts("pmp3g", "2", "point", "17.160666", "60.716082");
        if (forecast is not null && forecast!.TimeSeries!.Any())
        {
            foreach (var timeSerie in forecast!.TimeSeries!)
            {
                var time = timeSerie.ValidTime;
                var tValues = timeSerie?.Parameters?.Single(p => p.Name == "t").Values;
                var tUnit = timeSerie?.Parameters?.Single(p => p.Name == "t").Unit;
                var mslValues = timeSerie?.Parameters?.Single(p => p.Name == "msl").Values;
                var mslUnit = timeSerie?.Parameters?.Single(p => p.Name == "msl").Unit;
                Console.WriteLine($"{time}{tValues?.First(),8:N0} {tUnit}\t\t{mslValues?.First(),8:N0} {mslUnit}");
            }
        }
    }

    await host.WaitForShutdownAsync();
}
void AddServices(HostBuilderContext context, IServiceCollection services) 
    => services.AddSmhiSupport(() => context.Configuration);