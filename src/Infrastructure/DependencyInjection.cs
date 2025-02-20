using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MRTWeather.Application.Common.Interfaces;
using MRTWeather.Infrastructure.ExternalServices.OpenWeather;

namespace MRTWeather.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        builder.Services.AddHttpClient<OpenWeatherService>(client =>
            {
                string baseAddress = configuration["OpenWeather:BaseAddress"]
                                     ?? throw new ArgumentNullException("OpenWeather:BaseAddress");
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                UseProxy = false,
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });

        builder.Services.AddSingleton<IWeatherService>(provider =>
            provider.GetRequiredService<OpenWeatherService>());
    }
}
