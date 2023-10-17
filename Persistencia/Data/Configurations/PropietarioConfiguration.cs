using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
    {
        public void Configure(EntityTypeBuilder<Propietario> builder)
        {
            builder.ToTable("propietario");

            builder.Property(e=>e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(e=>e.CorreoElectronico)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e=>e.Telefono)
            .IsRequired()
            .HasMaxLength(15);

            builder.HasData(
            new Propietario
            {
                Id = 1,
                Nombre = "Juan Pérez",
                CorreoElectronico = "juan.perez@example.com",
                Telefono = "555-123-4567"
            },
            new Propietario
            {
                Id = 2,
                Nombre = "María Rodríguez",
                CorreoElectronico = "maria.rodriguez@example.com",
                Telefono = "555-987-6543"
            },
            new Propietario
            {
                Id = 3,
                Nombre = "Luis González",
                CorreoElectronico = "luis.gonzalez@example.com",
                Telefono = "555-567-8901"
            },
            new Propietario
            {
                Id = 4,
                Nombre = "Ana Martínez",
                CorreoElectronico = "ana.martinez@example.com",
                Telefono = "555-111-2222"
            },
            new Propietario
            {
                Id = 5,
                Nombre = "Carlos Sánchez",
                CorreoElectronico = "carlos.sanchez@example.com",
                Telefono = "555-333-4444"
            },
            new Propietario
            {
                Id = 6,
                Nombre = "Laura López",
                CorreoElectronico = "laura.lopez@example.com",
                Telefono = "555-555-6666"
            },
            new Propietario
            {
                Id = 7,
                Nombre = "Pedro Ramírez",
                CorreoElectronico = "pedro.ramirez@example.com",
                Telefono = "555-777-8888"
            },
            new Propietario
            {
                Id = 8,
                Nombre = "Sofía Torres",
                CorreoElectronico = "sofia.torres@example.com",
                Telefono = "555-999-0000"
            }
            );
        }
    }
}