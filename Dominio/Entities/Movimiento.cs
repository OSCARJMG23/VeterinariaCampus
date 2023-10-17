using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Movimiento  : BaseEntity
    {
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public DateTime FechaMovimiento { get; set; }
        /* public int IdMedicamentoFk { get; set; }
        public Medicamento Medicamento { get; set; } */
        public int IdTipoMovimientoFk { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
        public ICollection<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    }
}