using System.Net;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using RedingtonTechv2._0.Services;
using RedingtonTechv2._0.Repositories;
using RedingtonTechv2._0.Controllers;

namespace RedingtonTechv2._0.Tests
{
    [TestFixture]
    public class ProbabilityControllerTest
    {
        private readonly ProbabilityValidator _validator = new ProbabilityValidator();
        private readonly ProbabilityCalculator _calculator = new ProbabilityCalculator();
        private readonly ProbabilityFactory _factory = new ProbabilityFactory();
        private readonly LoggingService _loggingService = new LoggingService();
        private ProbabilityController _controller;

        [SetUp]
        public void SetUp()
        {
            this._controller = new ProbabilityController(new ProbabilityService(_calculator, _validator, _factory, _loggingService));
        }

        [Test]
        [TestCase(1, 1, false)]
        [TestCase(0.5, 0.5, false)]
        [TestCase(null, 1, true)]
        [TestCase(1, null, true)]
        [TestCase(2, 1, true)]
        [TestCase(1, 2, true)]
        [TestCase(-1, 1, true)]
        [TestCase(1, -1, true)]
        [TestCase(-0.000000001, 1, true)]
        [TestCase(1, -0.0000000001, true)]
        public async Task TestCombined(decimal? a, decimal? b, bool expectedFailed)
        {
            var output = await _controller.Combine(a, b);
            Assert.That(output, Is.Not.Null);
            Assert.That(output, Is.InstanceOf(typeof(ObjectResult)));
            ObjectResult? result = (output as ObjectResult);

            if (expectedFailed)
            {
                if (result != null) Assert.That(HttpStatusCode.BadRequest, Is.EqualTo((HttpStatusCode)result.StatusCode));
            }
            else
            {
                if (result != null) Assert.That(HttpStatusCode.OK, Is.EqualTo((HttpStatusCode)result.StatusCode));
            }
        }

        [Test]
        [TestCase(1, 1, false)]
        [TestCase(0.5, 0.5, false)]
        [TestCase(null, 1, true)]
        [TestCase(1, null, true)]
        [TestCase(2, 1, true)]
        [TestCase(1, 2, true)]
        [TestCase(-1, 1, true)]
        [TestCase(1, -1, true)]
        [TestCase(-0.000000001, 1, true)]
        [TestCase(1, -0.0000000001, true)]
        public async Task TestEither(decimal? a, decimal? b, bool expectedFailed)
        {
            var output = await _controller.Either(a, b);
            Assert.That(output, Is.Not.Null);
            Assert.That(output, Is.InstanceOf(typeof(ObjectResult)));
            ObjectResult result = (output as ObjectResult);

            if (expectedFailed)
            {
                Assert.That(HttpStatusCode.BadRequest, Is.EqualTo((HttpStatusCode)result.StatusCode));
            }
            else
            {
                Assert.That(HttpStatusCode.OK, Is.EqualTo((HttpStatusCode)result.StatusCode));
            }
        }

        [Test]
        public async Task Test_Either_Max_Value()
        {
            var output = await _controller.Either(Decimal.MaxValue, 1);
            Assert.That(output, Is.Not.Null);
            Assert.That(output, Is.InstanceOf(typeof(ObjectResult)));
            ObjectResult result = (output as ObjectResult);
            
            Assert.That(HttpStatusCode.BadRequest, Is.EqualTo((HttpStatusCode)result.StatusCode));
        }

        [Test]
        public async Task Test_Either_Min_Value()
        {
            var output = await _controller.Either(Decimal.MaxValue, 1);
            Assert.That(output, Is.Not.Null);
            Assert.That(output, Is.InstanceOf(typeof(ObjectResult)));
            ObjectResult result = (output as ObjectResult);

            Assert.That(HttpStatusCode.BadRequest, Is.EqualTo((HttpStatusCode)result.StatusCode));
        }

        [Test]
        public async Task Test_Combined_Max_Value()
        {
            var output = await _controller.Combine(Decimal.MaxValue, 1);
            Assert.That(output, Is.Not.Null);
            Assert.That(output, Is.InstanceOf(typeof(ObjectResult)));
            ObjectResult result = (output as ObjectResult);

            Assert.That(HttpStatusCode.BadRequest, Is.EqualTo((HttpStatusCode)result.StatusCode));
        }

        [Test]
        public async Task Test_Combined_Min_Value()
        {
            var output = await _controller.Combine(Decimal.MaxValue, 1);
            Assert.That(output, Is.Not.Null);
            Assert.That(output, Is.InstanceOf(typeof(ObjectResult)));
            ObjectResult result = (output as ObjectResult);

            Assert.That(HttpStatusCode.BadRequest, Is.EqualTo((HttpStatusCode)result.StatusCode));
        }
    }
}
