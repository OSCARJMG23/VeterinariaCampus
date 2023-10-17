using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Cita : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
        public int IdMascotaFk { get; set; }
        public Mascota Mascota { get; set; }
        public int IdVeterinarioFk { get; set; }
        public Veterinario Veterinario { get; set; }
        public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }
    }
}