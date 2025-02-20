namespace MRTWeather.Domain.Entities;

public class WeatherData
{
    public string CityName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Icon { get; init; } = string.Empty;
    public double Temperature { get; init; }
    public long Sunrise { get; init; }
    public long Sunset { get; init; }
}
