namespace TaxService.Application;

public interface ITaxCalculator
{
    void GetTaxRates(string zipCode);
    void CalculateTaxForOrder();
}
