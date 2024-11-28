using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Services;

namespace ReadingtonTech.Repositories.Interfaces;

public interface IProbabilityFactory
{
   public IProbabilityInput CreateProbabilityInput(decimal? a, decimal? b);

   public IProbabilityOutput CreateProbabilityOutput(decimal? a, decimal? b, CalculationType type);
}