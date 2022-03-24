namespace TaxService.Application;

using TaxService.Models;

public interface IConfigurationManager
{
    public TaxJarConfiguration GetTaxJarConfiguration();
}
