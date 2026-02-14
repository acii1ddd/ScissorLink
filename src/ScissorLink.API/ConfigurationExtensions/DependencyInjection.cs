using Microsoft.EntityFrameworkCore;
using ScissorLink.DAL.MariaDB;

namespace ScissorLink.API.ConfigurationExtensions;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMariaDb(string connectionString)
        {
            services.AddDbContext<UrlDbContext>(opt =>
            {
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    opt.LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                }
            });

            return services;
        }

        public IServiceCollection AddOpenApiSpec()
        {
            services.AddOpenApi();
            return services;
        }
    }
}