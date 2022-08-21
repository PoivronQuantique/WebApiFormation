using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Repositories;

namespace SelfieAWookie.API.Extensions
{
    public static class DIMethodes
    {
        public static void AddInjections(this IServiceCollection services)
        {
           services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
        }
    }
}
