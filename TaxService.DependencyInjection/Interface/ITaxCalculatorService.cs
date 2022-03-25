using TaxService.Domain;
using TaxService.Domain.ViewModels;

namespace TaxService.Application;
public interface ITaxCalculatorService
{
    Task<RateResponse.Rate> GetTaxRates(AddressViewModel address);
    Task<OrderResponse> CalculateTaxForOrder(OrderViewModel order);
}
