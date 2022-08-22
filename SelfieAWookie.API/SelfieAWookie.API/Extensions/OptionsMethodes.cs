using SelfieAWookie.Core.Selfies.Infrastructures.Configurations;

namespace SelfieAWookie.API.Extensions
{
    public static class OptionsMethodes
    {
        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OptionSecurite>(configuration.GetSection("Jwt"));
            services.Configure<OptionCors>(configuration.GetSection("Cors"));
            
            return services;
        }
    }
}
