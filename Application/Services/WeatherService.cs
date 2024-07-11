using Newtonsoft.Json;
using WeatherForecastApi.Domain;

namespace WeatherForecastApi.Application;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OpenWeatherMap:ApiKey"];
    }

    public async Task<WeatherResponse> GetWeatherForecastAsync(string city)
    {
        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<WeatherResponse>(content);
    }
}