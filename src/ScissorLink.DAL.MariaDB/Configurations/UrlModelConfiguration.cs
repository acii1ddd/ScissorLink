using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.DAL.MariaDB.Configurations;

public class UrlModelConfiguration : IEntityTypeConfiguration<UrlModel>
{
    private const int MaxLength = 200;
    
    public void Configure(EntityTypeBuilder<UrlModel> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ShortUrl)
            .HasMaxLength(200).IsRequired();
        
        builder.Property(x => x.LongUrl)
            .HasMaxLength(200).IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.ClickCount)
            .IsRequired();
    }
}