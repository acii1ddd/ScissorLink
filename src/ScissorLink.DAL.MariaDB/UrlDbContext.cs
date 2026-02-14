using Microsoft.EntityFrameworkCore;
using ScissorLink.DAL.MariaDB.Models;

namespace ScissorLink.DAL.MariaDB;

public class UrlDbContext(DbContextOptions<UrlDbContext> options) 
    : DbContext(options)
{
    public DbSet<UrlModel> Urls { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlDbContext).Assembly);
    }
}