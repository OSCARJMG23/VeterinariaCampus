using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder.ToTable("medicamento");

            builder.Property(e=>e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(e=>e.Stock)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(e=>e.Precio)
            .IsRequired()
            .HasColumnType("double");

            builder.Property(e=>e.IdLaboratorioFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e=>e.Laboratorio)
            .WithMany(e=>e.Medicamentos)
            .HasForeignKey(e=>e.IdLaboratorioFk);

            builder.HasMany(e=>e.Proveedores)
            .WithMany(r=>r.Medicamentos)
            .UsingEntity<MedicamentoProveedor>(

                j => j
                .HasOne(p=>p.Proveedor)
                .WithMany(p=>p.MedicamentosProveedores)
                .HasForeignKey(p=>p.IdProveedorFk),

                j => j
                .HasOne(e=>e.Medicamento)
                .WithMany(e=>e.MedicamentosProveedores)
                .HasForeignKey(e=>e.IdMedicamentoFk),

                j =>
                {
                    j.ToTable("medicamentoProveedor");
                    j.HasKey(t => new {t.IdMedicamentoFk, t.IdProveedorFk});

                });
            
            builder.HasData(
            new Medicamento
            {
                Id = 1,
                Nombre = "PetRelief",
                Stock = 100,
                Precio = 10.99,
                IdLaboratorioFk = 2
            },
            new Medicamento
            {
                Id = 2,
                Nombre = "AnimalGuardian",
                Stock = 75,
                Precio = 8.99,
                IdLaboratorioFk = 2
            },
            new Medicamento
            {
                Id = 3,
                Nombre = "VetMediCure",
                Stock = 50,
                Precio = 12.99,
                IdLaboratorioFk = 4
            },
            new Medicamento
            {
                Id = 4,
                Nombre = "PetRxPlus",
                Stock = 120,
                Precio = 50000,
                IdLaboratorioFk = 5
            },
            new Medicamento
            {
                Id = 5,
                Nombre = "AnimalVitality",
                Stock = 90,
                Precio = 11.99,
                IdLaboratorioFk = 6
            }
            );


        }
    }
}