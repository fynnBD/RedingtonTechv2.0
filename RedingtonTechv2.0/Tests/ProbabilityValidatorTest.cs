using NUnit.Framework;
using RedingtonTechv2._0.Models;
using RedingtonTechv2._0.Models.Interfaces;
using RedingtonTechv2._0.Repositories;
using RedingtonTechv2._0.Repositories.Interfaces;

namespace RedingtonTechv2._0.Tests;

[TestFixture]
public class ProbabilityValidatorTest
{
    private IProbabilityValidator _validator;

    [SetUp]
    public void SetUp()
    {
        this._validator = new ProbabilityValidator();
    }

    [Test]
    [TestCase(null, null, false, "one of the inputs was null")]
    [TestCase(1, null, false, "one of the inputs was null")]
    [TestCase(null, 1, false, "one of the inputs was null")]
    [TestCase(1.0, 1.0, true, "")]
    [TestCase(1, 0.0, true, "")]
    [TestCase(-0.000001, 1, false, "first value (-0.000001) was outside of range (0 <= x <= 1)")]
    [TestCase(1, -0.000001, false, "second value (-0.000001) was outside of range (0 <= x <= 1)")]
    [TestCase(1, 2, false, "second value (2) was outside of range (0 <= x <= 1)")]
    [TestCase(2, 1, false, "first value (2) was outside of range (0 <= x <= 1)")]
    public void TestValidator(decimal? a, decimal? b, bool expectedValue, string errorMessage)
    {
        IProbabilityInput input = new ProbablilityInput() { A = a, B = b };
        IProbabilityOutput output = new ProbabilityOutput();
        bool valid = this._validator.Validate(input, output);
        Assert.That(expectedValue, Is.EqualTo(valid));

        if (!expectedValue)
        {
            Assert.That(errorMessage, Is.EqualTo(output.errorReason));
        }
    }



}