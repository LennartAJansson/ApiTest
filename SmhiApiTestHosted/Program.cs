using SmhiApiServices;
using SmhiApiServices.Contracts;
using SmhiApiServices.Models;
using SmhiApiServices.Services;

//This example is using Dependency Injection

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

        ISmhiForecastServices forecastService = scope.ServiceProvider.GetRequiredService<ISmhiForecastServices>();
        Forecast forecast = await forecastService.GetForecasts("pmp3g", "2", "point", "17.160666", "60.716082");
        if (forecast is not null && forecast!.Values!.Any())
        {
            foreach (Value values in forecast.Values!)
            {
                DateTime time = values.At;
                Console.WriteLine($"{time}{values.Temperature,8:N0} {values.TemperatureText}\t\t{values.Pressure,8:N0} {values.PressureText}");
            }
        }
    }

    await host.WaitForShutdownAsync();
}
void AddServices(HostBuilderContext context, IServiceCollection services)
    => services.AddSmhiSupport(() => context.Configuration);

