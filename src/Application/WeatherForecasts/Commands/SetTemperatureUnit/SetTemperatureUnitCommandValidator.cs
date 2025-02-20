namespace MRTWeather.Application.WeatherForecasts.Commands.SetTemperatureUnit;

public class SetTemperatureUnitCommandValidator : AbstractValidator<SetTemperatureUnitCommand>
{
    public SetTemperatureUnitCommandValidator()
    {
        RuleFor(v => v.Unit)
            .IsInEnum()
            .WithMessage("'{PropertyName}' must be a valid temperature unit.");
    }
}
