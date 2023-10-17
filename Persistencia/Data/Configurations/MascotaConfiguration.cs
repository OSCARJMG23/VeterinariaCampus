using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("mascota");

            builder.Property(e=>e.Nombre)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(e=>e.IdPropietarioFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e=>e.Propietario)
            .WithMany(e=>e.Mascotas)
            .HasForeignKey(e=>e.IdPropietarioFk);

            builder.Property(e=>e.IdRazaFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e=>e.Raza)
            .WithMany(e=>e.Mascotas)
            .HasForeignKey(e=>e.IdRazaFk);

            builder.HasData(
            new Mascota
            {
                Id = 1,
                Nombre = "Max",
                FechaNacimiento = new DateTime(2019, 3, 10),
                IdPropietarioFk = 1,
                IdRazaFk = 1
            },
            new Mascota
            {
                Id = 2,
                Nombre = "Luna",
                FechaNacimiento = new DateTime(2020, 5, 15),
                IdPropietarioFk = 2,
                IdRazaFk = 2
            },
            new Mascota
            {
                Id = 3,
                Nombre = "Rocky",
                FechaNacimiento = new DateTime(2018, 7, 25),
                IdPropietarioFk = 1,
                IdRazaFk = 4
            },
            new Mascota
            {
                Id = 4,
                Nombre = "Bella",
                FechaNacimiento = new DateTime(2019, 1, 8),
                IdPropietarioFk = 3,
                IdRazaFk = 4
            },
            new Mascota
            {
                Id = 5,
                Nombre = "Coco",
                FechaNacimiento = new DateTime(2017, 11, 20),
                IdPropietarioFk = 5,
                IdRazaFk = 5
            }
            );
        }
    }
}