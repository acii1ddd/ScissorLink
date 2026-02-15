using Microsoft.Extensions.DependencyInjection;
using ScissorLink.BLL.Interfaces;
using ScissorLink.BLL.Services;

namespace ScissorLink.BLL.ConfigurationExtensions;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUrlService, UrlService>();
        services.AddScoped<IShortCodeGeneratorService, ShortCodeGeneratorService>();
        
        return services;
    }
}