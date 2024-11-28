using RedingtonTechv2._0.Models.Interfaces;
using RedingtonTechv2._0.Repositories.Interfaces;
using RedingtonTechv2._0.Services.Interfaces;

namespace RedingtonTechv2._0.Services
{
    public class ProbabilityService : IProbabilityService
    {
        private IProbabilityCalculator _calculator;
        private IProbabilityValidator _validator;
        private IProbabilityFactory _factory;
        private ILoggingService _loggingService;

        private bool _loggingEnabled;

        public ProbabilityService(IProbabilityCalculator probabilityCalculator, 
                                  IProbabilityValidator probabilityValidator, 
                                  IProbabilityFactory probabilityFactory,
                                  ILoggingService loggingService)
        {
            this._validator = probabilityValidator;
            this._calculator = probabilityCalculator;
            this._factory = probabilityFactory;
            this._loggingService = loggingService;

            this._loggingEnabled = true;
        }

        //Either and Validate
        public async Task<IProbabilityOutput> Either(decimal? a, decimal? b)
        {
            //create input and output objects, output will have errorlist string to append to
            IProbabilityInput input = _factory.CreateProbabilityInput(a, b);
            IProbabilityOutput output = _factory.CreateProbabilityOutput(a, b, CalculationType.Either);

            if (_validator.Validate(input, output))
            {
                _calculator.Either(input, output);
            }

            if (_loggingEnabled)
            {
                await _loggingService.LogResult(output);
            }

            return output;
        }

        //Combine and Validate
        public async Task<IProbabilityOutput> Combined(decimal? a, decimal? b)
        {
            IProbabilityInput input = _factory.CreateProbabilityInput(a, b);
            IProbabilityOutput output = _factory.CreateProbabilityOutput(a, b, CalculationType.Combine);

            if (_validator.Validate(input, output))
            {
                _calculator.CombinedWith(input, output);
            }

            if (_loggingEnabled)
            {
                await _loggingService.LogResult(output);
            }

            return output;
        }

        public void SetLogging(bool setting)
        {
            this._loggingEnabled = setting;
        }
    }

    public enum CalculationType
    {
        Combine,
        Either
    }
}