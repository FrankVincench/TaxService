namespace TaxService.Application;

using System.Text.Json;
using TaxService.Models;

public class ConfigurationManager : IConfigurationManager
{
    public TaxJarConfiguration GetTaxJarConfiguration()
    {
        var configurationValues = File.ReadAllText("appsettings.json");
        var taxJarConfiguration = JsonSerializer.Deserialize<Configuration>(configurationValues)?.TaxJar;

        return taxJarConfiguration ?? new TaxJarConfiguration();
    }
}
