using ReadingtonTech.Models;
using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Repositories.Interfaces;
using ReadingtonTech.Services;

namespace ReadingtonTech.Repositories
{
    public class ProbabilityFactory : IProbabilityFactory
    {
        public IProbabilityInput CreateProbabilityInput(decimal? a, decimal? b)
        {
            return new ProbablilityInput() { A = a, B = b };
        }

        public IProbabilityOutput CreateProbabilityOutput(decimal? a, decimal? b, CalculationType type)
        {
            return new ProbabilityOutput() { Values = [a ?? 0,b ?? 0], CalculationType = type};
        }
    }
}
