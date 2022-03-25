using NUnit.Framework;
using System;
using TaxService.Application.Implementation;
using TaxService.Application.Interface;
using TaxService.Domain.ViewModels;

namespace TaxService.UnitTests;

public class AddressValidationUnitTests
{
    IRequestValidator<AddressViewModel> _addressValidator;

    [SetUp]
    public void Setup()
    {
        _addressValidator = new AddressViewModelValidator();
    }

    [Test]
    public void AddressViewModel_IsZipMissing_ThrowZipValidationException()
    {
        // Arrange
        var vm = new AddressViewModel
        {
            City = "Miami",
            Country = "US",
            State = "Fl",
            Street = "Street",
        };

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => _addressValidator.ValidateModel(vm));

        //Assert
        Assert.AreEqual(ex.Message, "ZipCode is required");
    }

    [Test]
    public void AddressViewModel_InvalidUSZipProvided_ThrowZipValidationException()
    {
        // Arrange
        var vm = new AddressViewModel
        {
            Zip = "3317252",
            Country = "US"
        };

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => _addressValidator.ValidateModel(vm));

        //Assert
        Assert.AreEqual(ex.Message, "ZipCode provided is not a valid US ZipCode.");
    }

    [Test]
    public void AddressViewModel_InvalidCountryCodeProvided_ThrowCountryValidationException()
    {
        // Arrange
        var vm = new AddressViewModel
        {
            Zip = "33172",
            Country = "United States"
        };

        // Act
        var ex = Assert.Throws<InvalidOperationException>(() => _addressValidator.ValidateModel(vm));

        //Assert
        Assert.AreEqual(ex.Message, "Country code is not valid.");
    }

    [Test]
    public void AddressViewModel_IsValidUsZipProvided_DoesNotThrowException()
    {
        // Arrange
        var vm = new AddressViewModel
        {
            Zip = "33172",
        };

        Assert.DoesNotThrow(() => _addressValidator.ValidateModel(vm));
    }
}
