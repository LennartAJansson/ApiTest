namespace WeatherForecastApiWithApiKey;

using Contracts;

using Microsoft.OpenApi.Models;

using WeatherForecastApiWithApiKey.Attributes;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        _ = builder.Services.AddAuthorization();
        _ = builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServiceName", Version = "1" });
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Name = "x-api-key",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Description = "Authorization by x-api-key inside request's header",
                Scheme = "ApiKeyScheme"
            });

            OpenApiSecurityScheme key = new()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            };

            OpenApiSecurityRequirement requirement = new() { { key, new List<string>() } };

            c.AddSecurityRequirement(requirement);
        });

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }

        //app.UseMiddleware<ApiKeyMiddleware>();
        _ = app.UseHttpsRedirection();

        _ = app.UseAuthorization();

        string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        RouteGroupBuilder group = app.MapGroup("/weatherforecast")
            .WithTags(nameof(WeatherForecast));

        _ = group.MapGet("/GetAll/", (HttpContext httpContext) =>
        {
            WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToArray();
            return forecast;
        })
        .WithName("GetAll")
        .UseApiKey()
        .WithOpenApi();
        _ = group.MapGet("/GetById/{id}", (HttpContext httpContext, int id) =>
        {
            WeatherForecast forecast = new()
            {
                Id = id,
                Date = DateTime.Now.AddDays(id),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            };
            return forecast;
        })
        .WithName("GetById")
        .UseApiKey()
        .WithOpenApi();

        _ = app.MapControllers();
        app.Run();
    }
}
