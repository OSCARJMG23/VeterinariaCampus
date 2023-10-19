using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            builder.ToTable("veterinario");

            builder.Property(e=>e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e=>e.CorreoElectronico)
            .IsRequired()
            .HasMaxLength(75);

            builder.Property(e=>e.Telefono)
            .IsRequired()
            .HasMaxLength(15);

            builder.Property(e=>e.Especialidad)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasData(
            new Veterinario
            {
                Id = 1,
                Nombre = "Dr. Juan Pérez",
                CorreoElectronico = "juan.perez@example.com",
                Telefono = "555-123-4567",
                Especialidad = "Cirujano vascular"
            },
            new Veterinario
            {
                Id = 2,
                Nombre = "Dra. María Rodríguez",
                CorreoElectronico = "maria.rodriguez@example.com",
                Telefono = "555-987-6543",
                Especialidad = "Cirujano vascular"
            },
            new Veterinario
            {
                Id = 3,
                Nombre = "Dr. Luis González",
                CorreoElectronico = "luis.gonzalez@example.com",
                Telefono = "555-567-8901",
                Especialidad = "Cardiología"
            },
            new Veterinario
            {
                Id = 4,
                Nombre = "Dra. Ana Martínez",
                CorreoElectronico = "ana.martinez@example.com",
                Telefono = "555-111-2222",
                Especialidad = "Cirujano vascular"
            },
            new Veterinario
            {
                Id = 5,
                Nombre = "Dr. Carlos Sánchez",
                CorreoElectronico = "carlos.sanchez@example.com",
                Telefono = "555-333-4444",
                Especialidad = "Dermatología"
            },
            new Veterinario
            {
                Id = 6,
                Nombre = "Dra. Laura López",
                CorreoElectronico = "laura.lopez@example.com",
                Telefono = "555-555-6666",
                Especialidad = "Cirujano vascular"
            },
            new Veterinario
            {
                Id = 7,
                Nombre = "Dr. Pedro Ramírez",
                CorreoElectronico = "pedro.ramirez@example.com",
                Telefono = "555-777-8888",
                Especialidad = "Oftalmología"
            },
            new Veterinario
            {
                Id = 8,
                Nombre = "Dra. Sofía Torres",
                CorreoElectronico = "sofia.torres@example.com",
                Telefono = "555-999-0000",
                Especialidad = "Cirujano vascular"
            },
            new Veterinario
            {
                Id = 9,
                Nombre = "Dr. Diego Mendoza",
                CorreoElectronico = "diego.mendoza@example.com",
                Telefono = "555-444-3333",
                Especialidad = "Neurología"
            },
            new Veterinario
            {
                Id = 10,
                Nombre = "Dra. Patricia Gómez",
                CorreoElectronico = "patricia.gomez@example.com",
                Telefono = "555-222-1111",
                Especialidad = "Peluqueria"
            }
            );
        }
    }
}