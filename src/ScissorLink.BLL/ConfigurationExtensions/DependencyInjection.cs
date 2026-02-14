using Microsoft.Extensions.DependencyInjection;
using ScissorLink.BLL.Services;

namespace ScissorLink.BLL.ConfigurationExtensions;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUrlService, UrlService>();
        
        return services;
    }
}