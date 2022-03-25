using TaxService.Application.Interface;
using TaxService.Domain.ViewModels;

namespace TaxService.Application.Implementation;

public class AddressViewModelValidator : IRequestValidator<AddressViewModel>
{
    public void ValidateModel(AddressViewModel vm)
    {
        if (string.IsNullOrEmpty(vm.Zip))
        {
            throw new InvalidOperationException("ZipCode a required");
        }

        if ("US".Equals(vm.Country?.ToUpper()) && !vm.IsValidZipCode())
        {
            throw new InvalidOperationException("ZipCode provided is not a valid US ZipCode.");
        }

        if (!string.IsNullOrEmpty(vm?.Country) && !vm.IsValidCountry())
        {
            throw new InvalidOperationException("Country code is not valid.");
        }
    }
}
