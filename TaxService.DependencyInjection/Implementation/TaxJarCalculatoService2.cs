using System.Text;
using System.Text.Json;
using TaxService.Application.Exceptions;
using TaxService.Application.Interface;
using TaxService.Domain;
using TaxService.Domain.ViewModels;

namespace TaxService.Application;

public class TaxJarCalculatorService2 : ITaxCalculatorService
{
    public TaxJarCalculatorService2() { }

    public async Task<OrderResponse> CalculateTaxForOrder(OrderViewModel orderVm)
    {
        throw new NotImplementedException();
    }

    public async Task<RateResponse.Rate> GetTaxRates(AddressViewModel addressvm)
    {
        throw new NotImplementedException();
    }
}
