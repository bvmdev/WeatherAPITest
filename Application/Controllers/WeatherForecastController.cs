using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherForecastApi.Application;
using WeatherForecastApi.Domain;
using WeatherForecastApi.Infrastructure;

namespace WeatherForecastApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        private readonly WeatherDbContext _dbContext;

        public WeatherForecastController(WeatherService weatherService, WeatherDbContext dbContext)
        {
            _weatherService = weatherService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast(string city)
        {
            var forecast = await _weatherService.GetWeatherForecastAsync(city);
            var history = new WeatherHistory
            {
                City = city,
                Date = DateTime.UtcNow, // Set the date to UTC
                WeatherData = JsonConvert.SerializeObject(forecast)
            };
            _dbContext.WeatherHistories.Add(history);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                City = history.City,
                Date = history.Date,
                WeatherData = JsonConvert.DeserializeObject<WeatherResponse>(history.WeatherData)
            });
        }

        [HttpGet("history")]
        public IActionResult GetWeatherHistory([FromQuery] string city)
        {
            if (city == string.Empty)
            {
                var history = _dbContext.WeatherHistories.ToList();
                return Ok(history);
            }
            else
            {
                var history = _dbContext.WeatherHistories.Where(x=> x.City == city).ToList();
                return Ok(history);
            }
        }
    }
}