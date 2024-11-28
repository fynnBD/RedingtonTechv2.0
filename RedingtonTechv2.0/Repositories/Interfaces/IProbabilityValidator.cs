
using RedingtonTechv2._0.Models.Interfaces;

namespace RedingtonTechv2._0.Repositories.Interfaces;

public interface IProbabilityValidator
{
    public bool Validate(IProbabilityInput input, IProbabilityOutput output);
}