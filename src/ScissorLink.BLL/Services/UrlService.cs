using ScissorLink.DAL.MariaDB.Models;
using ScissorLink.DAL.MariaDB.Repositories;

namespace ScissorLink.BLL.Services;

public class UrlService(IUrlRepository urlRepository) : IUrlService
{
    public async Task<IEnumerable<UrlModel>> GetAllUrls(CancellationToken ct)
    {
        var urls = await urlRepository.GetAllUrlsAsync(ct);

        return urls;
    }

    public Task<UrlModel> GetUrlById(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UrlModel> GetUrlById(CancellationToken ct)
    {
        throw new NotImplementedException();
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
}