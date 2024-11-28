using ReadingtonTech.Models.Interfaces;

namespace ReadingtonTech.Repositories.Interfaces
{
    public interface IProbabilityCalculator
    {
        public IProbabilityOutput CombinedWith(IProbabilityInput input, IProbabilityOutput outpu);

        public IProbabilityOutput Either(IProbabilityInput input, IProbabilityOutput output);
    }
}
