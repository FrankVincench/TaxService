namespace TaxService.Application;

using TaxService.Models;

public interface ITaxServiceRequest<T>
{
    public TaxJarResponse<T> GetTaxRates(string zip);
}
