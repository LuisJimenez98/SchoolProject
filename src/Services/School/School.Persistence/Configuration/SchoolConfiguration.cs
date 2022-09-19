using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entity;

namespace School.Persistence.Configuration;
public class SchoolConfiguration
{
    public SchoolConfiguration(EntityTypeBuilder<Colegio> entityBuilder)
    {
        entityBuilder
            .HasKey(c => c.ColegioId);

        entityBuilder
            .Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(256);

        entityBuilder
            .HasIndex(x => x.Nombre)
            .IsUnique();

        entityBuilder
            .Property(c => c.TipoColegio)
            .IsRequired()
            .HasMaxLength(64);
    }
}
