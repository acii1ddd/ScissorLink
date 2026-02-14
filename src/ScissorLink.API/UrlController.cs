using Microsoft.AspNetCore.Mvc;
using ScissorLink.BLL.Services;

namespace ScissorLink.API.Controllers;

[ApiController]
[Route("api/urls")]
public class UrlController(IUrlService urlService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUrls(CancellationToken ct)
    {
        var urls = await urlService.GetAllUrls(ct);

        return Ok(urls);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUrl(CancellationToken ct)
    {
        var urls = await urlService.UpdateUrl("q", ct);

        return Ok(urls);
    }
}