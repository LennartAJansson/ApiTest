namespace MauiForecasts;

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
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<VmForecasts>();
        builder.Services.AddSmhiSupport(() => builder.Configuration);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
