using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SelfieAWookie.Core.Selfies.Infrastructures.Configurations;

namespace SelfieAWookie.API.Extensions
{
    public static class SecuriteMethodes
    {
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomCors(configuration);
            services.AddCustomAuthentication(configuration);

        }
        private static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            OptionSecurite optionSecu = new OptionSecurite();
            configuration.GetSection("Jwt").Bind(optionSecu);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                string maCleSecurite = optionSecu.Key;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(maCleSecurite))
                };
            });
        }
        private static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            OptionCors optionCors = new OptionCors();
            configuration.GetSection("Cors").Bind(optionCors);

            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    //builder.WithOrigins(optionCors.Origin)
                    //        .AllowAnyHeader()
                    //        .AllowAnyMethod();
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });
        }
    }
}
