using Microsoft.EntityFrameworkCore;
using UmbracoBlogPost.Web.AppCode.Models.CustomEntities;

namespace UmbracoBlogPost.Web.AppCode.CustomDbContext;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<ContactUs> ContactUs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}