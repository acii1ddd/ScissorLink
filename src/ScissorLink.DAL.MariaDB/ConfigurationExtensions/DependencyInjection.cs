using Microsoft.Extensions.DependencyInjection;
using ScissorLink.DAL.MariaDB.Repositories;

namespace ScissorLink.DAL.MariaDB.ConfigurationExtensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUrlRepository, UrlRepository>();
        
        return services;
    }
}