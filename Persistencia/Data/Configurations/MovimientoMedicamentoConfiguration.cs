using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
    {
        public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
        {
            builder.ToTable("movimientoMedicamento");
            
            builder.HasData(
            new MovimientoMedicamento
            {
                IdMovimientoFk = 1,  
                IdMedicamentoFk = 1
            },
            new MovimientoMedicamento
            {
                IdMovimientoFk = 2,  
                IdMedicamentoFk = 2
            },
            new MovimientoMedicamento
            {
                IdMovimientoFk = 3,  
                IdMedicamentoFk = 3
            },
            new MovimientoMedicamento
            {
                IdMovimientoFk = 4,  
                IdMedicamentoFk = 4
            },
            new MovimientoMedicamento
            {
                IdMovimientoFk = 5,  
                IdMedicamentoFk = 5
            }
            
            );
        }
    }
}