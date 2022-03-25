namespace TaxService.Domain.ViewModels;

public record AddressViewModel : BaseViewModel
{
    public string? Country { get; set; } = "US";

    public string? Zip { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public bool IsValidZipCode()
    {
        return base.IsValidZipCode(Zip);
    }

    public bool IsValidCountry()
    {
        return base.IsValidCountry(Country);
    }
}
