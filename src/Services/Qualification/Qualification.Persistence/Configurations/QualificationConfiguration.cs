using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualification.Domain.Entity;

namespace Matter.Persistence.Configuration;
public class QualificationConfiguration
{
    public QualificationConfiguration(EntityTypeBuilder<Calificacion> builder)
    {
        builder
            .HasKey(x => x.CalificacionId);

        builder
            .Property(x => x.ColegioId)
            .IsRequired();

        builder
        .Property(x => x.MateriaId)
        .IsRequired();

        builder
        .Property(x => x.UsuarioId)
        .IsRequired();

        builder
       .Property(x => x.Nota)
       .IsRequired()
       .HasPrecision(18,2);

    }
}
