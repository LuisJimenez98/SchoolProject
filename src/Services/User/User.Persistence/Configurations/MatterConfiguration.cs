using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entity;

namespace User.Persistence.Configuration
{
    public class MatterConfiguration
    {
        public MatterConfiguration(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(x => x.UsuarioId);

            builder
                .Property(x => x.NombreCompleto)
                .IsRequired()
                 .HasMaxLength(256);

            builder
              .Property(x => x.UserName)
               .IsRequired()
                .HasMaxLength(128);

            builder
                .HasIndex(x => x.UserName)
                .IsUnique();

            builder
                .Property(x => x.password)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.CorreoElectronico)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(x => x.Rol)
                .IsRequired()
                .HasMaxLength(32);

        }
    }
}
