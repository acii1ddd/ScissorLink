using ScissorLink.API.ConfigurationExtensions;

namespace ScissorLink.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApiSpec();
        
        var connectionString = builder.Configuration.GetConnectionString("MariaConnection")
            ?? throw new NullReferenceException("Maria connection string not found");
        
        builder.Services.AddMariaDb(connectionString);
        
        var app = builder.Build();
        
        await app.RunAsync();
    }
}