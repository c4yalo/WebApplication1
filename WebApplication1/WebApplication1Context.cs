using Microsoft.EntityFrameworkCore;

public class WebApplication1Context(DbContextOptions<WebApplication1Context> options) : DbContext(options)
{
    public DbSet<WebApplication1.Models.Curso> Curso { get; set; } = default!;
}
