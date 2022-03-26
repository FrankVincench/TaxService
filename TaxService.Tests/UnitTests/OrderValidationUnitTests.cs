using NUnit.Framework;
using System;
using TaxService.Application.Implementation;
using TaxService.Application.Interface;
using TaxService.Domain.ViewModels;

namespace TaxService.UnitTests;

public class OrderValidationUnitTests
{
    IRequestValidator<OrderViewModel> _addressValidator;

    [SetUp]
    public void Setup()
    {
        _addressValidator = new OrderViewModelValidation();
    }


    [Test]
    public void OrderViewModel_ValidModel_DoesNotThrowException()
    {
        // Arrange
        var vm = new OrderViewModel
        {
            to_country = "US",
            shipping = 100,
            to_zip = "33172",
            to_state = "Florida"
        };

        // Assert
        Assert.DoesNotThrow(() => _addressValidator.ValidateModel(vm));
    }

    [Test]
    public void OrderViewModel_CountryCodeMissing_throwsMissingCountryValidation()
    {
        // Arrange
        var vm = new OrderViewModel
        {
            shipping = 100
        };

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => _addressValidator.ValidateModel(vm));

        //Assert
        Assert.AreEqual(ex.Message, "Country field is required");
    }

    [Test]
    public void AddressViewModel_InvalidShipping_ThrowZipValidationException()
    {
        // Arrange
        var vm = new OrderViewModel
        {
           to_country = "US",
           shipping = -1
        };

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => _addressValidator.ValidateModel(vm));

        //Assert
        Assert.AreEqual(ex.Message, "Shipping cannot be less than zero");
    }
}
