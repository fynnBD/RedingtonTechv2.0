using NUnit.Framework;
using NUnit.Framework.Legacy;
using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Repositories;
using ReadingtonTech.Repositories.Interfaces;
using ReadingtonTech.Services;
using ReadingtonTech.Services.Interfaces;

namespace ReadingtonTech.Tests;

[TestFixture]
public class LoggerServiceTest
{
    private readonly IProbabilityValidator _validator = new ProbabilityValidator();
    private readonly IProbabilityCalculator _calculator = new ProbabilityCalculator();
    private readonly IProbabilityFactory _factory = new ProbabilityFactory();
    private readonly ILoggingService _loggingService = new LoggingService();
    private IProbabilityService _service;

    [SetUp]
    public void SetUp()
    {
        this._service = new ProbabilityService(_calculator, _validator, _factory, _loggingService);
        this._service.SetLogging(false);
    }

    [Test]
    [TestCase(1, 1, "1")]
    [TestCase(0, 0, "1")]
    [TestCase(.5, .5, "1")]
    [TestCase(1, .5, "1")]
    [TestCase(.000000001, .1, "1")]
    public async Task TestRawOutputCombine(decimal a, decimal b, string expectedValue)
    {
        IProbabilityOutput output = await _service.Combined(a, b);
        StringAssert.Contains($"{a},{b}", _loggingService.GetLogStringFromResult(output));
        StringAssert.Contains("Combine", _loggingService.GetLogStringFromResult(output));
    }

    [Test]
    [TestCase(1, 1, "1")]
    [TestCase(0, 0, "1")]
    [TestCase(.5, .5, "1")]
    [TestCase(1, .5, "1")]
    [TestCase(.000000001, .1, "1")]
    public async Task TestRawOutputEither(decimal a, decimal b, string expectedValue)
    {
        IProbabilityOutput output = await _service.Either(a, b);
        StringAssert.Contains($"{a},{b}", _loggingService.GetLogStringFromResult(output));
        StringAssert.Contains("Either", _loggingService.GetLogStringFromResult(output));
    }

    [Test]
    [TestCase(12, 1, $"first value (12) was outside of range (0 <= x <= 1)")]
    [TestCase(0, -12, "second value (-12) was outside of range (0 <= x <= 1)")]
    public async Task TestErrorLog(decimal a, decimal b, string expectedValue)
    {
        IProbabilityOutput output = await _service.Either(a, b);
        StringAssert.Contains(expectedValue, _loggingService.GetLogStringFromResult(output));
    }
}