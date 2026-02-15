using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.DAL.MariaDB.Repositories;

public interface IUrlRepository
{
    public Task<IEnumerable<UrlModel>> GetAllUrlsAsync(CancellationToken ct);
    
    public Task<UrlModel?> GetByIdAsync(Guid id, CancellationToken ct);
    
    public Task UpdateAsync(UrlModel url, CancellationToken ct);
    
    public Task DeleteAsync(UrlModel url, CancellationToken ct);
}