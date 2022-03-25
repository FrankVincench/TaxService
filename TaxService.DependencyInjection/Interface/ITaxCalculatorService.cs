using TaxService.Domain;
namespace TaxService.Application;

using TaxService.Domain.ViewModels;

public interface ITaxCalculatorService
{
    Task<RateResponse.Rate> GetTaxRates(AddressViewModel vm);
    void CalculateTaxForOrder();
}
