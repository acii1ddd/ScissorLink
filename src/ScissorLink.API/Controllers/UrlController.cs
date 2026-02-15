using Microsoft.AspNetCore.Mvc;
using ScissorLink.API.Dtos;
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
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUrl([FromBody] UpdateUrlRequest request, 
        Guid id, CancellationToken ct)
    {
        var url = await urlService.UpdateUrl(id, request.LongUrl, ct);

        return Ok(url);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUrl(Guid id, CancellationToken ct)
    {
        await urlService.DeleteUrlById(id, ct);

        return NoContent();
    }
}