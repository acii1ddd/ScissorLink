namespace ScissorLink.DAL.MariaDB.Models;

public class UrlModel
{
    public Guid Id { get; set; }
    
    public string ShortUrl { get; set; } = string.Empty;

    public string LongUrl { get; set; } = string.Empty;
    
    public DateOnly CreatedAt { get; set; }
    
    public int ClickCount { get; set; }
}