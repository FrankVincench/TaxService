namespace TaxService.Application;

using System.Text.Json;
using TaxService.Application.Interface;
using TaxService.Models;

public class TaxJarService : ITaxServiceRequest<TaxJarResultsv40>
{
    private readonly IConfigurationManager _configurationManager;
    private readonly IException _exceptionHandler;


    public TaxJarService(IConfigurationManager configurationManager, IException exceptionHandler)
    {
        _configurationManager = configurationManager;
        _exceptionHandler = exceptionHandler;
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
            try
            {
                _exceptionHandler.Handle(json.rCode);
            }
            catch (Exception e)
            {
               
            }
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
