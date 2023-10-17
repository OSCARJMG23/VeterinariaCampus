using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiVet.Dtos
{
    public class MovimientoDto
    {
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int IdTipoMovimientoFk { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}