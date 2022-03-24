namespace TaxService.Application;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IConfigurationManager, ConfigurationManager>();
        services.AddSingleton<ITaxCalculator, TaxJarCalculator>();
        services.AddScoped(typeof(ITaxServiceRequest<>));

        return services;
    }
}

