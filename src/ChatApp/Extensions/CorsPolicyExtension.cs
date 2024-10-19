using ChatApp.Constants;

namespace ChatApp.Extensions
{
    public static class CorsPolicyExtension
    {
        public static IServiceCollection AddApiCorsPolicy(this IServiceCollection serviecs)
        {
            serviecs.AddCors(option =>
            {
                option.AddPolicy(name: GlobalConstant.CorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            return serviecs;
        }
    }
}
