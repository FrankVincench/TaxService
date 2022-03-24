namespace TaxService.Models;

public record TaxJarConfiguration
{
    public string? ApiUrl { get; set; }
    public string? APIKey { get; set; }
    public string? APIVersion { get; set; }
}
