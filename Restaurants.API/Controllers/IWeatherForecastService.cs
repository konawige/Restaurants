namespace Restaurants.API.Controllers;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Get(int nbResult, int minTemp, int maxTemp);
}