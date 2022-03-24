namespace TaxService.Models;

public record TaxJarResponse<T>
{
    public string version { get; set; }
    public int rCode { get; set; }
    public List<T> results { get; set; }
}

