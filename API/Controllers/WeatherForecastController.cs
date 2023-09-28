using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
//inside [] is Route parameter here it is controller which is just a Place holder,
// controller means class name(basically called controller) below.
// to access this endpoint any user would do: https://localhost:5001/WeatherForescast
// note name of the controller , controller at the end of the name is not used
//because by convention this controller name is ignore when it comes to what inside the "Route"
[Route("[controller]")] // get https://localhost:5001/WeatherForecast
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    // this is how we inject services into controller. here we have is a constructor
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")] //endpoint : an http get , this will be hit when triggered
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
