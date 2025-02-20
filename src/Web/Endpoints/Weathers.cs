using MRTWeather.Application.WeatherForecasts.Commands.SetTemperatureUnit;
using MRTWeather.Application.WeatherForecasts.Queries.GetWeatherData;

namespace MRTWeather.Web.Endpoints;

public class Weathers : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup("api/weathers/").WithTags("Weathers");
        group.MapGet( "get-weather-data", GetWeatherData);
        group.MapPost( "set-temperature-unit", SetTemperatureUnit);
    }

    public async Task<IResult> GetWeatherData(ISender sender)
    {
        var result = await sender.Send(new GetWeatherDataQuery());
        return Results.Ok(result);
    }

    public async Task<IResult> SetTemperatureUnit(SetTemperatureUnitCommand command, ISender sender)
    {
        await sender.Send(command);
        return Results.NoContent();
    }
}
