namespace TaxService.Models;

public record TaxJarResultsv40 : TaxJarResultsV20
{
    public decimal? district1SalesTax { get; set; }
    public decimal? district1UseTax { get; set; }
    public string? district2Code { get; set; }
    public decimal? district2SalesTax { get; set; }
    public string? district3Code { get; set; }
    public decimal? district3SalesTax { get; set; }
    public decimal? district3UseTax { get; set; }
    public string? district4Code { get; set; }
    public decimal? district4SalesTax { get; set; }
    public decimal? district4UseTax { get; set; }
    public string? district5Code { get; set; }
    public decimal? district5SalesTax { get; set; }
    public decimal? district5UseTax { get; set; }
    public string? originDestination { get; set; }
}
