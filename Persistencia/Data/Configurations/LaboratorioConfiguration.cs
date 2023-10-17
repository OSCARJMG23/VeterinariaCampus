using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
    {
        public void Configure(EntityTypeBuilder<Laboratorio> builder)
        {
            builder.ToTable("laboratorio");

            builder.Property(e=>e.Nombre)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(e=>e.Direccion)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e=>e.Telefono)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasData(
            new Laboratorio
            {
                Id = 1,
                Nombre = "AnimalMed",
                Direccion = "Calle Veterinaria 123",
                Telefono = "555-111-1111"
            },
            new Laboratorio
            {
                Id = 2,
                Nombre = "Genfar",
                Direccion = "Avenida de Mascotas 456",
                Telefono = "555-222-2222"
            },
            new Laboratorio
            {
                Id = 3,
                Nombre = "PetCare Labs",
                Direccion = "Carrera Animal 789",
                Telefono = "555-333-3333"
            },
            new Laboratorio
            {
                Id = 4,
                Nombre = "AnimalHealth Solutions",
                Direccion = "Calle de Cuidados 567",
                Telefono = "555-444-4444"
            },
            new Laboratorio
            {
                Id = 5,
                Nombre = "VetMedix",
                Direccion = "Avenida de Salud 321",
                Telefono = "555-555-5555"
            },
            new Laboratorio
            {
                Id = 6,
                Nombre = "AnimalWellness Labs",
                Direccion = "Carrera Bienestar 654",
                Telefono = "555-666-6666"
            },
            new Laboratorio
            {
                Id = 7,
                Nombre = "AnimalPharmaceuticals",
                Direccion = "Calle de Farmacia 890",
                Telefono = "555-777-7777"
            },
            new Laboratorio
            {
                Id = 8,
                Nombre = "VetRx",
                Direccion = "Avenida de Medicamentos 987",
                Telefono = "555-888-8888"
            },
            new Laboratorio
            {
                Id = 9,
                Nombre = "AnimalCare Innovations",
                Direccion = "Carrera Innovación 123",
                Telefono = "555-999-9999"
            },
            new Laboratorio
            {
                Id = 10,
                Nombre = "BioVet",
                Direccion = "Avenida Principal Animal",
                Telefono = "555-123-4567"
            }
            // Puedes seguir agregando más nombres de laboratorios según sea necesario
        );
        }
    }
}