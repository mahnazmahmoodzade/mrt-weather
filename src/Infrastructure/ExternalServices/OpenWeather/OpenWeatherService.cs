using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using MRTWeather.Application.Common.Interfaces;
using MRTWeather.Application.WeatherForecasts.Common;
using MRTWeather.Domain.Entities;
using MRTWeather.Infrastructure.ExternalServices.OpenWeather.Models;

namespace MRTWeather.Infrastructure.ExternalServices.OpenWeather;

public class OpenWeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private TemperatureUnit _unit = TemperatureUnit.Metric;

    public OpenWeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OpenWeather:ApiKey"] ?? throw new ArgumentNullException(nameof(configuration));
        string baseAddress = configuration["OpenWeather:BaseAddress"]
                             ?? throw new ArgumentNullException(nameof(configuration));
        _httpClient.BaseAddress = new Uri(baseAddress);
    }

    public async Task<WeatherData> GetWeatherDataAsync(string city, CancellationToken cancellationToken)
    {
        var units = _unit == TemperatureUnit.Metric ? "metric" : "imperial";

        var response = await _httpClient.GetFromJsonAsync<OpenWeatherResponse>(
            $"weather?q={city}&appid={_apiKey}&units={units}",
            cancellationToken);

        if (response == null)
            throw new Exception($"Failed to get weather data for {city}");

        return new WeatherData
        {
            CityName = response.Name,
            Description = response.Weather[0].Description,
            Icon = response.Weather[0].Icon,
            Temperature = response.Main.Temp,
            Sunrise = response.Sys.Sunrise,
            Sunset = response.Sys.Sunset
        };
    }

    public Task SetTemperatureUnitAsync(TemperatureUnit unit, CancellationToken cancellationToken)
    {
        _unit = unit;
        return Task.CompletedTask;
    }
}
