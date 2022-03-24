namespace TaxService.Models;

public abstract record TaxJarResultsV20 : TaxJarResult
{
    public decimal? stateSalesTax { get; set; }
    public decimal? stateUseTax { get; set; }
    public decimal? citySalesTax { get; set; }
    public decimal? cityUseTax { get; set; }
    public string? cityTaxCode { get; set; }
    public decimal? countySalesTax { get; set; }
    public decimal? countyUseTax { get; set; }
    public string? countyTaxCode { get; set; }
    public decimal? districtSalesTax { get; set; }
    public decimal? districtUseTax { get; set; }
}


