using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimientoRepository
    {
        private readonly ApiVetContext _context;
        public TipoMovimientoRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }
    }
}