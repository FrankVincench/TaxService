using TaxService.Application.Interface;
using TaxService.Domain.ViewModels;

namespace TaxService.Application.Implementation;

public class OrderViewModelValidation : IRequestValidator<OrderViewModel>
{
    public void ValidateModel(OrderViewModel order)
    {
        if (string.IsNullOrEmpty(order.to_country) || order.shipping < 0)
        {
            throw new InvalidOperationException("ZipCode is a required data");
        }

        if (!string.IsNullOrEmpty(order.to_country) && !order.IsValidToCountry())
        {
            throw new InvalidOperationException("Destination country is not a valid Code");
        }

        if ("us".Equals(order.to_country.ToLower()) && string.IsNullOrEmpty(order.to_zip))
        {
            throw new InvalidOperationException("ZipCode data is required when destination country is US");
        }

        if ("us".Equals(order.to_zip.ToLower()) && !order.IsValidToZip())
        {
            throw new InvalidOperationException("ZipCode data is not a valid US ZipCode");
        }

        if (("us".Equals(order.to_country.ToLower()) || "ca".Equals(order.to_country.ToLower())) && string.IsNullOrWhiteSpace(order.to_state))
        {
            throw new InvalidOperationException("Destination state is required whe Destination country is US or CA");
        }
    }
}
