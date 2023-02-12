namespace MauiForecasts;

using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;

using MauiForecasts.ViewModels;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SmhiApiServices;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();

        builder
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.AddTransient<MainPage, MainViewModel>();
        builder.Services.AddSmhiSupport(() => builder.Configuration);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
