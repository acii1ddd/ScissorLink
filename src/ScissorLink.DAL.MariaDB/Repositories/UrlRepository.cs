using Microsoft.EntityFrameworkCore;
using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.DAL.MariaDB.Repositories;

public class UrlRepository(UrlDbContext context) : IUrlRepository
{
    public async Task<IEnumerable<UrlModel>> GetAllUrlsAsync(CancellationToken ct)
    {
        return await context.Urls.AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<UrlModel?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await context.Urls
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task UpdateAsync(UrlModel url, CancellationToken ct)
    {
        context.Urls.Update(url);
        
        return context.SaveChangesAsync(ct);
    }

    public Task DeleteAsync(UrlModel url, CancellationToken ct)
    {
        context.Urls.Remove(url);
        
        return context.SaveChangesAsync(ct);
    }

    public async Task AddAsync(UrlModel url, CancellationToken ct)
    {
        await context.Urls.AddAsync(url, ct);
        
        await context.SaveChangesAsync(ct);
    }

    public async Task<UrlModel?> GetByShortUrlAsync(string shortUrl, CancellationToken сt)
    {
        return await context.Urls
            .FirstOrDefaultAsync(x => x.ShortUrl == shortUrl, сt);
    }
}