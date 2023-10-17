using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class RazaConfiguration : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.ToTable("raza");

            builder.Property(e=>e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e=>e.IdEspecieFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(w => w.Especie)
            .WithMany(w=>w.Razas)
            .HasForeignKey(w=>w.IdEspecieFk);

            builder.HasData(
            new Raza
            {
                Id = 1,
                Nombre = "Golden Retriever",
                IdEspecieFk = 1
            },
            new Raza
            {
                Id = 2,
                Nombre = "Labrador Retriever",
                IdEspecieFk = 1
            },
            new Raza
            {
                Id = 3,
                Nombre = "Bulldog",
                IdEspecieFk = 1
            },
            new Raza
            {
                Id = 4,
                Nombre = "Siamese",
                IdEspecieFk = 2
            },
            new Raza
            {
                Id = 5,
                Nombre = "Maine Coon",
                IdEspecieFk = 2
            },
            new Raza
            {
                Id = 6,
                Nombre = "Holandés Enano",
                IdEspecieFk = 3
            },
            new Raza
            {
                Id = 7,
                Nombre = "Cabeza de León",
                IdEspecieFk = 3
            },
            // Razas para "Ave"
            new Raza
            {
                Id = 8,
                Nombre = "Canario",
                IdEspecieFk = 4
            },
            new Raza
            {
                Id = 9,
                Nombre = "Periquito",
                IdEspecieFk = 4
            }
            );
        }
    }
}