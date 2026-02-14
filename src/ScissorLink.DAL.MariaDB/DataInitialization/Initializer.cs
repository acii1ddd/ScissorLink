using Microsoft.EntityFrameworkCore;
using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.DAL.MariaDB.DataInitialization;

public class Initializer
{
    public static async Task SeedData(UrlDbContext context)
    {
        if (!await context.Urls.AnyAsync())
        {
            var urls = GetUrlsData();

            await context.Urls.AddRangeAsync(urls);
            
            await context.SaveChangesAsync();
        }
    }

    private static List<UrlModel> GetUrlsData()
    {
        var urls = new List<UrlModel>();
        
        var url1 = new UrlModel
        {
            Id = Guid.NewGuid(),
            LongUrl = "https://www.youtube.com/",
            ShortUrl = "abc123",
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-5)),
            ClickCount = 0
        };

        var url2 = new UrlModel
        {
            Id = Guid.NewGuid(),
            LongUrl = "https://github.com/dotnet/aspnetcore",
            ShortUrl = "def456",
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-3)),
            ClickCount = 0
        };

        var url3 = new UrlModel
        {
            Id = Guid.NewGuid(),
            LongUrl = "https://stackoverflow.com/questions/ask",
            ShortUrl = "ghi789",
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)),
            ClickCount = 0
        };

        var url4 = new UrlModel
        {
            Id = Guid.NewGuid(),
            LongUrl = "https://learn.microsoft.com/en-us/aspnet/core",
            ShortUrl = "jkl012",
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            ClickCount = 0
        };

        var url5 = new UrlModel
        {
            Id = Guid.NewGuid(),
            LongUrl = "https://www.google.com/",
            ShortUrl = "mno345",
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(-12)),
            ClickCount = 0
        };
        
        urls.AddRange(url1, url2, url3, url4, url5);
        return urls;
    }
}