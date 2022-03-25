using TaxService.Domain;

namespace TaxService.Application;

public interface ITaxCalculatorService
{
    Task<Rate> GetTaxRates(AddressViewModel vm);
    void CalculateTaxForOrder();
}
