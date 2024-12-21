using Core.MappingConfigurations;
using Core.Services.AuthService;
using Core.Services.UserService;
using DataAccess.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CoreExtensions
{
    public static class CoreExtension
    {
        public static IServiceCollection CoreExtensions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddDataAccessExtension(configuration)
                .AddAutoMapper(typeof(UserMapperConfigurations).Assembly);

            services.AddHttpContextAccessor();

            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
