using Application.Activities;
using Application.Core;
using GetriWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GetriWebApi.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly)
            );
            services.AddAutoMapper(typeof(MappingProfile).Assembly);


            services.AddCors(opt => opt.AddPolicy(
                "CorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000")
                ));

            return services;
        }
    }
}
