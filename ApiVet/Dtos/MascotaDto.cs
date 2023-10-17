using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiVet.Dtos
{
    public class MascotaDto
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPropietarioFk { get; set; }
        public Propietario Propietario { get; set; }
        public int IdRazaFk { get; set; }
        public Raza Raza { get; set; }
    }
}