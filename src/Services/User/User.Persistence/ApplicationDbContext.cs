using Microsoft.EntityFrameworkCore;
using User.Domain.Entity;
using User.Persistence.Configuration;

namespace User.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("User");
        ModelConfig(modelBuilder);
    }

    protected void ModelConfig(ModelBuilder modelBuilder)
    {
        new MatterConfiguration(modelBuilder.Entity<Usuario>());
    }

}
