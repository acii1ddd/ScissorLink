using Scalar.AspNetCore;

namespace ScissorLink.API.ConfigurationExtensions;

public class WebAppExtensions
{
    public static async Task ConfigureWebApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }
    }
}