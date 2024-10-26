using Core.Feature.AccountFeature.UserLogin;

namespace ChatApp.Extensions
{
    public static class MediaRExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssembly(typeof(UserLoginHandler).Assembly);
            });

            return services;
        }
    }
}
