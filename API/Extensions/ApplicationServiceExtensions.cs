using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Add a service for DbContext using SQLite as the database provider
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            // Add cross-origin resource sharing (CORS) services to the service collection
            services.AddCors();
            // registers the TokenService class as the implementation of the ITokenService interface 
            // in the application's dependency injection container, allowing components to easily access 
            // and use it throughout the application
            services.AddScoped<ITokenService, TokenService>();
            // Registers the UserRepository class to be used as the implementation of the IUserRepository interface
            // and to be instantiated once per HTTP request using the AddScoped method
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}