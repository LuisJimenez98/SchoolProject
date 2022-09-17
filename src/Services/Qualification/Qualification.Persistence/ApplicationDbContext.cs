using Matter.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Qualification.Domain.Entity;

namespace Qualification.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Calificacion> Calificaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Qualification");
        ModelConfig(modelBuilder);
    }

    protected void ModelConfig(ModelBuilder modelBuilder)
    {
        new QualificationConfiguration(modelBuilder.Entity<Calificacion>());
    }

}
