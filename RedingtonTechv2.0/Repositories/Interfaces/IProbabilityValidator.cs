using ReadingtonTech.Models.Interfaces;

namespace ReadingtonTech.Repositories.Interfaces;

public interface IProbabilityValidator
{
    public bool Validate(IProbabilityInput input, IProbabilityOutput output);
}