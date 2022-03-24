namespace TaxService.Application;

using System.Text.Json;
using TaxService.Models;

public class TaxJarService : ITaxServiceRequest<TaxJarResultsv40>
{
    private readonly IConfigurationManager _configurationManager;

    public TaxJarService(IConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;
    }

    public TaxJarResponse<TaxJarResultsv40> GetTaxRates(string zip)
    {
        var uriBuilder = GetUriBuilder();
        uriBuilder.AddParameter("postalcode", zip);

        using (var client = new HttpClient())
        {
            var httpResponse = client.GetAsync(uriBuilder.Uri).Result;
            var responseValue = httpResponse.Content.ReadAsStringAsync().Result;

            //return responseValue;
            var json = JsonSerializer.Deserialize<TaxJarResponse<TaxJarResultsv40>>(responseValue);
            return json;
        }
    }


    private UriBuilderExt GetUriBuilder()
    {
        var config = _configurationManager.GetTaxJarConfiguration();
        var builder = new UriBuilderExt(Path.Combine(config.ApiUrl, config.APIVersion));
        builder.AddParameter("key", config.APIKey);

        return builder;
    }


}
