using Microsoft.AspNetCore.Mvc;
using ScissorLink.BLL.Interfaces;

namespace ScissorLink.API.Controllers;

[ApiController]
[Route("go")]
public class RedirectController(IUrlService urlService) 
    : ControllerBase
{
    [HttpGet("{shortUrl}")]
    public async Task<IActionResult> RedirectToLongUrl(string shortUrl, CancellationToken ct)
    {
        var url = await urlService.GetByShortUrlAsync(shortUrl, ct);

        return Redirect(url.LongUrl);
    }
}