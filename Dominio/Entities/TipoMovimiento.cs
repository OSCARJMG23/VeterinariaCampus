using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class TipoMovimiento  : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}