namespace WeatherForecastApiWithApiKey.Middleware;

using Microsoft.AspNetCore.Mvc;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string APIKEYNAME = "ApiKey";
    private const string HEADERNAME = "x-api-key";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(HEADERNAME, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync("Api Key was not provided. (Using ApiKeyMiddleware)");
            return;
        }

        var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = appSettings.GetValue<string>(APIKEYNAME);

        if (apiKey is null || !apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync("Unauthorized client. (Using ApiKeyMiddleware)");
            return;
        }

        await _next(context);
    }
}
