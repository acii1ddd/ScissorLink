using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ScissorLink.DAL.MariaDB;
using ScissorLink.DAL.MariaDB.DataInitialization;

namespace ScissorLink.API.ConfigurationExtensions;

public static class WebAppExtensions
{
    extension(WebApplication app)
    {
        public async Task ConfigureWebApp()
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            
            app.MapGet("/", context =>
            {
                context.Response.Redirect("/index.html");
                return Task.CompletedTask;
            });
            
            await app.InitDbAsync();
        }

        private async Task InitDbAsync()
        {
            using var scope = app.Services.CreateScope();
        
            var context = scope.ServiceProvider.GetRequiredService<UrlDbContext>();

            await context.Database.MigrateAsync();

            await Initializer.SeedData(context);
        }
    }
}