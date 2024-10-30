using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChatApp.Extensions
{
    public static class AuthExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            string key = configuration.GetSection("JwtConfigurations:key").Get<string>() ?? string.Empty;
            IEnumerable<string> issuers = configuration.GetSection("JwtConfigurations:Issuer").Get<IEnumerable<string>>() ?? Enumerable.Empty<string>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     RequireAudience = true,
                     RequireExpirationTime = true,
                     ValidIssuers = issuers,
                     ValidAudiences = issuers,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                 };
             });

            return services;
        }
    }
}
