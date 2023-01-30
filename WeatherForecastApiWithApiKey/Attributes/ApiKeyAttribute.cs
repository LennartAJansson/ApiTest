namespace WeatherForecastApiWithApiKey.Attributes;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter, IEndpointFilter
{
    private const string APIKEYNAME = "ApiKey";
    private const string HEADERNAME = "x-api-key";

    //This is for Minimal Api's
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await CheckAndVerifyApiKey(context.HttpContext);

        if (result is Ok)
            return await next.Invoke(context);
        else
        {
            return result;
        }

    }

    //This is for Controllers
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await CheckAndVerifyApiKey(context.HttpContext);

        if (result is Ok)
            await next();
        else
        {
            await result.ExecuteAsync(context.HttpContext);
        }
    }

    private Task<IResult> CheckAndVerifyApiKey(HttpContext context)
    {
        var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = appSettings.GetValue<string>(APIKEYNAME);

        if (!context.Request.Headers.TryGetValue(HEADERNAME, out var extractedApiKey))
        {
            return Task.FromResult(Results.Json(new { StatusCode = 401, Content = "Api Key was not provided. (Using ApiKeyAttribute)" }, statusCode: 401));
        }

        if (apiKey is null || !apiKey.Equals(extractedApiKey))
        {
            return Task.FromResult(Results.Json(new { StatusCode = 401, Content = "Api Key was invalid. (Using ApiKeyAttribute)" }, statusCode: 401));
        }

        return Task.FromResult(Results.Ok());
    }
}


public static class MinimalApiExtensions
{
    private static readonly IEndpointFilter _apiKeyMetadata = new ApiKeyAttribute();
    public static TBuilder UseApiKey<TBuilder>(this TBuilder builder) where TBuilder : IEndpointConventionBuilder
    {
        builder.AddEndpointFilter(_apiKeyMetadata);

        return builder;
    }
}

