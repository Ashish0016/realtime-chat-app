using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddDataAccessExtension(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ChatAppContext>(option =>
            {
                option.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    option => option.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null)
                );
            })
            .AddScoped<DbContext, ChatAppContext>();

            services
                .AddIdentityCore<User>(option =>
                {
                    option.Password.RequireDigit = true;
                    option.Password.RequireUppercase = true;
                    option.Password.RequireLowercase = true;
                    option.Password.RequiredLength = 10;
                    option.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ChatAppContext>();

            return services;
        }
    }
}
