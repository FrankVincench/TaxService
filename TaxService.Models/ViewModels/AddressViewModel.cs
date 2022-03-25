namespace TaxService.Domain.ViewModels;

public record AddressViewModel : BaseViewModel
{
    /// <summary>
    /// Two-letter ISO country code for given location.
    /// </summary>
    public string? Country { get; set; } = "US";

    /// <summary>
    /// Postal code for given location (5-Digit ZIP or ZIP+4).
    /// </summary>
    public string? Zip { get; set; }

    /// <summary>
    /// Two-letter ISO state code for given location.
    /// </summary>
    public string? State { get; set; }


    /// <summary>
    /// 	City for given location.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// 	Street address for given location
    /// </summary>
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
