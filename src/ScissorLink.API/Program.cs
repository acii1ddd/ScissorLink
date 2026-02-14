using ScissorLink.API.ConfigurationExtensions;
using ScissorLink.BLL.ConfigurationExtensions;
using ScissorLink.DAL.MariaDB.ConfigurationExtensions;

namespace ScissorLink.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("MariaConnection")
                               ?? throw new NullReferenceException("Maria connection string not found");

        builder.Services
            .AddOpenApiSpec()
            .AddMariaDb(connectionString)
            .AddServices()
            .AddRepositories();
        
        var app = builder.Build();

        await app.ConfigureWebApp();
        
        await app.RunAsync();
    }
}