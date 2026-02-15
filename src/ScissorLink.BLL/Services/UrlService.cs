using ScissorLink.BLL.Interfaces;
using ScissorLink.DAL.MariaDB.Models;
using ScissorLink.DAL.MariaDB.Repositories;

namespace ScissorLink.BLL.Services;

public class UrlService(
    IUrlRepository urlRepository, 
    IShortCodeGeneratorService generator) : IUrlService
{
    public async Task<IEnumerable<UrlModel>> GetAllUrls(CancellationToken ct)
    {
        var urls = await urlRepository.GetAllUrlsAsync(ct);

        return urls;
    }

    public async Task<UrlModel?> GetUrlById(Guid id, CancellationToken ct)
    {
        var url = await urlRepository.GetByIdAsync(id, ct);

        if (url is null)
        {
            throw new KeyNotFoundException($"URL with id {id} not found");
        }
        
        return url;
    }
    
    public async Task<UrlModel> UpdateUrl(Guid id, string longUrl, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(longUrl))
            throw new ArgumentException("URL cannot be empty");
    
        if (!Uri.IsWellFormedUriString(longUrl, UriKind.Absolute))
            throw new ArgumentException("Invalid URL format");
        
        var url = await urlRepository.GetByIdAsync(id, ct);

        if (url is null)
        {
            throw new KeyNotFoundException($"URL with id {id} not found");
        }

        url.LongUrl = longUrl;
        
        await urlRepository.UpdateAsync(url, ct);

        return url;
    }

    public async Task DeleteUrlById(Guid id, CancellationToken ct)
    {
        var url = await urlRepository.GetByIdAsync(id, ct);

        if (url is null)
        {
            throw new KeyNotFoundException($"URL with id {id} not found");
        }

        await urlRepository.DeleteAsync(url, ct);
    }

    public async Task<UrlModel> AddUrlAsync(string longUrl, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(longUrl))
            throw new ArgumentException("URL cannot be empty");
        
        if (!Uri.IsWellFormedUriString(longUrl, UriKind.Absolute))
            throw new ArgumentException("Invalid URL format");

        var shortedUrl = generator.Generate();
        
        var url = new UrlModel
        {
            Id = Guid.NewGuid(),
            LongUrl = longUrl,
            ShortUrl = shortedUrl,
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            ClickCount = 0
        };
        
        await urlRepository.AddAsync(url, ct);

        return url;
    }

    public async Task<UrlModel> GetByShortUrlAsync(string shortUrl, CancellationToken ct)
    {
        var url = await urlRepository.GetByShortUrlAsync(shortUrl, ct);

        if (url is null)
        {
            throw new KeyNotFoundException($"URL with shortUrl {shortUrl} not found");
        }

        url.ClickCount++;
        
        await urlRepository.UpdateAsync(url, ct);
        
        return url;
    }
}