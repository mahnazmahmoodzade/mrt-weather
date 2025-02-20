namespace MRTWeather.Application.WeatherForecasts.Queries.GetWeatherData;

public class GetWeatherDataQueryValidator : AbstractValidator<GetWeatherDataQuery>
{
    public GetWeatherDataQueryValidator()
    {
        RuleFor(x => x).NotNull();
    }
}
