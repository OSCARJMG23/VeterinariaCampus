using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("proveedor");

            builder.Property(e=> e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e=> e.Direccion)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e=> e.Telefono)
            .IsRequired()
            .HasMaxLength(15);

            builder.HasData(
            new Proveedor
            {
                Id = 1,
                Nombre = "AnimalPharma",
                Direccion = "Calle de Suministros 123",
                Telefono = "555-111-1111"
            },
            new Proveedor
            {
                Id = 2,
                Nombre = "PetMedSupplies",
                Direccion = "Avenida de Productos 456",
                Telefono = "555-222-2222"
            },
            new Proveedor
            {
                Id = 3,
                Nombre = "VetSupplies Co.",
                Direccion = "Carrera de Veterinaria 789",
                Telefono = "555-333-3333"
            },
            new Proveedor
            {
                Id = 4,
                Nombre = "AnimalHealth Distributors",
                Direccion = "Calle de Distribución 567",
                Telefono = "555-444-4444"
            },
            new Proveedor
            {
                Id = 5,
                Nombre = "PetPharmaceuticals Inc.",
                Direccion = "Avenida de Farmacia 321",
                Telefono = "555-555-5555"
            },
            new Proveedor
            {
                Id = 6,
                Nombre = "AnimalCare Supplies",
                Direccion = "Carrera de Suministros 654",
                Telefono = "555-666-6666"
            }
        );
            
        }
    }
}