using MRTWeather.Application.WeatherForecasts.Common;
using MRTWeather.Domain.Entities;

namespace MRTWeather.Application.Common.Interfaces;

public interface IWeatherService
{
    Task<WeatherData> GetWeatherDataAsync(string city, CancellationToken cancellationToken);
    Task SetTemperatureUnitAsync(TemperatureUnit unit, CancellationToken cancellationToken);
}
