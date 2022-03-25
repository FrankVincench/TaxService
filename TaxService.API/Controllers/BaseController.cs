using Microsoft.AspNetCore.Mvc;
using TaxService.Application;
using TaxService.Domain.ViewModels;
using static TaxService.Application.DependencyInjection;

namespace TaxService.API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected string GetClientId(HttpRequest request)
    {
        if (request.Headers.ContainsKey("ClientId"))
        {
            return request.Headers["ClientId"];
        }
        return null;
    }
}
