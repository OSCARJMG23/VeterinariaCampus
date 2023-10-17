using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Dtos
{
    public class MedicamentosDto
    {
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public int IdLaboratorioFk { get; set; }
        public LaboratorioDto Laboratorio { get; set; }
    }
}