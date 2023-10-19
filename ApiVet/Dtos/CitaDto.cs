using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiVet.Dtos
{
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
        public int IdMascotaFk { get; set; }
        public MascotaDto Mascota { get; set; }
        public int IdVeterinarioFk { get; set; }
        public VeterinarioDto Veterinario { get; set; }
    }
}