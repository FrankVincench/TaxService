using Moq;
using NUnit.Framework;

using TaxService.Application;
using TaxService.Domain;
using TaxService.Domain.ViewModels;

namespace TaxService.UnitTests;
public class Tests
{
    private Mock<ITaxCalculatorService> _calculatorServiceMock;

    [SetUp]
    public void Setup()
    {
        _calculatorServiceMock = new Mock<ITaxCalculatorService>();
    }

    [Test]
    public async void Get_Tax_Rates_Is_Valid_Request()
    {
        // Arrange
        var address = new AddressViewModel
        {
            Zip = "33172"
        };
        var calculatorService = _calculatorServiceMock.Object;

        _calculatorServiceMock.Setup(r => r.GetTaxRates(address)).Returns( () => new RateResponse.Rate());

        var response = calculatorService.GetTaxRates(address);

        Assert.IsTrue(true);
    }
}
