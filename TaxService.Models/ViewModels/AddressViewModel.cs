using System.Text.RegularExpressions;

namespace TaxService.Domain;

public record AddressViewModel
{
    /// <summary>
    /// Two-letter ISO country code for given location.
    /// </summary>
    public string Country { get; set; } = "US";

    /// <summary>
    /// Postal code for given location (5-Digit ZIP or ZIP+4).
    /// </summary>
    public string Zip { get; set; }

    /// <summary>
    /// Two-letter ISO state code for given location.
    /// </summary>
    public string State { get; set; }


    /// <summary>
    /// 	City for given location.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// 	Street address for given location
    /// </summary>
    public string Street { get; set; }


    public bool IsValidZipCode()
    {
        var usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        return Regex.Match(usZipRegEx, @"^[A-Z]{2}$").Success;
    }

    public bool IsValidCountry()
    {
        var twoLettersRegex = @"^[A-Z]{2}$";
        return Regex.Match(Country, twoLettersRegex).Success;
    }
}
