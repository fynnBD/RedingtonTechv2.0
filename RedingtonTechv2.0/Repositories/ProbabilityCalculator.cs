
using RedingtonTechv2._0.Models.Interfaces;
using RedingtonTechv2._0.Repositories.Interfaces;

namespace RedingtonTechv2._0.Repositories
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public IProbabilityOutput CombinedWith(IProbabilityInput input, IProbabilityOutput output)
        {
            // self - explanatory, formula is (a + b)
            decimal? result = (input.A * input.B);
            return UpdateResponse(output, result);
        }

        public IProbabilityOutput Either(IProbabilityInput input, IProbabilityOutput output)
        {
            //self-explanatory, formula is (a+b)-(a*b)
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
