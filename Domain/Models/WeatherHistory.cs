namespace WeatherForecastApi.Domain;

public class WeatherHistory
{
    public int Id { get; set; }
    public string City { get; set; }
    public DateTime Date { get; set; }
    public string WeatherData { get; set; }

    public WeatherHistory()
    {
        // Ensure the date is set to UTC
        Date = DateTime.UtcNow;
    }
}