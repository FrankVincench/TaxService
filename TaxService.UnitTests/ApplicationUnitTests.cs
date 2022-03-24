using Moq;
using NUnit.Framework;
using System;
using TaxService.Application;
using TaxService.Models;

namespace TaxService.UnitTests;
public class Tests
{
    private Mock<IConfigurationManager> _configurationManager;
    private Mock<ITaxServiceRequest<TaxJarResultsv40>> _taxServiceRequest;

    [SetUp]
    public void Setup()
    {
        _configurationManager = new Mock<IConfigurationManager>();
        _taxServiceRequest = new Mock<ITaxServiceRequest<TaxJarResultsv40>>();
    }

    [Test]
    public void Should_Load_TaxJar_Configuration()
    {
        //_taxServiceRequest.Setup(x => x.GetTaxRates("33172").results == new System.Collections.Generic.List<TaxJarResultsv40>());
        //var taxServiceMock = new Mock<ITaxServiceRequest>();

        var configuration = new ConfigurationManager();
        var service = new TaxJarService(configuration);
        var taxCalculator = new TaxJarCalculator(service);


        //taxServiceMock.Setup(m => m.GetTaxRates("33172"));

        taxCalculator.GetTaxRates("33172");

        Assert.IsTrue(true);
    }
}
