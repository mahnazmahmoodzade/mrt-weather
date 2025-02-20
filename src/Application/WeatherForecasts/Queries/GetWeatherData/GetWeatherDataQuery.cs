using Microsoft.Extensions.Configuration;
using MRTWeather.Application.Common.Interfaces;
using MRTWeather.Application.WeatherForecasts.Common;

namespace MRTWeather.Application.WeatherForecasts.Queries.GetWeatherData;

public record GetWeatherDataQuery : IRequest<IEnumerable<WeatherDataDto>>;

public class GetWeatherDataQueryHandler : IRequestHandler<GetWeatherDataQuery, IEnumerable<WeatherDataDto>>
{
    private readonly IWeatherService _weatherService;
    private readonly IConfiguration _configuration;

    public GetWeatherDataQueryHandler(IWeatherService weatherService, IConfiguration configuration)
    {
        _weatherService = weatherService;
        _configuration = configuration;
    }

    public async Task<IEnumerable<WeatherDataDto>> Handle(GetWeatherDataQuery request, CancellationToken cancellationToken)
    {
        var cities = _configuration.GetSection("OpenWeather:Cities").Get<List<string>>()
                     ?? throw new ArgumentNullException("OpenWeather:Cities", "No cities found in the configuration.");

        var getWeatherRequests = cities.Select(city => _weatherService.GetWeatherDataAsync(city, cancellationToken));

        var weatherDataList = await Task.WhenAll(getWeatherRequests);

       var weatherDataDtos= weatherDataList.Select(weatherData => new WeatherDataDto
       {
           CityName = weatherData.CityName,
           Description = weatherData.Description,
           Icon = weatherData.Icon,
           Temperature = weatherData.Temperature,
           Sunrise = weatherData.Sunrise,
           Sunset = weatherData.Sunset
       });
        return weatherDataDtos;
    }
}
