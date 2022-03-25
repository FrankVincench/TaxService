using Microsoft.AspNetCore.Mvc;
using TaxService.Application;
using TaxService.Domain.ViewModels;

namespace TaxService.API.Controllers
{
    [ApiController]
    public class TaxCalculatorController : Controller
    {
        private readonly ITaxCalculatorService _service;
        public TaxCalculatorController(ITaxCalculatorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/taxCalculator/rates")]
        public async Task<IActionResult> GetRateByLocation(string zipCode, string? country, string? state, string? city, string? street)
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

                var tax = await _service.GetTaxRates(address);

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
    }
}
