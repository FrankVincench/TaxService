using System.Text.RegularExpressions;

namespace TaxService.Domain.ViewModels;
public record BaseViewModel
{
    protected bool IsValidZipCode(string zip)
    {
        var usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        return Regex.Match(zip, usZipRegEx, RegexOptions.IgnoreCase).Success;
    }

    protected bool IsValidCountry(string country)
    {
        var twoLettersRegex = @"^[A-Z]{2}$";
        return Regex.Match(country, twoLettersRegex,RegexOptions.IgnoreCase).Success;
    }
}
