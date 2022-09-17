using Matter.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matter.Persistence.Configuration
{
    public class MatterConfiguration
    {
        public MatterConfiguration(EntityTypeBuilder<Materia> builder)
        {
            builder
                .HasKey(x => x.MateriaId);

            builder
                .Property(x => x.ColegioId)
                .IsRequired();

            builder
                .Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(x => x.Area)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.NumeroEstudiantes)
                .IsRequired();

            builder
                .Property(x => x.DocenteAsignado)
                .IsRequired()
                .HasMaxLength(512);

            builder
                .Property(x => x.Curso)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(x => x.Paralelo)
                .IsRequired()
                .HasMaxLength(16);


        }
    }
}
