using RedingtonTechv2._0.Repositories;
using RedingtonTechv2._0.Repositories.Interfaces;
using RedingtonTechv2._0.Services;
using RedingtonTechv2._0.Services.Interfaces;

namespace RedingtonTechv2._0.Config
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
