using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MovimientoMedicamento
    {
        public int IdMedicamentoFk { get; set; }
        public Medicamento Medicamento { get; set; }
        public int IdMovimientoFk { get; set; }
        public Movimiento Movimiento { get; set; }
    }
}