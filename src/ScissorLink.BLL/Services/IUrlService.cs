using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.BLL.Services;

public interface IUrlService
{
    public Task<IEnumerable<UrlModel>> GetAllUrls(CancellationToken ct);
    
    public Task<UrlModel> GetUrlById(CancellationToken ct);
    
    public Task<UrlModel> UpdateUrl(string longUrl, CancellationToken ct);
    
    public Task<UrlModel> DeleteUrlById(Guid id, CancellationToken ct);
}