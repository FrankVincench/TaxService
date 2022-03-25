using System.Text.Json;
using TaxService.Application.Interface;
using TaxService.Domain;

namespace TaxService.Application;

public class TaxJarCalculatorService : ITaxCalculatorService
{
    private readonly HttpClient _client;
    private readonly IRequestValidator<AddressViewModel> _validator;

    public TaxJarCalculatorService(HttpClient client,IRequestValidator<AddressViewModel> validator)
    {
        _client = client;
        _validator = validator;
    }

    public void CalculateTaxForOrder()
    {
        throw new NotImplementedException();
    }

    public async Task<Rate> GetTaxRates(AddressViewModel addressvm)
    {
        _validator.ValidateModel(addressvm);

        var requestMsg = new HttpRequestMessage(HttpMethod.Get, Path.Combine("rates", addressvm.Zip));

        foreach (var prop in addressvm.GetType().GetProperties())
        {
            var propName = prop.Name;
            var propValue = prop.GetValue(addressvm);
            if (propValue != null)
            {
                requestMsg.Headers.Add(propName.ToLower(), propValue.ToString());
            }
        }

        var requestResponse = await _client.SendAsync(requestMsg);
        var responseValue = requestResponse.Content.ReadAsStringAsync().Result;
        var result = JsonSerializer.Deserialize<RateResponse>(responseValue);

        return result.rate;
    }
}
