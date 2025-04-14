using System;

namespace ClassLibrary.WebApi.Endpoints;

/// <summary>
/// This is a weather-forecast endpoint.
/// </summary>
public class WeatherForecast
{
    public static void Register(WebApplication app)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () => 
        {
            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastData
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToList();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();
    }
    
    record WeatherForecastData(DateOnly Date, int TemperatureC, string Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
