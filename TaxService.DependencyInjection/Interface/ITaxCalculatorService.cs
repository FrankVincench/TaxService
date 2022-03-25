using TaxService.Domain;

namespace TaxService.Application;

public interface ITaxCalculatorService
{
    Task<RateResponse.Rate> GetTaxRates(AddressViewModel vm);
    void CalculateTaxForOrder();
}
