using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Randvice.Core.Advices;

namespace Randvice.Core;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection ConfigureCore(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.ConfigureMapping(configuration);
        services.AddScoped<IAdviceService, AdviceService>();
        return services;
    }

    private static IServiceCollection ConfigureMapping(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        return services;
    }
}
