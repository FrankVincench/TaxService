namespace TaxService.Application;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Application.Implementation;
using TaxService.Application.Interface;

public static class DependencyInjection
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddTransient<ITaxCalculatorService, TaxJarCalculatorService>();
        return services;
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        var taxJarConfiguration = configuration.GetSection("Taxjar");
        var client = new HttpClient();
        client.BaseAddress = new System.Uri(taxJarConfiguration.GetSection("apiurl").Value);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {taxJarConfiguration.GetSection("APIKey").Value}");

        services.AddTransient(x => client);

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

