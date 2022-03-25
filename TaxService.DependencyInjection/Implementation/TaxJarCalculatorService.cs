using System.Text;
using System.Text.Json;
using TaxService.Application.Exceptions;
using TaxService.Application.Interface;
using TaxService.Domain;
using TaxService.Domain.ViewModels;

namespace TaxService.Application;

public class TaxJarCalculatorService : ITaxCalculatorService
{
    private readonly HttpClient _client;
    private readonly IRequestValidator<AddressViewModel> _adressValidator;
    private readonly IRequestValidator<OrderViewModel> _orderValidator;

    public TaxJarCalculatorService(HttpClient client,
        IRequestValidator<AddressViewModel> adressValidator,
        IRequestValidator<OrderViewModel> orderValidator)
    {
        _client = client;
        _adressValidator = adressValidator;
        _orderValidator = orderValidator;
    }

    public async Task<OrderResponse> CalculateTaxForOrder(OrderViewModel orderVm)
    {
        _orderValidator.ValidateModel(orderVm);

        var content = JsonSerializer.Serialize(orderVm);

        var requestResponse = await _client.PostAsync("taxes",
            new StringContent(content, Encoding.UTF8, "application/json"));

        // Let's ensure our request was sucesful.
        if (requestResponse.IsSuccessStatusCode)
        {
            var responseValue = requestResponse.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<OrderResponse>(responseValue);
        }

        throw new TaxJarResponseException();
    }

    public async Task<RateResponse.Rate> GetTaxRates(AddressViewModel addressvm)
    {
        _adressValidator.ValidateModel(addressvm);

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

        // Let's ensure our request was sucesful.
        if (requestResponse.IsSuccessStatusCode)
        {
            var responseValue = requestResponse.Content.ReadAsStringAsync().Result;
            var result = JsonSerializer.Deserialize<RateResponse>(responseValue);
            return result.rate;
        }
        throw new TaxJarResponseException();
    }
}
