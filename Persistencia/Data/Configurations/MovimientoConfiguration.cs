using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.ToTable("movimiento");

            builder.Property(e=>e.Cantidad)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(e=>e.Precio)
            .IsRequired()
            .HasColumnType("int");

           /*  builder.Property(e=>e.IdMedicamentoFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e => e.Medicamento)
            .WithMany(e=>e.Movimientos)
            .HasForeignKey(e=>e.IdMedicamentoFk); */

            builder.Property(e=>e.IdTipoMovimientoFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e => e.TipoMovimiento)
            .WithMany(e=>e.Movimientos)
            .HasForeignKey(e=>e.IdTipoMovimientoFk);

            builder.HasMany(e =>e.Medicamentos)
            .WithMany(e=>e.Movimientos)
            .UsingEntity<MovimientoMedicamento>(

                j => j
                .HasOne(p=>p.Medicamento)
                .WithMany(p=>p.MovimientosMedicamentos)
                .HasForeignKey(p=>p.IdMedicamentoFk),

                j => j
                .HasOne(t=>t.Movimiento)
                .WithMany(t=>t.MovimientosMedicamentos)
                .HasForeignKey(t=>t.IdMovimientoFk),

                j =>
                {
                    j.ToTable("movimientoMedicamento");
                    j.HasKey(t=> new {t.IdMedicamentoFk, t.IdMovimientoFk });
                }
            );

            builder.HasData(
            new Movimiento
            {
                Id = 1,
                Cantidad = 10,
                Precio = 50,
                IdTipoMovimientoFk = 2
            },
            new Movimiento
            {
                Id = 2,
                Cantidad = 5,
                Precio = 80,
                IdTipoMovimientoFk = 2
            },
            new Movimiento
            {
                Id = 3,
                Cantidad = 8,
                Precio = 60,
                IdTipoMovimientoFk = 2
            },
            new Movimiento
            {
                Id = 4,
                Cantidad = 15,
                Precio = 120,
                IdTipoMovimientoFk = 2
            },
            new Movimiento
            {
                Id = 5,
                Cantidad = 12,
                Precio = 70,
                IdTipoMovimientoFk = 2
            }
            );

            

        }
    }
}