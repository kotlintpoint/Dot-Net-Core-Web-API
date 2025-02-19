using GetriWebApi.DataAccess;
using GetriWebApi.Models;
using GetriWebApi.Services;

namespace GetriWebApi.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication();
            services.AddScoped<TokenService>();

            return services;
        }
    }
}
