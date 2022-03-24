namespace TaxService.Application;

using Microsoft.Extensions.DependencyInjection;
using TaxService.Application.Behavior;
using TaxService.Application.Interface;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IConfigurationManager, ConfigurationManager>();
        services.AddSingleton<ITaxCalculator, TaxJarCalculator>();
        services.AddSingleton<IException, ExceptionBehavior>();

        services.AddScoped(typeof(ITaxServiceRequest<>));

        return services;
    }
}

