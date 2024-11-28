
using RedingtonTechv2._0.Models.Interfaces;
using RedingtonTechv2._0.Services;

namespace RedingtonTechv2._0.Repositories.Interfaces;

public interface IProbabilityFactory
{
   public IProbabilityInput CreateProbabilityInput(decimal? a, decimal? b);

   public IProbabilityOutput CreateProbabilityOutput(decimal? a, decimal? b, CalculationType type);
}