using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.ToTable("especie");

            builder.Property(e=>e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.HasData(
            new Especie
            {
                Id = 1,
                Nombre = "Perro"
            },
            new Especie
            {
                Id = 2,
                Nombre = "Felina"
            },
            new Especie
            {
                Id = 3,
                Nombre = "Conejo"
            },
            new Especie
            {
                Id = 4,
                Nombre = "Ave"
            }
            );
        }
    }
}