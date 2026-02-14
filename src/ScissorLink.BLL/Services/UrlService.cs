using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.BLL.Services;

public class UrlService : IUrlService
{
    public Task<IEnumerable<UrlModel>> GetAllUrls(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UrlModel> GetUrlById(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UrlModel> UpdateUrl(string longUrl, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UrlModel> DeleteUrlById(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}