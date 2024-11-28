
using RedingtonTechv2._0.Models.Interfaces;

namespace RedingtonTechv2._0.Repositories.Interfaces
{
    public interface IProbabilityCalculator
    {
        public IProbabilityOutput CombinedWith(IProbabilityInput input, IProbabilityOutput outpu);

        public IProbabilityOutput Either(IProbabilityInput input, IProbabilityOutput output);
    }
}
