using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Repositories.Interfaces;

namespace ReadingtonTech.Repositories
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public IProbabilityOutput CombinedWith(IProbabilityInput input, IProbabilityOutput output)
        {
            decimal? result = (input.A * input.B);
            return UpdateResponse(output, result);
        }

        public IProbabilityOutput Either(IProbabilityInput input, IProbabilityOutput output)
        {
            decimal? result = (input.A + input.B) - (input.A * input.B);
            return UpdateResponse(output, result);
        }

        private IProbabilityOutput UpdateResponse(IProbabilityOutput output, decimal? result)
        {
            output.result = result ?? 0;
            return output;
        }
    }
}
