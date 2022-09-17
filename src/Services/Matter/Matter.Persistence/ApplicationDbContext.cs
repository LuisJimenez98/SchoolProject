using Matter.Domain.Entity;
using Matter.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Matter.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Materia> Materias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Matter");
        ModelConfig(modelBuilder);
    }

    protected void ModelConfig(ModelBuilder modelBuilder)
    {
        new MatterConfiguration(modelBuilder.Entity<Materia>());
    }

}
