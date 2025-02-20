namespace MRTWeather.Infrastructure.ExternalServices.OpenWeather.Models;

public class OpenWeatherResponse
{
    public string Name { get; set; } = string.Empty;
    public WeatherInfo[] Weather { get; set; } = Array.Empty<WeatherInfo>();
    public MainInfo Main { get; set; } = new();
    public SysInfo Sys { get; set; } = new();
}
