using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api1/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecasts = new();

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {//Este metodo es el constructor del controlador
    //     _logger = logger;

    //     if (ListWeatherForecasts == null || !ListWeatherForecasts.Any() == false)
    //     {
    //         ListWeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //         {
    //             Date = DateTime.Now.AddDays(index),
    //             TemperatureC = Random.Shared.Next(-20, 55),
    //             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //         })
    //         .ToList();
    //     }

    // }
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            var random = new Random();

            if(ListWeatherForecasts == null || !ListWeatherForecasts.Any())
            {
                ListWeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = random.Next(-20, 55),
                    Summary = Summaries[random.Next(Summaries.Length)]
                })
                .ToList(); 
            }
        }

    [HttpGet(Name = "GetWeatherForecast")]
    // [Route("get/weatherforecast")]
    // [Route("get/weatherforecast2")]
    // [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Getting all the weather forecasts");
        return ListWeatherForecasts;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecasts.Add(weatherForecast);
        return Ok();
    }


      [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if (ListWeatherForecasts.Count <= index)
        {
            return BadRequest("The given ID is out of bounds.");
        }

        ListWeatherForecasts.RemoveAt(index);

        return Ok("Forecast was successfully removed.");
    }

}



// Les comparto una pequeña validacion que hice para el metodo post! \[
//     HttpPost]    public IActionResult Post(WeatherForecast weatherForecast)    {  
//               bool hasData;        if(weatherForecast != null)        { 
//                            ListWeatherForecast.Add(weatherForecast);            hasData = true;        } else         {     
//                                    Console.WriteLine("Ingrese datos por favor!");            hasData = false;        }  
//                                          return hasData ? Ok() : BadRequest();    }```js [HttpPost] public IActionResult Post(
//                                             WeatherForecast weatherForecast) { bool hasData; if(weatherForecast != null) { 
//                                                 ListWeatherForecast.Add(weatherForecast); hasData = true; } else {
//                                                      Console.WriteLine("Ingrese datos por favor!"); hasData = false; } 
//                                                      return hasData ? Ok() : BadRequest(); }