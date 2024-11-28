using ReadingtonTech.Models.Interfaces;

namespace ReadingtonTech.Services.Interfaces
{
    public interface ILoggingService
    {
        public Task LogResult(IProbabilityOutput result);
        public string GetLogStringFromResult(IProbabilityOutput result);
    }
}
