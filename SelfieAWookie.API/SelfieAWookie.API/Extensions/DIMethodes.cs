using MediatR;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Repositories;
using System.Reflection;

namespace SelfieAWookie.API.Extensions
{
    public static class DIMethodes
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
