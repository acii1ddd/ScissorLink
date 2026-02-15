using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.BLL.Services;

public interface IUrlService
{
    public Task<IEnumerable<UrlModel>> GetAllUrls(CancellationToken ct);
    
    public Task<UrlModel> GetUrlById(Guid id, CancellationToken ct);

    public Task<UrlModel> UpdateUrl(Guid id, string longUrl, CancellationToken ct);
    
    public Task DeleteUrlById(Guid id, CancellationToken ct);
}