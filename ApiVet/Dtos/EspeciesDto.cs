using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
    public class EspeciesDto
    {
        public string Nombre { get; set; }
        public List<RazaDto> Razas { get; set; }
    }
}