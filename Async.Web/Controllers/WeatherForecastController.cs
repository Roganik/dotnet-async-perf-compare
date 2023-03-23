using Microsoft.AspNetCore.Mvc;

namespace Async.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(template: "GetSync", Name = "GetWeatherForecastSync")]
    public IEnumerable<WeatherForecast> GetSync()
    {
        Thread.Sleep(100);

        return GetForecast;
    }

    [HttpGet(template: "GetAsync", Name = "GetWeatherForecastAsync")]
    public async Task<WeatherForecast[]> GetAsync()
    {
        await Task.Delay(100);

        return GetForecast;
    }

    private WeatherForecast[] GetForecast => Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
}