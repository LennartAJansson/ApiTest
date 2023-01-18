namespace SmhiApiServices;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Refit;

using SmhiApiServices.Clients;
using SmhiApiServices.Services;

public static class SmhiExtensions
{
    public static IServiceCollection AddSmhiSupport(this IServiceCollection services, Func<IConfiguration> GetConfiguration)
    {
        IConfiguration config = GetConfiguration?.Invoke() 
            ?? throw new ArgumentException("You have to point out the configuration where the base urls are");
        
        _ = services.AddRefitClient<ISmhiObservationApiClient>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(config["BaseUrls:SmhiObservation"]);
                //If you need any headers or authentications added to your requests
                //(it's also possible to add them as attributes to the interface or its methods):
                //c.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
                //c.DefaultRequestHeaders.Add("x-api-key", YourApiKey);
            });
        _ = services.AddRefitClient<ISmhiForecastApiClient>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(config["BaseUrls:SmhiForecast"]);
                //If you need any headers or authentications added to your requests
                //(it's also possible to add them as attributes to the interface or its methods):
                //c.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
                //c.DefaultRequestHeaders.Add("x-api-key", YourApiKey);
            });
        services.AddTransient<ISmhiForecastServices, SmhiForecastServices>();
        services.AddTransient<ISmhiObservationServices, SmhiObservationServices>();
        return services;
    }
}