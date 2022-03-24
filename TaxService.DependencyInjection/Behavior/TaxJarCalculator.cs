namespace TaxService.Application;

using TaxService.Models;

public class TaxJarCalculator : ITaxCalculator
{
    private readonly ITaxServiceRequest<TaxJarResultsv40> _taxService;

    public TaxJarCalculator(ITaxServiceRequest<TaxJarResultsv40> taxService)
    {
        _taxService = taxService;
    }

    public void CalculateTaxForOrder()
    {
        //throw new NotImplementedException();
    }

    public void GetTaxRates(string zipCode)
    {
        var rates = _taxService.GetTaxRates(zipCode);
        //throw new NotImplementedException();
    }
}
