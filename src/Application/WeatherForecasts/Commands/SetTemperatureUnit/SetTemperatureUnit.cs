using MRTWeather.Application.Common.Interfaces;
using MRTWeather.Application.WeatherForecasts.Common;

namespace MRTWeather.Application.WeatherForecasts.Commands.SetTemperatureUnit;

public record SetTemperatureUnitCommand(TemperatureUnit Unit) : IRequest<bool>;

public class SetTemperatureUnitCommandHandler : IRequestHandler<SetTemperatureUnitCommand, bool>
{
    private readonly IWeatherService _weatherService;

    public SetTemperatureUnitCommandHandler(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<bool> Handle(SetTemperatureUnitCommand request, CancellationToken cancellationToken)
    {
        await _weatherService.SetTemperatureUnitAsync(request.Unit, cancellationToken);
        return true;
    }
}
