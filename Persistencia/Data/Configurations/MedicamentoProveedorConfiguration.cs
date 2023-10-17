using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class MedicamentoProveedorConfiguration : IEntityTypeConfiguration<MedicamentoProveedor>
    {
        public void Configure(EntityTypeBuilder<MedicamentoProveedor> builder)
        {
            builder.ToTable("medicamentoProveedor");
            
            builder.HasData(
            new MedicamentoProveedor
            {
                IdMedicamentoFk = 1,  
                IdProveedorFk = 1
            },
            new MedicamentoProveedor
            {
                IdMedicamentoFk = 2,  
                IdProveedorFk = 1
            },
            new MedicamentoProveedor
            {
                IdMedicamentoFk = 3,  
                IdProveedorFk = 4
            },
            new MedicamentoProveedor
            {
                IdMedicamentoFk = 4,  
                IdProveedorFk = 3
            },
            new MedicamentoProveedor
            {
                IdMedicamentoFk = 5,  
                IdProveedorFk = 6
            }
            );
        }
    }
}