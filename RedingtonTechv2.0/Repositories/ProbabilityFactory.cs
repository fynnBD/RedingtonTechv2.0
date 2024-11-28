using RedingtonTechv2._0.Models;
using RedingtonTechv2._0.Models.Interfaces;
using RedingtonTechv2._0.Repositories.Interfaces;
using RedingtonTechv2._0.Services;

namespace RedingtonTechv2._0.Repositories
{
    public class ProbabilityFactory : IProbabilityFactory
    {
        public IProbabilityInput CreateProbabilityInput(decimal? a, decimal? b)
        {
            return new ProbablilityInput() { A = a, B = b };
        }

        public IProbabilityOutput CreateProbabilityOutput(decimal? a, decimal? b, CalculationType type)
        {
            return new ProbabilityOutput() { Values = [a ?? 0, b ?? 0], CalculationType = type };
        }
    }
}
