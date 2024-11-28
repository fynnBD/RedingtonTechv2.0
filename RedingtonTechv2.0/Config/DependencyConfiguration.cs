using ReadingtonTech.Repositories.Interfaces;
using ReadingtonTech.Repositories;
using ReadingtonTech.Services.Interfaces;
using ReadingtonTech.Services;

namespace ReadingtonTech.Config
{
    public static class DependencyConfiguration
    {
        public static void ConfigureDependency(IServiceCollection services)
        {
            services.AddTransient<IProbabilityCalculator, ProbabilityCalculator>();
            services.AddScoped<ILoggingService, LoggingService>();
            services.AddScoped<IProbabilityValidator, ProbabilityValidator>();
            services.AddScoped<IProbabilityFactory, ProbabilityFactory>();
            services.AddScoped<IProbabilityService, ProbabilityService>();
        }
    }
}
