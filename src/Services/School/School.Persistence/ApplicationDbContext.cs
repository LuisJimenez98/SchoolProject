using Microsoft.EntityFrameworkCore;
using School.Domain.Entity;
using School.Persistence.Configuration;
using System.Reflection;

namespace School.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Colegio> Colegios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Database schema
            modelBuilder.HasDefaultSchema("School");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new SchoolConfiguration(modelBuilder.Entity<Colegio>());
        }
    }
}
