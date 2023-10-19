using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("cita");

            builder.Property(e=>e.Hora)
            .IsRequired()
            .HasMaxLength(10);

            builder.Property(t=>t.Motivo)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e=>e.IdMascotaFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(c=>c.Mascota)
            .WithMany(t=>t.Citas)
            .HasForeignKey(t=>t.IdMascotaFk);

            builder.Property(e=>e.IdVeterinarioFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e=>e.Veterinario)
            .WithMany(e=>e.Citas)
            .HasForeignKey(e=>e.IdVeterinarioFk);

            builder.HasData(
            new Cita
            {
                Id = 1,
                Fecha = new DateTime(2023, 3, 5),
                Hora = "09:00 AM",
                Motivo = "Vacunación",
                IdMascotaFk = 1,
                IdVeterinarioFk = 1
            },
            new Cita
            {
                Id = 2,
                Fecha = new DateTime(2023, 3, 10),
                Hora = "11:30 AM",
                Motivo = "Consulta General",
                IdMascotaFk = 2,
                IdVeterinarioFk = 2
            },
            new Cita
            {
                Id = 3,
                Fecha = new DateTime(2023, 3, 15),
                Hora = "03:15 PM",
                Motivo = "Vacunación",
                IdMascotaFk = 3,
                IdVeterinarioFk = 3
            },
            new Cita
            {
                Id = 4,
                Fecha = new DateTime(2023, 3, 20),
                Hora = "02:00 PM",
                Motivo = "Cirugía",
                IdMascotaFk = 4,
                IdVeterinarioFk = 2
            },
            new Cita
            {
                Id = 5,
                Fecha = new DateTime(2023, 3, 25),
                Hora = "10:45 AM",
                Motivo = "Consulta General",
                IdMascotaFk = 5,
                IdVeterinarioFk = 3
            },
            new Cita
            {
                Id = 6,
                Fecha = new DateTime(2023, 3, 30),
                Hora = "04:30 PM",
                Motivo = "Vacunación",
                IdMascotaFk = 3,
                IdVeterinarioFk = 4
            }
        );
        }
    }
}