using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
    {
        public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
        {
            builder.ToTable("tratamientomedico");

            builder.Property(e=>e.Dosis)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(e=>e.Observacion)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e=>e.Observacion)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e=>e.IdCitaFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e=>e.Cita)
            .WithMany(e=>e.TratamientosMedicos)
            .HasForeignKey(e=>e.IdCitaFk);

            builder.Property(e=>e.IdMedicamentoFk)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(e=>e.Medicamento)
            .WithMany(e=>e.TratamientosMedicos)
            .HasForeignKey(e=>e.IdMedicamentoFk);

            builder.HasData(
            new TratamientoMedico
            {
                Id = 1,
                Dosis = "2 tabletas",
                FechaAdministracion = new DateTime(2023, 3, 7),
                Observacion = "Tomar después de las comidas",
                IdCitaFk = 2,
                IdMedicamentoFk = 3
            },
            new TratamientoMedico
            {
                Id = 2,
                Dosis = "1 cápsula",
                FechaAdministracion = new DateTime(2023, 3, 10),
                Observacion = "Tomar con agua",
                IdCitaFk = 1,
                IdMedicamentoFk = 4
            },
            new TratamientoMedico
            {
                Id = 3,
                Dosis = "3 ml",
                FechaAdministracion = new DateTime(2023, 3, 15),
                Observacion = "Inyectar en el músculo",
                IdCitaFk = 3,
                IdMedicamentoFk = 5
            }
            );
        }
    }
}