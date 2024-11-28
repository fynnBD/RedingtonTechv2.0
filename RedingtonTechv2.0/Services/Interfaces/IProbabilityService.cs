
using RedingtonTechv2._0.Models.Interfaces;

namespace RedingtonTechv2._0.Services.Interfaces;

public interface IProbabilityService
{
    public Task<IProbabilityOutput> Combined(decimal? a, decimal? b);
    public Task<IProbabilityOutput> Either(decimal? a, decimal? b);
    public void SetLogging(bool setting);

}