using NUnit.Framework;
using System;
using System.Net.Http;
using TaxService.Application;
using TaxService.Application.Implementation;
using TaxService.Domain.ViewModels;

namespace TaxService.IntegrationTests;
public class TaxJarCalculatorTests
{
    private ITaxCalculatorService _taxCalculatorService;

    [SetUp]
    public void Setup()
    {
        var client = new HttpClient();
        client.BaseAddress = new System.Uri("https://api.taxjar.com/v2/");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer 5da2f821eee4035db4771edab942a4cc");

        _taxCalculatorService = new TaxJarCalculatorService(client, new AddressViewModelValidator(), null);
    }

    [Test]
    public void GetTaxRates_IsValidInput_ReturnsValidResponse()
    {
        // Arrange
        var vm = new AddressViewModel()
        {
            Zip = "33172",
            Country = "US"
        };

        //act
        var response = _taxCalculatorService.GetTaxRates(vm).Result;

        //assert
        Assert.AreEqual(response.zip, "33172");
    }

    [Test]
    public void GetTaxRates_ZipMissing_ThrowsRequiredZipException()
    {
        // Arrange
        var vm = new AddressViewModel
        {
            City = "Miami",
            Country = "US",
            State = "Fl",
            Street = "Street",
        };

        //Act
        var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _taxCalculatorService.GetTaxRates(vm));

        //Assert
        Assert.AreEqual(ex.Message, "ZipCode is required");
    }
}
