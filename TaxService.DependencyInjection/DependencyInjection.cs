using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Application.Interface;

namespace TaxService.Application;
public static class DependencyInjection
{
    public delegate ITaxCalculatorService ServiceResolver(string key);

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<TaxJarCalculatorService>();
        services.AddTransient<TaxJarCalculatorService2>();

        services.AddTransient<ServiceResolver>(serviceProvider => key =>
        {
            // Get the implementation tied to the key sent on the request
            var implementationKey = configuration[$"ImplementationKeys:{key}"];

            switch (implementationKey)
            {
                case "Implementation1":
                    return serviceProvider.GetService<TaxJarCalculatorService>();
                case "Implementation2":
                    return serviceProvider.GetService<TaxJarCalculatorService2>();
                default:
                    throw new KeyNotFoundException();
            }
        });

        return services;
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        var client = new HttpClient();
        client.BaseAddress = new System.Uri(configuration["Taxjar:apiurl"]);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration["Taxjar:APIKey"]}");

        services.AddSingleton(x => client);

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        System.Reflection.Assembly.GetExecutingAssembly()
          .GetTypes()
          .Where(item => item.GetInterfaces()
          .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IRequestValidator<>)) && !item.IsAbstract && !item.IsInterface)
          .ToList()
          .ForEach(assignedTypes =>
          {
              var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IRequestValidator<>));
              services.AddScoped(serviceType, assignedTypes);
          });
        return services;
    }
}

