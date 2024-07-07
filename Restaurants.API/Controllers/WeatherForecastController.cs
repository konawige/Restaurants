using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = _weatherForecastService.Get(5, -20, 55);
        return result;
    }
    [HttpPost]
    [Route("generate")]
    public IActionResult Generate([FromBody] WeatherForecastRequest request)
    {
        if (request.NbResult <= 0)
        {
            return BadRequest("nbResult should be greater than 0");
        }
        if (request.MinTemp > request.MaxTemp)
        {
            return BadRequest("minTemp should be less than maxTemp");
        }
        
        var result = _weatherForecastService.Get(request.NbResult, request.MinTemp, request.MaxTemp);
        return Ok(result);
    }
    
}
