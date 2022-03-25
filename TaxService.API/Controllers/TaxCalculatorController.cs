using Microsoft.AspNetCore.Mvc;
using TaxService.Application;
using TaxService.Domain.ViewModels;
using static TaxService.Application.DependencyInjection;

namespace TaxService.API.Controllers;

[ApiController]
public class TaxCalculatorController : BaseController
{
    private readonly ServiceResolver _serviceResolver;
    public TaxCalculatorController(ServiceResolver service)
    {
        _serviceResolver = service;
    }

    [HttpGet]
    [Route("api/taxCalculator/rates")]
    public async Task<IActionResult> GetRates(string zipCode, string? country, string? state, string? city, string? street)
    {
        try
        {
            var address = new AddressViewModel
            {
                Zip = zipCode,
                Country = country,
                City = city,
                Street = street,
                State = state
            };

            var taxCalculatorService = _serviceResolver(GetClientId(Request));
            var tax = await taxCalculatorService.GetTaxRates(address);

            return Ok(tax);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("api/taxCalculator/CalculateOrderTax")]
    public async Task<IActionResult> CalculateTaxForOrder(OrderViewModel order)
    {
        try
        {
            var taxCalculatorService = _serviceResolver(GetClientId(Request));
            var result = await taxCalculatorService.CalculateTaxForOrder(order);

            return Ok(result);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
