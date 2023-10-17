using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiVet.Dtos
{
    public class RazaDto
    {
        public string Nombre { get; set; }
        public int IdEspecieFk { get; set; }
        public EspecieDto Especie { get; set; }
    }
}