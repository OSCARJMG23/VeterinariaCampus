using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiVet.Dtos
{
    public class TratamientoMedicoDto
    {
        public string Dosis { get; set; }
        public DateTime FechaAdministracion { get; set; }
        public string Observacion { get; set; }
        public int IdCitaFk { get; set; }
        public CitaDto Cita { get; set; }
        public int IdMedicamentoFk { get; set; }
        public MedicamentoDto Medicamento { get; set; }
    }
}