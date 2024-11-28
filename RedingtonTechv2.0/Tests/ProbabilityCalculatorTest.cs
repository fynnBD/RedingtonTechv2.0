using NUnit.Framework;
using RedingtonTechv2._0.Models;
using RedingtonTechv2._0.Models.Interfaces;
using RedingtonTechv2._0.Repositories;
using RedingtonTechv2._0.Repositories.Interfaces;

namespace RedingtonTechv2._0.Tests;

[TestFixture]
public class ProbabilityCalculatorTest
{
    private IProbabilityCalculator _calculator;

    [SetUp]
    public void SetUp()
    {
        this._calculator = new ProbabilityCalculator();
    }

    [Test]
    [TestCase(1, 1, 1)]
    [TestCase(0, 0, 0)]
    [TestCase(.5, .5, 0.25)]
    [TestCase(1, .5, 0.5)]
    [TestCase(.000000001, .1, 0.0000000001)]
    public void TestCombined(decimal a, decimal b, decimal expectedValue)
    {
        IProbabilityInput input = new ProbablilityInput(){A = a, B = b};
        IProbabilityOutput output = new ProbabilityOutput();
        output = this._calculator.CombinedWith(input, output);
        Assert.That(expectedValue, Is.EqualTo(output.result));
    }

    [Test]
    [TestCase(1, 1, 1)]
    [TestCase(0, 0, 0)]
    [TestCase(.5, .5, .75)]
    [TestCase(1, .5, 1)]
    [TestCase(.000000001, .1, 0.1000000009)]

    public void TestEither(decimal a, decimal b, decimal expectedValue)
    {
        IProbabilityInput input = new ProbablilityInput() { A = a, B = b };
        IProbabilityOutput output = new ProbabilityOutput();
        output = this._calculator.Either(input, output);
        Assert.That(expectedValue, Is.EqualTo(output.result));
    }



}