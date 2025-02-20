using Microsoft.AspNetCore.Mvc;

namespace MRTWeather.Web;

public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddExceptionHandler<CustomExceptionHandler>();
    }
}
