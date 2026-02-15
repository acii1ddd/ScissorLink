using Microsoft.AspNetCore.Mvc;
using ScissorLink.API.Dtos;
using ScissorLink.BLL.Interfaces;

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
    
    [HttpPost]
    public async Task<IActionResult> AddUrl([FromBody] AddUrlRequest request, CancellationToken ct)
    {
        var url = await urlService.AddUrlAsync(request.LongUrl, ct);

        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        
        var response = new AddUrlResponse
        {
            Id = url.Id,
            ShortUrl = url.ShortUrl,
            LongUrl = url.LongUrl,
            CreatedAt = url.CreatedAt,
            ClickCount = url.ClickCount,
            Links =
            [
                new Link { Rel = "self", Href = $"{baseUrl}/api/urls/{url.Id}", Method = "GET" },
                new Link { Rel = "redirect", Href = $"{baseUrl}/api/go/{url.ShortUrl}", Method = "GET" },
                new Link { Rel = "delete", Href = $"{baseUrl}/api/urls/{url.Id}", Method = "DELETE" },
                new Link { Rel = "update", Href = $"{baseUrl}/api/urls/{url.Id}", Method = "PUT" }
            ]
        };
        
        return CreatedAtAction(nameof(GetUrl), new { id = url.Id }, response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUrl(Guid id, CancellationToken ct)
    {
        var url = await urlService.GetUrlById(id, ct);

        return Ok(url);
    }
}