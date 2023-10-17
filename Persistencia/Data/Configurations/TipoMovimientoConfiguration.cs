using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
    {
        public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
        {
            builder.ToTable("tipomovimiento");

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasData(
            new TipoMovimiento
            {
                Id = 1,
                Nombre = "Compra"
            },
            new TipoMovimiento
            {
                Id = 2,
                Nombre = "Venta"
            }
            // Puedes seguir agregando más tipos de movimiento según sea necesario
            );
            
        }
    }
}