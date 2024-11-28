using RedingtonTechv2._0.Models.Interfaces;

namespace RedingtonTechv2._0.Services.Interfaces
{
    public interface ILoggingService
    {
        public Task LogResult(IProbabilityOutput result);
        public string GetLogStringFromResult(IProbabilityOutput result);
    }
}
